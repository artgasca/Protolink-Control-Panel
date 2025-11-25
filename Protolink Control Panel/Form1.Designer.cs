namespace Protolink_Control_Panel
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.grpConnection = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.lblIp = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkDi4 = new System.Windows.Forms.CheckBox();
            this.chkDi3 = new System.Windows.Forms.CheckBox();
            this.chkDi2 = new System.Windows.Forms.CheckBox();
            this.chkDi1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCh2Value = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCh1Value = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.chartCh1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.chkR4 = new System.Windows.Forms.CheckBox();
            this.chkR3 = new System.Windows.Forms.CheckBox();
            this.chkR2 = new System.Windows.Forms.CheckBox();
            this.chkR1 = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tmrPoll = new System.Windows.Forms.Timer(this.components);
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.chartCh2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grpConnection.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCh1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCh2)).BeginInit();
            this.SuspendLayout();
            // 
            // grpConnection
            // 
            this.grpConnection.Controls.Add(this.btnDisconnect);
            this.grpConnection.Controls.Add(this.lblStatus);
            this.grpConnection.Controls.Add(this.btnConnect);
            this.grpConnection.Controls.Add(this.txtPort);
            this.grpConnection.Controls.Add(this.lblPort);
            this.grpConnection.Controls.Add(this.txtIp);
            this.grpConnection.Controls.Add(this.lblIp);
            this.grpConnection.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConnection.ForeColor = System.Drawing.Color.SteelBlue;
            this.grpConnection.Location = new System.Drawing.Point(333, 12);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Size = new System.Drawing.Size(719, 80);
            this.grpConnection.TabIndex = 0;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Conexión Modbus";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.lblStatus.Location = new System.Drawing.Point(587, 32);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(132, 23);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Desconectado";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(334, 24);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(112, 38);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPort
            // 
            this.txtPort.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtPort.Location = new System.Drawing.Point(280, 29);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(48, 30);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "502";
            this.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(209, 32);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(65, 23);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Puerto";
            // 
            // txtIp
            // 
            this.txtIp.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtIp.Location = new System.Drawing.Point(48, 29);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(155, 30);
            this.txtIp.TabIndex = 1;
            this.txtIp.Text = "192.168.68.110";
            this.txtIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIp.TextChanged += new System.EventHandler(this.txtIp_TextChanged);
            // 
            // lblIp
            // 
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new System.Drawing.Point(15, 32);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new System.Drawing.Size(27, 23);
            this.lblIp.TabIndex = 0;
            this.lblIp.Text = "IP";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.chkDi4);
            this.panel1.Controls.Add(this.chkDi3);
            this.panel1.Controls.Add(this.chkDi2);
            this.panel1.Controls.Add(this.chkDi1);
            this.panel1.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(60, 322);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 347);
            this.panel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(51, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 33);
            this.label6.TabIndex = 8;
            this.label6.Text = "ENTRADAS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 271);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 33);
            this.label5.TabIndex = 7;
            this.label5.Text = "DI4";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 33);
            this.label4.TabIndex = 6;
            this.label4.Text = "DI3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 33);
            this.label3.TabIndex = 5;
            this.label3.Text = "DI2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 33);
            this.label2.TabIndex = 4;
            this.label2.Text = "DI1";
            // 
            // chkDi4
            // 
            this.chkDi4.AutoSize = true;
            this.chkDi4.Enabled = false;
            this.chkDi4.Location = new System.Drawing.Point(142, 270);
            this.chkDi4.Name = "chkDi4";
            this.chkDi4.Size = new System.Drawing.Size(72, 37);
            this.chkDi4.TabIndex = 3;
            this.chkDi4.Text = "ON";
            this.chkDi4.UseVisualStyleBackColor = true;
            // 
            // chkDi3
            // 
            this.chkDi3.AutoSize = true;
            this.chkDi3.Enabled = false;
            this.chkDi3.Location = new System.Drawing.Point(142, 206);
            this.chkDi3.Name = "chkDi3";
            this.chkDi3.Size = new System.Drawing.Size(72, 37);
            this.chkDi3.TabIndex = 2;
            this.chkDi3.Text = "ON";
            this.chkDi3.UseVisualStyleBackColor = true;
            // 
            // chkDi2
            // 
            this.chkDi2.AutoSize = true;
            this.chkDi2.Enabled = false;
            this.chkDi2.Location = new System.Drawing.Point(142, 144);
            this.chkDi2.Name = "chkDi2";
            this.chkDi2.Size = new System.Drawing.Size(72, 37);
            this.chkDi2.TabIndex = 1;
            this.chkDi2.Text = "ON";
            this.chkDi2.UseVisualStyleBackColor = true;
            // 
            // chkDi1
            // 
            this.chkDi1.AutoSize = true;
            this.chkDi1.Enabled = false;
            this.chkDi1.Location = new System.Drawing.Point(142, 81);
            this.chkDi1.Name = "chkDi1";
            this.chkDi1.Size = new System.Drawing.Size(72, 37);
            this.chkDi1.TabIndex = 0;
            this.chkDi1.Text = "ON";
            this.chkDi1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.lblCh2Value);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lblCh1Value);
            this.panel2.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.Color.SteelBlue;
            this.panel2.Location = new System.Drawing.Point(20, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 215);
            this.panel2.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(40, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 33);
            this.label7.TabIndex = 10;
            this.label7.Text = "ANALOGICAS";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(222, 141);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 33);
            this.label13.TabIndex = 9;
            this.label13.Text = "mA";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(31, 141);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 33);
            this.label14.TabIndex = 8;
            this.label14.Text = "CH2";
            // 
            // lblCh2Value
            // 
            this.lblCh2Value.AutoSize = true;
            this.lblCh2Value.Location = new System.Drawing.Point(105, 141);
            this.lblCh2Value.Name = "lblCh2Value";
            this.lblCh2Value.Size = new System.Drawing.Size(82, 33);
            this.lblCh2Value.TabIndex = 7;
            this.lblCh2Value.Text = "20.00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(222, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 33);
            this.label12.TabIndex = 6;
            this.label12.Text = "mA";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 33);
            this.label11.TabIndex = 5;
            this.label11.Text = "CH1";
            // 
            // lblCh1Value
            // 
            this.lblCh1Value.AutoSize = true;
            this.lblCh1Value.Location = new System.Drawing.Point(105, 78);
            this.lblCh1Value.Name = "lblCh1Value";
            this.lblCh1Value.Size = new System.Drawing.Size(82, 33);
            this.lblCh1Value.TabIndex = 0;
            this.lblCh1Value.Text = "20.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Flex ExtraBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(2, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 47);
            this.label1.TabIndex = 3;
            this.label1.Text = "Protolink HMI Panel";
            // 
            // chartCh1
            // 
            chartArea1.Name = "ChartArea1";
            this.chartCh1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartCh1.Legends.Add(legend1);
            this.chartCh1.Location = new System.Drawing.Point(3, 42);
            this.chartCh1.Name = "chartCh1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartCh1.Series.Add(series1);
            this.chartCh1.Size = new System.Drawing.Size(354, 170);
            this.chartCh1.TabIndex = 0;
            this.chartCh1.Text = "chartCh1";
            this.chartCh1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.chkR4);
            this.panel3.Controls.Add(this.chkR3);
            this.panel3.Controls.Add(this.chkR2);
            this.panel3.Controls.Add(this.chkR1);
            this.panel3.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.ForeColor = System.Drawing.Color.SteelBlue;
            this.panel3.Location = new System.Drawing.Point(387, 322);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 347);
            this.panel3.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DarkCyan;
            this.label8.Location = new System.Drawing.Point(51, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 33);
            this.label8.TabIndex = 8;
            this.label8.Text = "SALIDAS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 33);
            this.label9.TabIndex = 7;
            this.label9.Text = "R4";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(38, 207);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 33);
            this.label16.TabIndex = 6;
            this.label16.Text = "R3";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(38, 145);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 33);
            this.label17.TabIndex = 5;
            this.label17.Text = "R2";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(38, 82);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 33);
            this.label18.TabIndex = 4;
            this.label18.Text = "R1";
            // 
            // chkR4
            // 
            this.chkR4.AutoSize = true;
            this.chkR4.Location = new System.Drawing.Point(142, 270);
            this.chkR4.Name = "chkR4";
            this.chkR4.Size = new System.Drawing.Size(72, 37);
            this.chkR4.TabIndex = 3;
            this.chkR4.Text = "ON";
            this.chkR4.UseVisualStyleBackColor = true;
            this.chkR4.Click += new System.EventHandler(this.chkRelay_CheckedChanged);
            // 
            // chkR3
            // 
            this.chkR3.AutoSize = true;
            this.chkR3.Location = new System.Drawing.Point(142, 206);
            this.chkR3.Name = "chkR3";
            this.chkR3.Size = new System.Drawing.Size(72, 37);
            this.chkR3.TabIndex = 2;
            this.chkR3.Text = "ON";
            this.chkR3.UseVisualStyleBackColor = true;
            this.chkR3.Click += new System.EventHandler(this.chkRelay_CheckedChanged);
            // 
            // chkR2
            // 
            this.chkR2.AutoSize = true;
            this.chkR2.Location = new System.Drawing.Point(142, 144);
            this.chkR2.Name = "chkR2";
            this.chkR2.Size = new System.Drawing.Size(72, 37);
            this.chkR2.TabIndex = 1;
            this.chkR2.Text = "ON";
            this.chkR2.UseVisualStyleBackColor = true;
            this.chkR2.Click += new System.EventHandler(this.chkRelay_CheckedChanged);
            // 
            // chkR1
            // 
            this.chkR1.AutoSize = true;
            this.chkR1.Location = new System.Drawing.Point(142, 81);
            this.chkR1.Name = "chkR1";
            this.chkR1.Size = new System.Drawing.Size(72, 37);
            this.chkR1.TabIndex = 0;
            this.chkR1.Text = "ON";
            this.chkR1.UseVisualStyleBackColor = true;
            this.chkR1.Click += new System.EventHandler(this.chkRelay_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.textBox6);
            this.panel4.Controls.Add(this.label25);
            this.panel4.Controls.Add(this.textBox5);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.textBox4);
            this.panel4.Controls.Add(this.label22);
            this.panel4.Controls.Add(this.textBox3);
            this.panel4.Controls.Add(this.label21);
            this.panel4.Controls.Add(this.textBox2);
            this.panel4.Controls.Add(this.label20);
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.label23);
            this.panel4.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.ForeColor = System.Drawing.Color.SteelBlue;
            this.panel4.Location = new System.Drawing.Point(715, 322);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 347);
            this.panel4.TabIndex = 8;
            // 
            // textBox6
            // 
            this.textBox6.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBox6.Location = new System.Drawing.Point(120, 268);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 40);
            this.textBox6.TabIndex = 19;
            this.textBox6.Text = "2000";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(13, 271);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(101, 33);
            this.label25.TabIndex = 18;
            this.label25.Text = "CONF1";
            // 
            // textBox5
            // 
            this.textBox5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBox5.Location = new System.Drawing.Point(120, 227);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 40);
            this.textBox5.TabIndex = 17;
            this.textBox5.Text = "2000";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(13, 230);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(101, 33);
            this.label24.TabIndex = 16;
            this.label24.Text = "CONF1";
            // 
            // textBox4
            // 
            this.textBox4.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBox4.Location = new System.Drawing.Point(120, 185);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 40);
            this.textBox4.TabIndex = 15;
            this.textBox4.Text = "2000";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(13, 188);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(101, 33);
            this.label22.TabIndex = 14;
            this.label22.Text = "CONF1";
            // 
            // textBox3
            // 
            this.textBox3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBox3.Location = new System.Drawing.Point(120, 142);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 40);
            this.textBox3.TabIndex = 13;
            this.textBox3.Text = "2000";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 145);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(101, 33);
            this.label21.TabIndex = 12;
            this.label21.Text = "CONF1";
            // 
            // textBox2
            // 
            this.textBox2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBox2.Location = new System.Drawing.Point(120, 101);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 40);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "2000";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 104);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(101, 33);
            this.label20.TabIndex = 10;
            this.label20.Text = "CONF1";
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBox1.Location = new System.Drawing.Point(120, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 40);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "2000";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.Color.DarkCyan;
            this.label19.Location = new System.Drawing.Point(13, 12);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(227, 33);
            this.label19.TabIndex = 8;
            this.label19.Text = "CONFIGURACION";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(13, 62);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(101, 33);
            this.label23.TabIndex = 4;
            this.label23.Text = "CONF1";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(452, 24);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(129, 38);
            this.btnDisconnect.TabIndex = 6;
            this.btnDisconnect.Text = "Desconectar";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.chartCh2);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.chartCh1);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.ForeColor = System.Drawing.Color.SteelBlue;
            this.panel5.Location = new System.Drawing.Point(322, 101);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(717, 215);
            this.panel5.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DarkCyan;
            this.label10.Location = new System.Drawing.Point(157, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 33);
            this.label10.TabIndex = 8;
            this.label10.Text = "CH1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.DarkCyan;
            this.label15.Location = new System.Drawing.Point(525, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 33);
            this.label15.TabIndex = 9;
            this.label15.Text = "CH2";
            // 
            // chartCh2
            // 
            chartArea2.Name = "ChartArea1";
            this.chartCh2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartCh2.Legends.Add(legend2);
            this.chartCh2.Location = new System.Drawing.Point(360, 45);
            this.chartCh2.Name = "chartCh2";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartCh2.Series.Add(series2);
            this.chartCh2.Size = new System.Drawing.Size(354, 170);
            this.chartCh2.TabIndex = 10;
            this.chartCh2.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grpConnection);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Protolink HMI Panel v1.0.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.grpConnection.ResumeLayout(false);
            this.grpConnection.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCh1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCh2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConnection;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label lblIp;
        private System.Windows.Forms.CheckBox chkDi1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkDi4;
        private System.Windows.Forms.CheckBox chkDi3;
        private System.Windows.Forms.CheckBox chkDi2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblCh2Value;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCh1Value;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCh1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chkR4;
        private System.Windows.Forms.CheckBox chkR3;
        private System.Windows.Forms.CheckBox chkR2;
        private System.Windows.Forms.CheckBox chkR1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Timer tmrPoll;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCh2;
    }
}

