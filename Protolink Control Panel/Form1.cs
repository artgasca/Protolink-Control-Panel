using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;
using System.Windows.Forms.DataVisualization.Charting;





namespace Protolink_Control_Panel
{


    public partial class Form1 : Form
    {
        private ModbusClient _modbus;
        private bool _updatingFromPoll = false;  // para no disparar escrituras al refrescar
        private readonly int _maxChartPoints = 120; // aprox 1 minuto si tmrPoll=500ms

        public Form1()
        {
            InitializeComponent();
            InitUi();
            InitCharts();
        }
        static class ProtolinkMap
        {
            // ---- Input Registers (3x) ----
            // 30001–30003 : AI1
            // 30011–30013 : AI2
            // 30021+      : Diagnóstico / Telemetría

            public const int INREG_AI1_RAW = 0;   // 30001 (2 regs float)
            public const int INREG_AI1_MA = 2;   // 30003 (2 regs float)
            public const int INREG_AI1_SCALED = 4;   // 30005 (1 reg, por ahora lo tomamos como int)

            public const int INREG_AI2_RAW = 10;  // 30011 (2 regs float)
            public const int INREG_AI2_MA = 12;  // 30013 (2 regs float)
            public const int INREG_AI2_SCALED = 14;  // 30015

            public const int INREG_BASCULA1 = 20;  // 30021 (2 regs float)
            public const int INREG_BASCULA2 = 22;  // 30023 (2 regs float)

            // Discrete Inputs (10001+): DI1..DI4
            public const int DI_START = 0;   // 10001..10004

            // Coils (00001+): R1..R4
            public const int DO_START = 0;   // 00001..00004
        }


        private void InitUi()
        {
            txtIp.Text = "192.168.68.111";
            txtPort.Text = "502";

            SetConnectionState(false);

            // Entradas solo lectura visual
            chkDi1.Enabled = false;
            chkDi2.Enabled = false;
            chkDi3.Enabled = false;
            chkDi4.Enabled = false;

            // Salidas: deshabilitadas hasta que haya conexión
            chkR1.Enabled = false;
            chkR2.Enabled = false;
            chkR3.Enabled = false;
            chkR4.Enabled = false;


            // Timer
            tmrPoll.Interval = 500; // ms
            tmrPoll.Tick += tmrPoll_Tick;

            // Eventos de salidas
            chkR1.CheckedChanged += chkRelay_CheckedChanged;
            chkR2.CheckedChanged += chkRelay_CheckedChanged;
            chkR3.CheckedChanged += chkRelay_CheckedChanged;
            chkR4.CheckedChanged += chkRelay_CheckedChanged;

            // Botón de desconexión
            btnDisconnect.Click += btnDisconnect_Click;
            btnDisconnect.Enabled = false;   // solo se habilita cuando haya conexión
        }

        private void InitCharts()
        {
            InitSingleChart(chartCh1, "CH1");
            InitSingleChart(chartCh2, "CH2");
        }

        private void InitSingleChart(Chart chart, string seriesName)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            // Área
            var area = new ChartArea("Area1");
            area.AxisX.LabelStyle.Format = "HH:mm:ss";
            area.AxisX.IntervalType = DateTimeIntervalType.Seconds;
            area.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

            area.AxisY.Title = "mA";
            area.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;

            chart.ChartAreas.Add(area);

            // Serie
            var s = new Series(seriesName);
            s.ChartType = SeriesChartType.Line;
            s.ChartArea = "Area1";
            s.XValueType = ChartValueType.DateTime;
            s.IsXValueIndexed = false;

            chart.Series.Add(s);

            chart.Legends.Clear(); // si no quieres la leyenda "Series1"
        }


        private void SetConnectionState(bool connected)
        {
            if (connected)
            {
                lblStatus.Text = "Conectado";
                lblStatus.ForeColor = System.Drawing.Color.DarkGreen;
                tmrPoll.Start();
            }
            else
            {
                lblStatus.Text = "Desconectado";
                lblStatus.ForeColor = System.Drawing.Color.DarkRed;
                tmrPoll.Stop();

                // Limpia valores visuales
                lblCh1Value.Text = "--.--";
                lblCh2Value.Text = "--.--";

                chkDi1.Checked = false;
                chkDi2.Checked = false;
                chkDi3.Checked = false;
                chkDi4.Checked = false;

                chkR1.Checked = false;
                chkR2.Checked = false;
                chkR3.Checked = false;
                chkR4.Checked = false;
            }

            btnConnect.Enabled = !connected;
            btnDisconnect.Enabled = connected;
            // Habilitar relés solo si hay conexión
            chkR1.Enabled = connected;
            chkR2.Enabled = connected;
            chkR3.Enabled = connected;
            chkR4.Enabled = connected;
        }

        private void tmrPoll_Tick(object sender, EventArgs e)
        {
            if (_modbus == null || !_modbus.Connected)
                return;

            try
            {
                _updatingFromPoll = true;

                // 1) Leer análogas
                UpdateAnalogInputs();

                // 2) Leer entradas digitales
                UpdateDigitalInputs();

                // 3) Leer estado real de salidas (por si otro master escribe)
                UpdateRelayOutputs();
            }
            catch (Exception ex)
            {
                // Aquí puedes loguear o mostrar algo pequeño
                Console.WriteLine("Error en poll: " + ex.Message);
                SetConnectionState(false);
            }
            finally
            {
                _updatingFromPoll = false;
            }
        }
        private void UpdateAnalogInputs()
        {
            // AI1: mA en 30003/30004 (INREG_AI1_MA)
            float ch1_mA = ReadFloatInputRegister(ProtolinkMap.INREG_AI1_MA);

            // AI2: mA en 30013/30014 (INREG_AI2_MA)
            float ch2_mA = ReadFloatInputRegister(ProtolinkMap.INREG_AI2_MA);


            // UI numérica
            lblCh1Value.Text = ch1_mA.ToString("0.00");
            lblCh2Value.Text = ch2_mA.ToString("0.00");



            // Charts
            UpdateCharts(ch1_mA, ch2_mA);
        }

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

            // Agregamos nuevo punto
            s.Points.AddXY(time.ToOADate(), value);

            // Limitar puntos para que no crezca infinito
            while (s.Points.Count > _maxChartPoints)
            {
                s.Points.RemoveAt(0);
            }

            // Ajustar vista del eje X al rango visible actual
            if (s.Points.Count > 1)
            {
                double minX = s.Points[0].XValue;
                double maxX = s.Points[s.Points.Count - 1].XValue;

                var area = chart.ChartAreas[0];
                area.AxisX.Minimum = minX;
                area.AxisX.Maximum = maxX;
            }

            chart.Invalidate(); // refresca
        }


        private void UpdateDigitalInputs()
        {
            // Leer 4 discrete inputs desde DI_START
            bool[] di = _modbus.ReadDiscreteInputs(ProtolinkMap.DI_START, 4);

            chkDi1.Checked = di.Length > 0 && di[0];
            chkDi2.Checked = di.Length > 1 && di[1];
            chkDi3.Checked = di.Length > 2 && di[2];
            chkDi4.Checked = di.Length > 3 && di[3];
        }
        private void UpdateRelayOutputs()
        {
            bool[] coils = _modbus.ReadCoils(ProtolinkMap.DO_START, 4);

            chkR1.Checked = coils.Length > 0 && coils[0];
            chkR2.Checked = coils.Length > 1 && coils[1];
            chkR3.Checked = coils.Length > 2 && coils[2];
            chkR4.Checked = coils.Length > 3 && coils[3];
        }

        private float ReadFloatInputRegister(int startAddress)
        {
            // Lee 2 registros de Input (3x)
            int[] regs = _modbus.ReadInputRegisters(startAddress, 2);

            // Si el Protolink guarda LowWord primero, esto te va a salir bien.
            // Si ves valores raros, probamos con el RegisterOrder.HighLow:
            // return ModbusClient.ConvertRegistersToFloat(regs, ModbusClient.RegisterOrder.HighLow);

            //return ModbusClient.ConvertRegistersToFloat(regs);
            return ModbusClient.ConvertRegistersToFloat(
           regs, ModbusClient.RegisterOrder.HighLow);
        }





        private void txtIp_TextChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtIp.Text.Trim();
                int port = int.Parse(txtPort.Text.Trim());

                if (_modbus != null && _modbus.Connected)
                {
                    _modbus.Disconnect();
                }

                _modbus = new ModbusClient(ip, port);
                // si usas UnitIdentifier distinto de 1, configúralo aquí:
                // _modbus.UnitIdentifier = 1;

                _modbus.Connect();

                SetConnectionState(_modbus.Connected);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al conectar: " + ex.Message,
                    "Conexión Modbus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                SetConnectionState(false);
            }

        }
        private void chkRelay_CheckedChanged(object sender, EventArgs e)
        {
            // Si el cambio viene del polling, no escribir nada
            if (_updatingFromPoll)
                return;

            CheckBox chk = (CheckBox)sender;

            // Si no hay conexión, revertimos el cambio visual y salimos en silencio
            if (_modbus == null || !_modbus.Connected)
            {
                _updatingFromPoll = true;
                chk.Checked = !chk.Checked;   // regresar al estado anterior
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
                MessageBox.Show("Error al escribir relé: " + ex.Message,
                    "Escritura Modbus",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            // Paramos el polling antes de tocar el socket
            tmrPoll.Stop();

            try
            {
                if (_modbus != null && _modbus.Connected)
                {
                    _modbus.Disconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al desconectar Modbus: " + ex.Message,
                    "Desconexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            finally
            {
                _modbus = null;
                SetConnectionState(false);
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                tmrPoll.Stop();

                if (_modbus != null && _modbus.Connected)
                    _modbus.Disconnect();
            }
            catch { /* silencio, ya nos vamos */ }
        }
    }
}
