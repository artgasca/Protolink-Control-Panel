# Protolink HMI Panel

Panel HMI para **Protolink** sobre **Windows Forms (.NET + C#)**, utilizando **Modbus TCP** y la librería **EasyModbus**.

Este proyecto sirve como cliente HMI ligero para:

- Visualizar **entradas analógicas** (mA) con gráfica en tiempo real.  
- Ver el estado de **entradas digitales (DI)**.  
- Leer y escribir **salidas a relevador (DO / coils)**.  
- Sentar las bases para futuras **configuraciones por holding registers** y expansión de I/O.

---

## 1. Requisitos

- Windows 10/11  
- .NET Framework 4.8 **o** .NET 6 Windows (WinForms)  
- Visual Studio (o IDE compatible)  
- Acceso a un dispositivo **Protolink** con firmware Modbus TCP

### Dependencias NuGet

Librería Modbus:

```powershell
Install-Package EasyModbusTCP

using EasyModbus;

```

## 2. Arquitectura general

El proyecto está centrado en un FormMain (WinForms) que contiene:

### Sección de conexión Modbus

- txtIp, txtPort

- btnConectar, btnDisconnect

- lblEstadoConexion

### Analógicas

- Labels de valor:

- lblCh1Value (AI1 en mA)

- lblCh2Value (AI2 en mA)

### Charts de tendencia:

- chartCh1

- chartCh2

### Entradas digitales

- chkDi1…chkDi4 (solo visuales, Enabled = false)

### Salidas a relevador

- chkR1…chkR4 (escritura de coils)

- Escritura protegida con verificación de conexión y flag interno para evitar rebotes.

### Timer de polling

- tmrPoll (típicamente 500 ms)

- Encargado de disparar la lectura periódica de Modbus.

### Clase de mapa Modbus

Los offsets de registros se definen en una clase estática tipo:
```c#
static class ProtolinkMap
{
    // --- Input Registers (3x) ---
    public const int INREG_AI1_RAW    = 0;   // 30001 (2 regs float)
    public const int INREG_AI1_MA     = 2;   // 30003 (2 regs float)
    public const int INREG_AI1_SCALED = 4;   // 30005 (1 reg)

    public const int INREG_AI2_RAW    = 10;  // 30011 (2 regs float)
    public const int INREG_AI2_MA     = 12;  // 30013 (2 regs float)
    public const int INREG_AI2_SCALED = 14;  // 30015 (1 reg)

    public const int INREG_BASCULA1   = 20;  // 30021 (2 regs float)
    public const int INREG_BASCULA2   = 22;  // 30023 (2 regs float)

    // --- Discrete Inputs (1x) ---
    public const int DI_START = 0;           // 10001..10004 → DI1..DI4

    // --- Coils (0x) ---
    public const int DO_START = 0;           // 00001..00004 → R1..R4

    // --- Holding Registers (4x) ---
    // Reservado para expansión futura de configuraciones.
}
```

EasyModbus utiliza direccionamiento 0-based: 0 → 30001, 1 → 30002, etc.
El mapa está alineado con los #define originales del firmware Protolink.

## 3. Uso de EasyModbus en el proyecto
### 3.1. Conexión Modbus TCP
```C#
private ModbusClient _modbus;

private void btnConectar_Click(object sender, EventArgs e)
{
    string ip = txtIp.Text.Trim();
    int port  = int.Parse(txtPort.Text.Trim());

    _modbus = new ModbusClient(ip, port);
    // _modbus.UnitIdentifier = 1; // si el slave ID es distinto

    _modbus.Connect();
    SetConnectionState(_modbus.Connected);
}

```


Desconexión segura:
```C#
private void btnDisconnect_Click(object sender, EventArgs e)
{
    tmrPoll.Stop();
    try
    {
        if (_modbus != null && _modbus.Connected)
            _modbus.Disconnect();
    }
    finally
    {
        _modbus = null;
        SetConnectionState(false);
    }
}
```

### SetConnectionState(bool connected):

- Actualiza lblEstadoConexion (texto / color).

- Inicia/detiene tmrPoll.

- Limpia los valores de UI.

### Habilita/deshabilita:

- btnConectar, btnDisconnect

- chkR1…chkR4 (solo se pueden usar con conexión activa).

### 3.2. Lectura periódica (Timer de polling)

### tmrPoll_Tick ejecuta el ciclo de adquisición:
```C#
private bool _updatingFromPoll = false;

private void tmrPoll_Tick(object sender, EventArgs e)
{
    if (_modbus == null || !_modbus.Connected)
        return;

    try
    {
        _updatingFromPoll = true;

        UpdateAnalogInputs();
        UpdateDigitalInputs();
        UpdateRelayOutputs();
    }
    catch (Exception ex)
    {
        // Manejo básico de error: log / aviso y desconexión
        Console.WriteLine("Error en poll: " + ex.Message);
        SetConnectionState(false);
    }
    finally
    {
        _updatingFromPoll = false;
    }
}
```
### 3.3. Lectura de análogas (AI1 / AI2)
Helper para float Modbus (HighWord–LowWord)

El firmware Protolink envía floats como HighWord–LowWord, así que se utiliza:
```C#
private float ReadFloatInputRegister(int startAddress)
{
    int[] regs = _modbus.ReadInputRegisters(startAddress, 2);
    return ModbusClient.ConvertRegistersToFloat(
               regs, ModbusClient.RegisterOrder.HighLow);
}
```
Actualizar UI y charts
```C#
private void UpdateAnalogInputs()
{
    float ch1_mA = ReadFloatInputRegister(ProtolinkMap.INREG_AI1_MA);
    float ch2_mA = ReadFloatInputRegister(ProtolinkMap.INREG_AI2_MA);

    lblCh1Value.Text = ch1_mA.ToString("0.00") + " mA";
    lblCh2Value.Text = ch2_mA.ToString("0.00") + " mA";

    UpdateCharts(ch1_mA, ch2_mA);
}
```


UpdateCharts agrega puntos a chartCh1 y chartCh2 manteniendo una ventana de N muestras:
```C#
private readonly int _maxChartPoints = 120; // p.ej. ~1 min a 500 ms

private void UpdateCharts(float ch1_mA, float ch2_mA)
{
    DateTime now = DateTime.Now;
    AppendChartPoint(chartCh1, now, ch1_mA);
    AppendChartPoint(chartCh2, now, ch2_mA);
}

private void AppendChartPoint(Chart chart, DateTime time, double value)
{
    if (chart.Series.Count == 0)
        return;

    Series s = chart.Series[0];
    s.Points.AddXY(time.ToOADate(), value);

    while (s.Points.Count > _maxChartPoints)
        s.Points.RemoveAt(0);

    if (s.Points.Count > 1)
    {
        double minX = s.Points[0].XValue;
        double maxX = s.Points[^1].XValue;
        var area = chart.ChartAreas[0];
        area.AxisX.Minimum = minX;
        area.AxisX.Maximum = maxX;
    }

    chart.Invalidate();
}
```
### 3.4. Lectura de entradas digitales (DI1..DI4)

Las entradas digitales se mapean a Discrete Inputs (1x) a partir de DI_START.
```C#
private void UpdateDigitalInputs()
{
    bool[] di = _modbus.ReadDiscreteInputs(ProtolinkMap.DI_START, 4);

    chkDi1.Checked = di.Length > 0 && di[0];
    chkDi2.Checked = di.Length > 1 && di[1];
    chkDi3.Checked = di.Length > 2 && di[2];
    chkDi4.Checked = di.Length > 3 && di[3];
}
```

Los checkboxes chkDiX están en modo solo lectura visual (Enabled = false).

### 3.5. Lectura y escritura de salidas (R1..R4)

Las salidas se manejan como Coils (0x) a partir de DO_START.

Lectura del estado real (por si hay otros masters Modbus)
```C#
private void UpdateRelayOutputs()
{
    bool[] coils = _modbus.ReadCoils(ProtolinkMap.DO_START, 4);

    chkR1.Checked = coils.Length > 0 && coils[0];
    chkR2.Checked = coils.Length > 1 && coils[1];
    chkR3.Checked = coils.Length > 2 && coils[2];
    chkR4.Checked = coils.Length > 3 && coils[3];
}
```
Escritura desde la UI (click en los checkboxes)

```C#
private void chkRelay_CheckedChanged(object sender, EventArgs e)
{
    // Evitar escrituras cuando estamos actualizando desde el polling
    if (_updatingFromPoll)
        return;

    CheckBox chk = (CheckBox)sender;

    // Si no hay conexión, revertimos el cambio visual y salimos en silencio
    if (_modbus == null || !_modbus.Connected)
    {
        _updatingFromPoll = true;
        chk.Checked = !chk.Checked;
        _updatingFromPoll = false;
        return;
    }

    try
    {
        int coilIndex = 0;

        if (chk == chkR1) coilIndex = 0;
        else if (chk == chkR2) coilIndex = 1;
        else if (chk == chkR3) coilIndex = 2;
        else if (chk == chkR4) coilIndex = 3;

        bool value = chk.Checked;
        _modbus.WriteSingleCoil(ProtolinkMap.DO_START + coilIndex, value);
    }
    catch (Exception ex)
    {
        MessageBox.Show(
            "Error al escribir relé: " + ex.Message,
            "Escritura Modbus",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
    }
}
```

Los checkboxes chkR1…chkR4 solo están habilitados cuando SetConnectionState(true).

## 4. Mapa de registros actualmente utilizados
### 4.1. Input Registers (3x)



| Nombre             | Offset (0-based) | Dirección Modbus | Descripción                         | Tipo               |
| ------------------ | ---------------- | ---------------- | ----------------------------------- | ------------------ |
| `INREG_AI1_RAW`    | 0                | 30001–30002      | Valor RAW AI1 (float)               | float              |
| `INREG_AI1_MA`     | 2                | 30003–30004      | Corriente AI1 en mA (float)         | float              |
| `INREG_AI1_SCALED` | 4                | 30005            | Valor escalado AI1 (unidad proceso) | int / futuro float |
| `INREG_AI2_RAW`    | 10               | 30011–30012      | Valor RAW AI2 (float)               | float              |
| `INREG_AI2_MA`     | 12               | 30013–30014      | Corriente AI2 en mA (float)         | float              |
| `INREG_AI2_SCALED` | 14               | 30015            | Valor escalado AI2                  | int / futuro float |
| `INREG_BASCULA1`   | 20               | 30021–30022      | Lectura báscula 1                   | float              |
| `INREG_BASCULA2`   | 22               | 30023–30024      | Lectura báscula 2                   | float              |


Todos los float se leen como 2 registros y se convierten con
ModbusClient.ConvertRegistersToFloat(regs, RegisterOrder.HighLow).

### 4.2. Discrete Inputs (1x)

| Señal | Tipo           | Offset (0-based) | Dirección típica |
| ----- | -------------- | ---------------- | ---------------- |
| DI1   | Discrete Input | `DI_START + 0`   | 10001            |
| DI2   | Discrete Input | `DI_START + 1`   | 10002            |
| DI3   | Discrete Input | `DI_START + 2`   | 10003            |
| DI4   | Discrete Input | `DI_START + 3`   | 10004            |

### 4.3. Coils (0x)

| Señal | Tipo | Offset (0-based) | Dirección típica |
| ----- | ---- | ---------------- | ---------------- |
| R1    | Coil | `DO_START + 0`   | 00001            |
| R2    | Coil | `DO_START + 1`   | 00002            |
| R3    | Coil | `DO_START + 2`   | 00003            |
| R4    | Coil | `DO_START + 3`   | 00004            |

## 5. Espacio para expansión futura

La estructura del proyecto está pensada para crecer sin romper nada.

### 5.1. Holding Registers (4x) – Configuración

Pendiente de integrar (próximos sprints).
Se propone declarar en ProtolinkMap algo como:
```C#

// --- Holding Registers (4x) - Configuración ---
public const int HOLD_CFG_BASE        = 0;  // 40001+
public const int HOLD_CFG_MODE_OP     = HOLD_CFG_BASE + 0;  // modo operación
public const int HOLD_CFG_HEARTBEAT   = HOLD_CFG_BASE + 1;  // heartbeat, s
public const int HOLD_CFG_FILTER_AI1  = HOLD_CFG_BASE + 2;  // filtro AI1
public const int HOLD_CFG_FILTER_AI2  = HOLD_CFG_BASE + 3;  // filtro AI2
// ... seguir en orden para nuevos parámetros


```
En el HMI se puede agregar una sección de “Configuración” con:

Lectura total (ReadHoldingRegisters) a un bloque continuo.

Escritura controlada (WriteMultipleRegisters o WriteSingleRegister) con confirmación de usuario.

### 5.2. Más entradas digitales / salidas

Si se amplía el hardware:

- Entradas digitales:

Extender DI_START manteniendo el orden (DI5 = DI_START + 4, etc.)

UI: añadir chkDi5… o migrar la sección DI a un DataGridView.

- Salidas (coils):

Extender DO_START (R5 = DO_START + 4, etc.).

UI: añadir nuevos checkboxes o filas en una tabla de salidas.

La lógica de lectura/escritura es fácilmente escalable modificando:

- Cantidad de bits en las llamadas ReadDiscreteInputs / ReadCoils.

- El switch o mapping en chkRelay_CheckedChanged.

## 6. Resumen

- El HMI usa EasyModbus como cliente Modbus TCP para hablar con Protolink.

- Se implementa una desconexión segura y un polling periódico de entradas/salidas.

 -Las análogas se leen como float en formato HighWord–LowWord y se grafican en tiempo real.

- Las entradas digitales se muestran como indicadores, y las salidas pueden controlarse desde la UI, respetando el estado del bus.

 - El diseño del mapa (ProtolinkMap) y de la UI deja espacio reservado para:

       - Configuración avanzada por holding registers.

       - Expansión de más entradas y salidas manteniendo el orden actual.

Cuando haya nuevos registros o módulos (config, diagnóstico extra, más AI/DI/DO), basta con:

1.- Declararlos en ProtolinkMap.

2.- Amarrarlos a nuevos controles en el formulario.

3.- Incluirlos en el ciclo de polling / escritura donde corresponda.
