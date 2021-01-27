namespace Modbus
{
    partial class Modbus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modbus));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Save_Tcp_Btn = new System.Windows.Forms.Button();
            this.Clean_Tcp = new System.Windows.Forms.Button();
            this.Time_Out_Textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.当前连接 = new System.Windows.Forms.Label();
            this.Remote_Port = new System.Windows.Forms.Label();
            this.TCP = new System.Windows.Forms.Label();
            this.TCP_Startbtn = new System.Windows.Forms.Button();
            this.Ip_Address = new System.Windows.Forms.Label();
            this.tcpListenPortTextBox = new System.Windows.Forms.TextBox();
            this.myIPtextBox = new System.Windows.Forms.TextBox();
            this.Connection = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Save_Rtu_Btn = new System.Windows.Forms.Button();
            this.Clean_Rtu = new System.Windows.Forms.Button();
            this.RTU_label = new System.Windows.Forms.Label();
            this.Serial_OpenBtn = new System.Windows.Forms.Button();
            this.Parity_Bit = new System.Windows.Forms.Label();
            this.Stop_Bit = new System.Windows.Forms.Label();
            this.Data_Bit = new System.Windows.Forms.Label();
            this.Buad_Rate = new System.Windows.Forms.Label();
            this.Serial_Port = new System.Windows.Forms.Label();
            this.comboPortBaudRate = new System.Windows.Forms.ComboBox();
            this.comboParity = new System.Windows.Forms.ComboBox();
            this.comboPortName = new System.Windows.Forms.ComboBox();
            this.comboStopBits = new System.Windows.Forms.ComboBox();
            this.comboDataBits = new System.Windows.Forms.ComboBox();
            this.RecvRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SerialRecv_TextBox = new System.Windows.Forms.RichTextBox();
            this.Tcp_Send = new System.Windows.Forms.GroupBox();
            this.DataFrame = new System.Windows.Forms.RichTextBox();
            this.Create_Tcp = new System.Windows.Forms.Button();
            this.UnitID = new System.Windows.Forms.TextBox();
            this.Amount_Tcp = new System.Windows.Forms.TextBox();
            this.Func_Code = new System.Windows.Forms.ComboBox();
            this.Tcp_Sendbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Addr_Tcp = new System.Windows.Forms.TextBox();
            this.Counter_Tcp = new System.Windows.Forms.TextBox();
            this.Recv_Timer = new System.Windows.Forms.Timer(this.components);
            this.Rtu_Recv = new System.Windows.Forms.GroupBox();
            this.SlaveID_Rtu_Label = new System.Windows.Forms.Label();
            this.SlaveID_Rtu = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Create_Rtu = new System.Windows.Forms.Button();
            this.Amount_Rtu = new System.Windows.Forms.TextBox();
            this.Addr_Rtu = new System.Windows.Forms.TextBox();
            this.Func_Code_Rtu = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Tcp_Send.SuspendLayout();
            this.Rtu_Recv.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Save_Tcp_Btn);
            this.groupBox3.Controls.Add(this.Clean_Tcp);
            this.groupBox3.Controls.Add(this.Time_Out_Textbox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.当前连接);
            this.groupBox3.Controls.Add(this.Remote_Port);
            this.groupBox3.Controls.Add(this.TCP);
            this.groupBox3.Controls.Add(this.TCP_Startbtn);
            this.groupBox3.Controls.Add(this.Ip_Address);
            this.groupBox3.Controls.Add(this.tcpListenPortTextBox);
            this.groupBox3.Controls.Add(this.myIPtextBox);
            this.groupBox3.Controls.Add(this.Connection);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(4, 3);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(331, 351);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TCP Master/Settings";
            // 
            // Save_Tcp_Btn
            // 
            this.Save_Tcp_Btn.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Save_Tcp_Btn.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Save_Tcp_Btn.Location = new System.Drawing.Point(29, 303);
            this.Save_Tcp_Btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Save_Tcp_Btn.Name = "Save_Tcp_Btn";
            this.Save_Tcp_Btn.Size = new System.Drawing.Size(102, 36);
            this.Save_Tcp_Btn.TabIndex = 39;
            this.Save_Tcp_Btn.Text = "Save_Tcp";
            this.Save_Tcp_Btn.UseVisualStyleBackColor = false;
            this.Save_Tcp_Btn.Click += new System.EventHandler(this.Save_Tcp_Btn_Click);
            // 
            // Clean_Tcp
            // 
            this.Clean_Tcp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Clean_Tcp.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clean_Tcp.Location = new System.Drawing.Point(153, 303);
            this.Clean_Tcp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Clean_Tcp.Name = "Clean_Tcp";
            this.Clean_Tcp.Size = new System.Drawing.Size(152, 36);
            this.Clean_Tcp.TabIndex = 38;
            this.Clean_Tcp.Text = "Clean_Tcp";
            this.Clean_Tcp.UseVisualStyleBackColor = false;
            this.Clean_Tcp.Click += new System.EventHandler(this.Clean_Tcp_Click);
            // 
            // Time_Out_Textbox
            // 
            this.Time_Out_Textbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Time_Out_Textbox.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_Out_Textbox.Location = new System.Drawing.Point(153, 253);
            this.Time_Out_Textbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Time_Out_Textbox.Name = "Time_Out_Textbox";
            this.Time_Out_Textbox.Size = new System.Drawing.Size(152, 29);
            this.Time_Out_Textbox.TabIndex = 37;
            this.Time_Out_Textbox.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 23);
            this.label2.TabIndex = 36;
            this.label2.Text = "Time Out (ms)";
            // 
            // 当前连接
            // 
            this.当前连接.AutoSize = true;
            this.当前连接.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.当前连接.Location = new System.Drawing.Point(25, 42);
            this.当前连接.Name = "当前连接";
            this.当前连接.Size = new System.Drawing.Size(58, 23);
            this.当前连接.TabIndex = 0;
            this.当前连接.Text = "Status";
            // 
            // Remote_Port
            // 
            this.Remote_Port.AutoSize = true;
            this.Remote_Port.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remote_Port.Location = new System.Drawing.Point(25, 203);
            this.Remote_Port.Name = "Remote_Port";
            this.Remote_Port.Size = new System.Drawing.Size(106, 23);
            this.Remote_Port.TabIndex = 28;
            this.Remote_Port.Text = "Remote Port";
            // 
            // TCP
            // 
            this.TCP.AutoSize = true;
            this.TCP.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCP.Location = new System.Drawing.Point(25, 96);
            this.TCP.Name = "TCP";
            this.TCP.Size = new System.Drawing.Size(39, 23);
            this.TCP.TabIndex = 35;
            this.TCP.Text = "TCP";
            // 
            // TCP_Startbtn
            // 
            this.TCP_Startbtn.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TCP_Startbtn.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TCP_Startbtn.Location = new System.Drawing.Point(153, 88);
            this.TCP_Startbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TCP_Startbtn.Name = "TCP_Startbtn";
            this.TCP_Startbtn.Size = new System.Drawing.Size(152, 36);
            this.TCP_Startbtn.TabIndex = 34;
            this.TCP_Startbtn.Text = "Connect";
            this.TCP_Startbtn.UseVisualStyleBackColor = false;
            this.TCP_Startbtn.Click += new System.EventHandler(this.TCP_Startbtn_Click);
            // 
            // Ip_Address
            // 
            this.Ip_Address.AutoSize = true;
            this.Ip_Address.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ip_Address.Location = new System.Drawing.Point(25, 153);
            this.Ip_Address.Name = "Ip_Address";
            this.Ip_Address.Size = new System.Drawing.Size(93, 23);
            this.Ip_Address.TabIndex = 1;
            this.Ip_Address.Text = "Ip Address";
            // 
            // tcpListenPortTextBox
            // 
            this.tcpListenPortTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.tcpListenPortTextBox.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcpListenPortTextBox.Location = new System.Drawing.Point(153, 198);
            this.tcpListenPortTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tcpListenPortTextBox.Name = "tcpListenPortTextBox";
            this.tcpListenPortTextBox.Size = new System.Drawing.Size(152, 29);
            this.tcpListenPortTextBox.TabIndex = 32;
            this.tcpListenPortTextBox.Text = "502";
            // 
            // myIPtextBox
            // 
            this.myIPtextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.myIPtextBox.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.myIPtextBox.Location = new System.Drawing.Point(153, 148);
            this.myIPtextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.myIPtextBox.Name = "myIPtextBox";
            this.myIPtextBox.Size = new System.Drawing.Size(152, 29);
            this.myIPtextBox.TabIndex = 32;
            this.myIPtextBox.Text = "127.0.0.1";
            // 
            // Connection
            // 
            this.Connection.AutoSize = true;
            this.Connection.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connection.Location = new System.Drawing.Point(153, 42);
            this.Connection.Name = "Connection";
            this.Connection.Size = new System.Drawing.Size(122, 23);
            this.Connection.TabIndex = 33;
            this.Connection.Text = "No connection";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Save_Rtu_Btn);
            this.groupBox1.Controls.Add(this.Clean_Rtu);
            this.groupBox1.Controls.Add(this.RTU_label);
            this.groupBox1.Controls.Add(this.Serial_OpenBtn);
            this.groupBox1.Controls.Add(this.Parity_Bit);
            this.groupBox1.Controls.Add(this.Stop_Bit);
            this.groupBox1.Controls.Add(this.Data_Bit);
            this.groupBox1.Controls.Add(this.Buad_Rate);
            this.groupBox1.Controls.Add(this.Serial_Port);
            this.groupBox1.Controls.Add(this.comboPortBaudRate);
            this.groupBox1.Controls.Add(this.comboParity);
            this.groupBox1.Controls.Add(this.comboPortName);
            this.groupBox1.Controls.Add(this.comboStopBits);
            this.groupBox1.Controls.Add(this.comboDataBits);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 362);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(331, 428);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "RTU Slave/Settings";
            // 
            // Save_Rtu_Btn
            // 
            this.Save_Rtu_Btn.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Save_Rtu_Btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Save_Rtu_Btn.Location = new System.Drawing.Point(29, 367);
            this.Save_Rtu_Btn.Name = "Save_Rtu_Btn";
            this.Save_Rtu_Btn.Size = new System.Drawing.Size(102, 36);
            this.Save_Rtu_Btn.TabIndex = 38;
            this.Save_Rtu_Btn.Text = "Save_Rtu";
            this.Save_Rtu_Btn.UseVisualStyleBackColor = false;
            this.Save_Rtu_Btn.Click += new System.EventHandler(this.Save_Rtu_Btn_Click);
            // 
            // Clean_Rtu
            // 
            this.Clean_Rtu.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Clean_Rtu.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Clean_Rtu.Location = new System.Drawing.Point(150, 367);
            this.Clean_Rtu.Margin = new System.Windows.Forms.Padding(4);
            this.Clean_Rtu.Name = "Clean_Rtu";
            this.Clean_Rtu.Size = new System.Drawing.Size(158, 38);
            this.Clean_Rtu.TabIndex = 37;
            this.Clean_Rtu.Text = "Clean_Rtu";
            this.Clean_Rtu.UseVisualStyleBackColor = false;
            this.Clean_Rtu.Click += new System.EventHandler(this.Clean_Rtu_Click);
            // 
            // RTU_label
            // 
            this.RTU_label.AutoSize = true;
            this.RTU_label.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTU_label.Location = new System.Drawing.Point(25, 318);
            this.RTU_label.Name = "RTU_label";
            this.RTU_label.Size = new System.Drawing.Size(41, 23);
            this.RTU_label.TabIndex = 36;
            this.RTU_label.Text = "RTU";
            // 
            // Serial_OpenBtn
            // 
            this.Serial_OpenBtn.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Serial_OpenBtn.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Serial_OpenBtn.Location = new System.Drawing.Point(150, 313);
            this.Serial_OpenBtn.Margin = new System.Windows.Forms.Padding(4);
            this.Serial_OpenBtn.Name = "Serial_OpenBtn";
            this.Serial_OpenBtn.Size = new System.Drawing.Size(158, 38);
            this.Serial_OpenBtn.TabIndex = 13;
            this.Serial_OpenBtn.Text = "Open Serial";
            this.Serial_OpenBtn.UseVisualStyleBackColor = false;
            this.Serial_OpenBtn.Click += new System.EventHandler(this.Serial_OpenBtn_Click);
            // 
            // Parity_Bit
            // 
            this.Parity_Bit.AutoSize = true;
            this.Parity_Bit.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Parity_Bit.Location = new System.Drawing.Point(25, 265);
            this.Parity_Bit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Parity_Bit.Name = "Parity_Bit";
            this.Parity_Bit.Size = new System.Drawing.Size(79, 23);
            this.Parity_Bit.TabIndex = 8;
            this.Parity_Bit.Text = "Parity Bit";
            // 
            // Stop_Bit
            // 
            this.Stop_Bit.AutoSize = true;
            this.Stop_Bit.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stop_Bit.Location = new System.Drawing.Point(25, 210);
            this.Stop_Bit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Stop_Bit.Name = "Stop_Bit";
            this.Stop_Bit.Size = new System.Drawing.Size(69, 23);
            this.Stop_Bit.TabIndex = 9;
            this.Stop_Bit.Text = "Stop Bit";
            // 
            // Data_Bit
            // 
            this.Data_Bit.AutoSize = true;
            this.Data_Bit.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Data_Bit.Location = new System.Drawing.Point(25, 155);
            this.Data_Bit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Data_Bit.Name = "Data_Bit";
            this.Data_Bit.Size = new System.Drawing.Size(70, 23);
            this.Data_Bit.TabIndex = 10;
            this.Data_Bit.Text = "Data Bit";
            // 
            // Buad_Rate
            // 
            this.Buad_Rate.AutoSize = true;
            this.Buad_Rate.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buad_Rate.Location = new System.Drawing.Point(25, 100);
            this.Buad_Rate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Buad_Rate.Name = "Buad_Rate";
            this.Buad_Rate.Size = new System.Drawing.Size(87, 23);
            this.Buad_Rate.TabIndex = 11;
            this.Buad_Rate.Text = "Buad Rate";
            // 
            // Serial_Port
            // 
            this.Serial_Port.AutoSize = true;
            this.Serial_Port.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Serial_Port.Location = new System.Drawing.Point(25, 45);
            this.Serial_Port.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Serial_Port.Name = "Serial_Port";
            this.Serial_Port.Size = new System.Drawing.Size(89, 23);
            this.Serial_Port.TabIndex = 12;
            this.Serial_Port.Text = "Serial Port";
            // 
            // comboPortBaudRate
            // 
            this.comboPortBaudRate.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboPortBaudRate.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPortBaudRate.FormattingEnabled = true;
            this.comboPortBaudRate.Location = new System.Drawing.Point(150, 95);
            this.comboPortBaudRate.Margin = new System.Windows.Forms.Padding(4);
            this.comboPortBaudRate.Name = "comboPortBaudRate";
            this.comboPortBaudRate.Size = new System.Drawing.Size(160, 30);
            this.comboPortBaudRate.TabIndex = 3;
            // 
            // comboParity
            // 
            this.comboParity.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboParity.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboParity.FormattingEnabled = true;
            this.comboParity.Location = new System.Drawing.Point(150, 260);
            this.comboParity.Margin = new System.Windows.Forms.Padding(4);
            this.comboParity.Name = "comboParity";
            this.comboParity.Size = new System.Drawing.Size(160, 30);
            this.comboParity.TabIndex = 4;
            // 
            // comboPortName
            // 
            this.comboPortName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboPortName.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPortName.FormattingEnabled = true;
            this.comboPortName.Location = new System.Drawing.Point(150, 40);
            this.comboPortName.Margin = new System.Windows.Forms.Padding(4);
            this.comboPortName.Name = "comboPortName";
            this.comboPortName.Size = new System.Drawing.Size(160, 30);
            this.comboPortName.TabIndex = 5;
            // 
            // comboStopBits
            // 
            this.comboStopBits.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboStopBits.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStopBits.FormattingEnabled = true;
            this.comboStopBits.Location = new System.Drawing.Point(150, 205);
            this.comboStopBits.Margin = new System.Windows.Forms.Padding(4);
            this.comboStopBits.Name = "comboStopBits";
            this.comboStopBits.Size = new System.Drawing.Size(160, 30);
            this.comboStopBits.TabIndex = 6;
            // 
            // comboDataBits
            // 
            this.comboDataBits.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboDataBits.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDataBits.FormattingEnabled = true;
            this.comboDataBits.Location = new System.Drawing.Point(150, 150);
            this.comboDataBits.Margin = new System.Windows.Forms.Padding(4);
            this.comboDataBits.Name = "comboDataBits";
            this.comboDataBits.Size = new System.Drawing.Size(160, 30);
            this.comboDataBits.TabIndex = 7;
            // 
            // RecvRichTextBox
            // 
            this.RecvRichTextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.RecvRichTextBox.Location = new System.Drawing.Point(6, 149);
            this.RecvRichTextBox.Name = "RecvRichTextBox";
            this.RecvRichTextBox.ReadOnly = true;
            this.RecvRichTextBox.Size = new System.Drawing.Size(580, 190);
            this.RecvRichTextBox.TabIndex = 41;
            this.RecvRichTextBox.Text = "";
            // 
            // SerialRecv_TextBox
            // 
            this.SerialRecv_TextBox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.SerialRecv_TextBox.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SerialRecv_TextBox.Location = new System.Drawing.Point(6, 95);
            this.SerialRecv_TextBox.Name = "SerialRecv_TextBox";
            this.SerialRecv_TextBox.ReadOnly = true;
            this.SerialRecv_TextBox.Size = new System.Drawing.Size(580, 325);
            this.SerialRecv_TextBox.TabIndex = 42;
            this.SerialRecv_TextBox.Text = "";
            // 
            // Tcp_Send
            // 
            this.Tcp_Send.Controls.Add(this.DataFrame);
            this.Tcp_Send.Controls.Add(this.RecvRichTextBox);
            this.Tcp_Send.Controls.Add(this.Create_Tcp);
            this.Tcp_Send.Controls.Add(this.UnitID);
            this.Tcp_Send.Controls.Add(this.Amount_Tcp);
            this.Tcp_Send.Controls.Add(this.Func_Code);
            this.Tcp_Send.Controls.Add(this.Tcp_Sendbtn);
            this.Tcp_Send.Controls.Add(this.label1);
            this.Tcp_Send.Controls.Add(this.Addr_Tcp);
            this.Tcp_Send.Controls.Add(this.Counter_Tcp);
            this.Tcp_Send.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tcp_Send.Location = new System.Drawing.Point(365, 3);
            this.Tcp_Send.Name = "Tcp_Send";
            this.Tcp_Send.Size = new System.Drawing.Size(593, 351);
            this.Tcp_Send.TabIndex = 43;
            this.Tcp_Send.TabStop = false;
            this.Tcp_Send.Text = "Tcp_Send";
            // 
            // DataFrame
            // 
            this.DataFrame.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.DataFrame.Location = new System.Drawing.Point(7, 94);
            this.DataFrame.Name = "DataFrame";
            this.DataFrame.Size = new System.Drawing.Size(580, 49);
            this.DataFrame.TabIndex = 44;
            this.DataFrame.Text = "";
            // 
            // Create_Tcp
            // 
            this.Create_Tcp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Create_Tcp.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create_Tcp.Location = new System.Drawing.Point(502, 17);
            this.Create_Tcp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Create_Tcp.Name = "Create_Tcp";
            this.Create_Tcp.Size = new System.Drawing.Size(84, 31);
            this.Create_Tcp.TabIndex = 43;
            this.Create_Tcp.Text = "Create";
            this.Create_Tcp.UseVisualStyleBackColor = false;
            this.Create_Tcp.Click += new System.EventHandler(this.Create_Tcp_Click);
            // 
            // UnitID
            // 
            this.UnitID.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.UnitID.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnitID.Location = new System.Drawing.Point(112, 57);
            this.UnitID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.UnitID.Name = "UnitID";
            this.UnitID.Size = new System.Drawing.Size(60, 29);
            this.UnitID.TabIndex = 42;
            this.UnitID.Text = "0";
            this.UnitID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Amount_Tcp
            // 
            this.Amount_Tcp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Amount_Tcp.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amount_Tcp.Location = new System.Drawing.Point(412, 57);
            this.Amount_Tcp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Amount_Tcp.Name = "Amount_Tcp";
            this.Amount_Tcp.Size = new System.Drawing.Size(60, 29);
            this.Amount_Tcp.TabIndex = 41;
            this.Amount_Tcp.Text = "0";
            this.Amount_Tcp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Func_Code
            // 
            this.Func_Code.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Func_Code.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Func_Code.FormattingEnabled = true;
            this.Func_Code.Items.AddRange(new object[] {
            "01",
            "03",
            "0F",
            "10"});
            this.Func_Code.Location = new System.Drawing.Point(211, 57);
            this.Func_Code.Margin = new System.Windows.Forms.Padding(4);
            this.Func_Code.Name = "Func_Code";
            this.Func_Code.Size = new System.Drawing.Size(85, 30);
            this.Func_Code.TabIndex = 40;
            this.Func_Code.Text = "Select";
            // 
            // Tcp_Sendbtn
            // 
            this.Tcp_Sendbtn.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Tcp_Sendbtn.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tcp_Sendbtn.Location = new System.Drawing.Point(502, 54);
            this.Tcp_Sendbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tcp_Sendbtn.Name = "Tcp_Sendbtn";
            this.Tcp_Sendbtn.Size = new System.Drawing.Size(84, 31);
            this.Tcp_Sendbtn.TabIndex = 39;
            this.Tcp_Sendbtn.Text = "Send";
            this.Tcp_Sendbtn.UseVisualStyleBackColor = false;
            this.Tcp_Sendbtn.Click += new System.EventHandler(this.Tcp_Sendbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 23);
            this.label1.TabIndex = 38;
            this.label1.Text = "Trans             SlaveID            Func                  Addr               Amt" +
    "";
            // 
            // Addr_Tcp
            // 
            this.Addr_Tcp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Addr_Tcp.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addr_Tcp.Location = new System.Drawing.Point(319, 57);
            this.Addr_Tcp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Addr_Tcp.Name = "Addr_Tcp";
            this.Addr_Tcp.Size = new System.Drawing.Size(60, 29);
            this.Addr_Tcp.TabIndex = 37;
            this.Addr_Tcp.Text = "0";
            this.Addr_Tcp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Counter_Tcp
            // 
            this.Counter_Tcp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Counter_Tcp.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Counter_Tcp.Location = new System.Drawing.Point(15, 57);
            this.Counter_Tcp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Counter_Tcp.Name = "Counter_Tcp";
            this.Counter_Tcp.ReadOnly = true;
            this.Counter_Tcp.Size = new System.Drawing.Size(60, 29);
            this.Counter_Tcp.TabIndex = 33;
            this.Counter_Tcp.Text = "0";
            this.Counter_Tcp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Recv_Timer
            // 
            this.Recv_Timer.Tick += new System.EventHandler(this.Recv_Timer_Tick);
            // 
            // Rtu_Recv
            // 
            this.Rtu_Recv.Controls.Add(this.SlaveID_Rtu_Label);
            this.Rtu_Recv.Controls.Add(this.SlaveID_Rtu);
            this.Rtu_Recv.Controls.Add(this.label5);
            this.Rtu_Recv.Controls.Add(this.label4);
            this.Rtu_Recv.Controls.Add(this.label3);
            this.Rtu_Recv.Controls.Add(this.Create_Rtu);
            this.Rtu_Recv.Controls.Add(this.Amount_Rtu);
            this.Rtu_Recv.Controls.Add(this.Addr_Rtu);
            this.Rtu_Recv.Controls.Add(this.Func_Code_Rtu);
            this.Rtu_Recv.Controls.Add(this.SerialRecv_TextBox);
            this.Rtu_Recv.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rtu_Recv.Location = new System.Drawing.Point(365, 362);
            this.Rtu_Recv.Name = "Rtu_Recv";
            this.Rtu_Recv.Size = new System.Drawing.Size(593, 428);
            this.Rtu_Recv.TabIndex = 45;
            this.Rtu_Recv.TabStop = false;
            this.Rtu_Recv.Text = "Rtu_Recv";
            // 
            // SlaveID_Rtu_Label
            // 
            this.SlaveID_Rtu_Label.AutoSize = true;
            this.SlaveID_Rtu_Label.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlaveID_Rtu_Label.Location = new System.Drawing.Point(15, 27);
            this.SlaveID_Rtu_Label.Name = "SlaveID_Rtu_Label";
            this.SlaveID_Rtu_Label.Size = new System.Drawing.Size(70, 24);
            this.SlaveID_Rtu_Label.TabIndex = 51;
            this.SlaveID_Rtu_Label.Text = "SlaveID";
            // 
            // SlaveID_Rtu
            // 
            this.SlaveID_Rtu.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.SlaveID_Rtu.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlaveID_Rtu.Location = new System.Drawing.Point(14, 55);
            this.SlaveID_Rtu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SlaveID_Rtu.Name = "SlaveID_Rtu";
            this.SlaveID_Rtu.Size = new System.Drawing.Size(68, 29);
            this.SlaveID_Rtu.TabIndex = 50;
            this.SlaveID_Rtu.Text = "0";
            this.SlaveID_Rtu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(387, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 24);
            this.label5.TabIndex = 49;
            this.label5.Text = "Amt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(269, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 24);
            this.label4.TabIndex = 48;
            this.label4.Text = "Addr";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(128, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 24);
            this.label3.TabIndex = 47;
            this.label3.Text = "Func";
            // 
            // Create_Rtu
            // 
            this.Create_Rtu.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Create_Rtu.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create_Rtu.Location = new System.Drawing.Point(501, 50);
            this.Create_Rtu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Create_Rtu.Name = "Create_Rtu";
            this.Create_Rtu.Size = new System.Drawing.Size(84, 35);
            this.Create_Rtu.TabIndex = 45;
            this.Create_Rtu.Text = "Create";
            this.Create_Rtu.UseVisualStyleBackColor = false;
            this.Create_Rtu.Click += new System.EventHandler(this.Create_Rtu_Click);
            // 
            // Amount_Rtu
            // 
            this.Amount_Rtu.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Amount_Rtu.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amount_Rtu.Location = new System.Drawing.Point(378, 55);
            this.Amount_Rtu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Amount_Rtu.Name = "Amount_Rtu";
            this.Amount_Rtu.Size = new System.Drawing.Size(72, 29);
            this.Amount_Rtu.TabIndex = 45;
            this.Amount_Rtu.Text = "0";
            this.Amount_Rtu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Addr_Rtu
            // 
            this.Addr_Rtu.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Addr_Rtu.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addr_Rtu.Location = new System.Drawing.Point(267, 55);
            this.Addr_Rtu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Addr_Rtu.Name = "Addr_Rtu";
            this.Addr_Rtu.Size = new System.Drawing.Size(68, 29);
            this.Addr_Rtu.TabIndex = 45;
            this.Addr_Rtu.Text = "0";
            this.Addr_Rtu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Func_Code_Rtu
            // 
            this.Func_Code_Rtu.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Func_Code_Rtu.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Func_Code_Rtu.FormattingEnabled = true;
            this.Func_Code_Rtu.Items.AddRange(new object[] {
            "Coil",
            "Register"});
            this.Func_Code_Rtu.Location = new System.Drawing.Point(125, 53);
            this.Func_Code_Rtu.Margin = new System.Windows.Forms.Padding(4);
            this.Func_Code_Rtu.Name = "Func_Code_Rtu";
            this.Func_Code_Rtu.Size = new System.Drawing.Size(97, 30);
            this.Func_Code_Rtu.TabIndex = 46;
            this.Func_Code_Rtu.Text = "Select";
            // 
            // Modbus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(970, 794);
            this.Controls.Add(this.Rtu_Recv);
            this.Controls.Add(this.Tcp_Send);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Modbus";
            this.Text = "Modbus";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Modbus_FormClosing);
            this.Load += new System.EventHandler(this.Modbus_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Tcp_Send.ResumeLayout(false);
            this.Tcp_Send.PerformLayout();
            this.Rtu_Recv.ResumeLayout(false);
            this.Rtu_Recv.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label 当前连接;
        private System.Windows.Forms.Label Remote_Port;
        private System.Windows.Forms.Label TCP;
        private System.Windows.Forms.Button TCP_Startbtn;
        private System.Windows.Forms.Label Ip_Address;
        private System.Windows.Forms.TextBox tcpListenPortTextBox;
        private System.Windows.Forms.TextBox myIPtextBox;
        private System.Windows.Forms.Label Connection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label Parity_Bit;
        private System.Windows.Forms.Label Stop_Bit;
        private System.Windows.Forms.Label Data_Bit;
        private System.Windows.Forms.Label Buad_Rate;
        private System.Windows.Forms.Label Serial_Port;
        private System.Windows.Forms.RichTextBox RecvRichTextBox;
        private System.Windows.Forms.RichTextBox SerialRecv_TextBox;
        private System.Windows.Forms.Label RTU_label;
        private System.Windows.Forms.GroupBox Tcp_Send;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Counter_Tcp;
        public System.Windows.Forms.TextBox Addr_Tcp;
        public System.Windows.Forms.TextBox Amount_Tcp;
        public System.Windows.Forms.TextBox UnitID;
        public System.Windows.Forms.Button Tcp_Sendbtn;
        public System.Windows.Forms.ComboBox Func_Code;
        public System.Windows.Forms.Button Create_Tcp;
        public System.Windows.Forms.RichTextBox DataFrame;
        private System.Windows.Forms.Timer Recv_Timer;
        private System.Windows.Forms.TextBox Time_Out_Textbox;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button Serial_OpenBtn;
        public System.Windows.Forms.ComboBox comboPortBaudRate;
        public System.Windows.Forms.ComboBox comboParity;
        public System.Windows.Forms.ComboBox comboStopBits;
        public System.Windows.Forms.ComboBox comboDataBits;
        private System.Windows.Forms.GroupBox Rtu_Recv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button Create_Rtu;
        public System.Windows.Forms.TextBox Amount_Rtu;
        public System.Windows.Forms.TextBox Addr_Rtu;
        public System.Windows.Forms.ComboBox Func_Code_Rtu;
        private System.Windows.Forms.Button Clean_Tcp;
        public System.Windows.Forms.Button Clean_Rtu;
        private System.Windows.Forms.Label SlaveID_Rtu_Label;
        public System.Windows.Forms.TextBox SlaveID_Rtu;
        private System.Windows.Forms.Button Save_Tcp_Btn;
        private System.Windows.Forms.Button Save_Rtu_Btn;
        private System.Windows.Forms.ComboBox comboPortName;
    }
}