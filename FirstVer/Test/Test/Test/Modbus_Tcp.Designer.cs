namespace Modbus_Tcp
{
    partial class Modbus_Tcp
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Btn_Send_Tcp = new System.Windows.Forms.GroupBox();
            this.Txt_DataFrame = new System.Windows.Forms.RichTextBox();
            this.Txt_Recv = new System.Windows.Forms.RichTextBox();
            this.Btn_Create_Tcp = new System.Windows.Forms.Button();
            this.Txt_UnitID = new System.Windows.Forms.TextBox();
            this.Txt_Amount_Tcp = new System.Windows.Forms.TextBox();
            this.Cbo_Func_Code = new System.Windows.Forms.ComboBox();
            this.Btn_Send = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Addr_Tcp = new System.Windows.Forms.TextBox();
            this.Txt_Counter_Tcp = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Btn_Savelog_Tcp = new System.Windows.Forms.Button();
            this.Btn_Clean_Tcp = new System.Windows.Forms.Button();
            this.txt_Time_Out = new System.Windows.Forms.TextBox();
            this.Lab_Time_Out = new System.Windows.Forms.Label();
            this.Lab_Statu = new System.Windows.Forms.Label();
            this.Lab_Remote_Port = new System.Windows.Forms.Label();
            this.Lab_TCP = new System.Windows.Forms.Label();
            this.Btn_Start_Tcp = new System.Windows.Forms.Button();
            this.Lab_Ip_Address = new System.Windows.Forms.Label();
            this.txt_TcpPort = new System.Windows.Forms.TextBox();
            this.txt_RemoteIP = new System.Windows.Forms.TextBox();
            this.Connection = new System.Windows.Forms.Label();
            this.Timer_Recv = new System.Windows.Forms.Timer(this.components);
            this.Timer_ScanStatus = new System.Windows.Forms.Timer(this.components);
            this.Btn_Send_Tcp.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Send_Tcp
            // 
            this.Btn_Send_Tcp.Controls.Add(this.Txt_DataFrame);
            this.Btn_Send_Tcp.Controls.Add(this.Txt_Recv);
            this.Btn_Send_Tcp.Controls.Add(this.Btn_Create_Tcp);
            this.Btn_Send_Tcp.Controls.Add(this.Txt_UnitID);
            this.Btn_Send_Tcp.Controls.Add(this.Txt_Amount_Tcp);
            this.Btn_Send_Tcp.Controls.Add(this.Cbo_Func_Code);
            this.Btn_Send_Tcp.Controls.Add(this.Btn_Send);
            this.Btn_Send_Tcp.Controls.Add(this.label1);
            this.Btn_Send_Tcp.Controls.Add(this.Txt_Addr_Tcp);
            this.Btn_Send_Tcp.Controls.Add(this.Txt_Counter_Tcp);
            this.Btn_Send_Tcp.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Send_Tcp.Location = new System.Drawing.Point(360, 12);
            this.Btn_Send_Tcp.Name = "Btn_Send_Tcp";
            this.Btn_Send_Tcp.Size = new System.Drawing.Size(641, 479);
            this.Btn_Send_Tcp.TabIndex = 45;
            this.Btn_Send_Tcp.TabStop = false;
            this.Btn_Send_Tcp.Text = "Tcp_Send";
            // 
            // Txt_DataFrame
            // 
            this.Txt_DataFrame.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Txt_DataFrame.Location = new System.Drawing.Point(7, 94);
            this.Txt_DataFrame.Name = "Txt_DataFrame";
            this.Txt_DataFrame.Size = new System.Drawing.Size(628, 49);
            this.Txt_DataFrame.TabIndex = 44;
            this.Txt_DataFrame.Text = "";
            // 
            // Txt_Recv
            // 
            this.Txt_Recv.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Txt_Recv.Location = new System.Drawing.Point(6, 149);
            this.Txt_Recv.Name = "Txt_Recv";
            this.Txt_Recv.ReadOnly = true;
            this.Txt_Recv.Size = new System.Drawing.Size(629, 322);
            this.Txt_Recv.TabIndex = 41;
            this.Txt_Recv.Text = "";
            // 
            // Btn_Create_Tcp
            // 
            this.Btn_Create_Tcp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Btn_Create_Tcp.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Create_Tcp.Location = new System.Drawing.Point(544, 17);
            this.Btn_Create_Tcp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Create_Tcp.Name = "Btn_Create_Tcp";
            this.Btn_Create_Tcp.Size = new System.Drawing.Size(84, 31);
            this.Btn_Create_Tcp.TabIndex = 43;
            this.Btn_Create_Tcp.Text = "Create";
            this.Btn_Create_Tcp.UseVisualStyleBackColor = false;
            this.Btn_Create_Tcp.Click += new System.EventHandler(this.Btn_Create_Tcp_Click);
            // 
            // Txt_UnitID
            // 
            this.Txt_UnitID.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Txt_UnitID.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_UnitID.Location = new System.Drawing.Point(112, 57);
            this.Txt_UnitID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_UnitID.Name = "Txt_UnitID";
            this.Txt_UnitID.Size = new System.Drawing.Size(60, 29);
            this.Txt_UnitID.TabIndex = 42;
            this.Txt_UnitID.Text = "0";
            this.Txt_UnitID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_Amount_Tcp
            // 
            this.Txt_Amount_Tcp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Txt_Amount_Tcp.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Amount_Tcp.Location = new System.Drawing.Point(440, 57);
            this.Txt_Amount_Tcp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_Amount_Tcp.Name = "Txt_Amount_Tcp";
            this.Txt_Amount_Tcp.Size = new System.Drawing.Size(60, 29);
            this.Txt_Amount_Tcp.TabIndex = 41;
            this.Txt_Amount_Tcp.Text = "0";
            this.Txt_Amount_Tcp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Cbo_Func_Code
            // 
            this.Cbo_Func_Code.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Cbo_Func_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbo_Func_Code.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbo_Func_Code.FormattingEnabled = true;
            this.Cbo_Func_Code.Items.AddRange(new object[] {
            "01",
            "03",
            "0F",
            "10"});
            this.Cbo_Func_Code.Location = new System.Drawing.Point(211, 57);
            this.Cbo_Func_Code.Margin = new System.Windows.Forms.Padding(4);
            this.Cbo_Func_Code.Name = "Cbo_Func_Code";
            this.Cbo_Func_Code.Size = new System.Drawing.Size(85, 30);
            this.Cbo_Func_Code.TabIndex = 40;
            // 
            // Btn_Send
            // 
            this.Btn_Send.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Btn_Send.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Send.Location = new System.Drawing.Point(544, 54);
            this.Btn_Send.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Send.Name = "Btn_Send";
            this.Btn_Send.Size = new System.Drawing.Size(84, 31);
            this.Btn_Send.TabIndex = 39;
            this.Btn_Send.Text = "Send";
            this.Btn_Send.UseVisualStyleBackColor = false;
            this.Btn_Send.Click += new System.EventHandler(this.Btn_Send_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 23);
            this.label1.TabIndex = 38;
            this.label1.Text = "Trans             SlaveID            Func                     Addr               " +
    "   Amt";
            // 
            // Txt_Addr_Tcp
            // 
            this.Txt_Addr_Tcp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Txt_Addr_Tcp.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Addr_Tcp.Location = new System.Drawing.Point(334, 57);
            this.Txt_Addr_Tcp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_Addr_Tcp.Name = "Txt_Addr_Tcp";
            this.Txt_Addr_Tcp.Size = new System.Drawing.Size(60, 29);
            this.Txt_Addr_Tcp.TabIndex = 37;
            this.Txt_Addr_Tcp.Text = "0";
            this.Txt_Addr_Tcp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Txt_Counter_Tcp
            // 
            this.Txt_Counter_Tcp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Txt_Counter_Tcp.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Counter_Tcp.Location = new System.Drawing.Point(9, 57);
            this.Txt_Counter_Tcp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Txt_Counter_Tcp.Name = "Txt_Counter_Tcp";
            this.Txt_Counter_Tcp.ReadOnly = true;
            this.Txt_Counter_Tcp.Size = new System.Drawing.Size(60, 29);
            this.Txt_Counter_Tcp.TabIndex = 33;
            this.Txt_Counter_Tcp.Text = "0";
            this.Txt_Counter_Tcp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Btn_Savelog_Tcp);
            this.groupBox3.Controls.Add(this.Btn_Clean_Tcp);
            this.groupBox3.Controls.Add(this.txt_Time_Out);
            this.groupBox3.Controls.Add(this.Lab_Time_Out);
            this.groupBox3.Controls.Add(this.Lab_Statu);
            this.groupBox3.Controls.Add(this.Lab_Remote_Port);
            this.groupBox3.Controls.Add(this.Lab_TCP);
            this.groupBox3.Controls.Add(this.Btn_Start_Tcp);
            this.groupBox3.Controls.Add(this.Lab_Ip_Address);
            this.groupBox3.Controls.Add(this.txt_TcpPort);
            this.groupBox3.Controls.Add(this.txt_RemoteIP);
            this.groupBox3.Controls.Add(this.Connection);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 12);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(331, 479);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TCP Master/Settings";
            // 
            // Btn_Savelog_Tcp
            // 
            this.Btn_Savelog_Tcp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Btn_Savelog_Tcp.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Savelog_Tcp.Location = new System.Drawing.Point(29, 421);
            this.Btn_Savelog_Tcp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Savelog_Tcp.Name = "Btn_Savelog_Tcp";
            this.Btn_Savelog_Tcp.Size = new System.Drawing.Size(102, 36);
            this.Btn_Savelog_Tcp.TabIndex = 39;
            this.Btn_Savelog_Tcp.Text = "Save_Tcp";
            this.Btn_Savelog_Tcp.UseVisualStyleBackColor = false;
            // 
            // Btn_Clean_Tcp
            // 
            this.Btn_Clean_Tcp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Btn_Clean_Tcp.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Clean_Tcp.Location = new System.Drawing.Point(153, 421);
            this.Btn_Clean_Tcp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Clean_Tcp.Name = "Btn_Clean_Tcp";
            this.Btn_Clean_Tcp.Size = new System.Drawing.Size(152, 36);
            this.Btn_Clean_Tcp.TabIndex = 38;
            this.Btn_Clean_Tcp.Text = "Clean_Tcp";
            this.Btn_Clean_Tcp.UseVisualStyleBackColor = false;
            this.Btn_Clean_Tcp.Click += new System.EventHandler(this.Btn_Clean_Tcp_Click);
            // 
            // txt_Time_Out
            // 
            this.txt_Time_Out.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_Time_Out.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Time_Out.Location = new System.Drawing.Point(153, 343);
            this.txt_Time_Out.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Time_Out.Name = "txt_Time_Out";
            this.txt_Time_Out.Size = new System.Drawing.Size(152, 29);
            this.txt_Time_Out.TabIndex = 37;
            this.txt_Time_Out.Text = "1000";
            // 
            // Lab_Time_Out
            // 
            this.Lab_Time_Out.AutoSize = true;
            this.Lab_Time_Out.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Time_Out.Location = new System.Drawing.Point(25, 348);
            this.Lab_Time_Out.Name = "Lab_Time_Out";
            this.Lab_Time_Out.Size = new System.Drawing.Size(119, 23);
            this.Lab_Time_Out.TabIndex = 36;
            this.Lab_Time_Out.Text = "Time Out (ms)";
            // 
            // Lab_Statu
            // 
            this.Lab_Statu.AutoSize = true;
            this.Lab_Statu.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Statu.Location = new System.Drawing.Point(25, 42);
            this.Lab_Statu.Name = "Lab_Statu";
            this.Lab_Statu.Size = new System.Drawing.Size(58, 23);
            this.Lab_Statu.TabIndex = 0;
            this.Lab_Statu.Text = "Status";
            // 
            // Lab_Remote_Port
            // 
            this.Lab_Remote_Port.AutoSize = true;
            this.Lab_Remote_Port.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Remote_Port.Location = new System.Drawing.Point(25, 270);
            this.Lab_Remote_Port.Name = "Lab_Remote_Port";
            this.Lab_Remote_Port.Size = new System.Drawing.Size(106, 23);
            this.Lab_Remote_Port.TabIndex = 28;
            this.Lab_Remote_Port.Text = "Remote Port";
            // 
            // Lab_TCP
            // 
            this.Lab_TCP.AutoSize = true;
            this.Lab_TCP.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_TCP.Location = new System.Drawing.Point(25, 116);
            this.Lab_TCP.Name = "Lab_TCP";
            this.Lab_TCP.Size = new System.Drawing.Size(39, 23);
            this.Lab_TCP.TabIndex = 35;
            this.Lab_TCP.Text = "TCP";
            // 
            // Btn_Start_Tcp
            // 
            this.Btn_Start_Tcp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Btn_Start_Tcp.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Start_Tcp.Location = new System.Drawing.Point(153, 108);
            this.Btn_Start_Tcp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_Start_Tcp.Name = "Btn_Start_Tcp";
            this.Btn_Start_Tcp.Size = new System.Drawing.Size(152, 36);
            this.Btn_Start_Tcp.TabIndex = 34;
            this.Btn_Start_Tcp.Text = "Connect";
            this.Btn_Start_Tcp.UseVisualStyleBackColor = false;
            this.Btn_Start_Tcp.Click += new System.EventHandler(this.Btn_Start_Tcp_Click);
            // 
            // Lab_Ip_Address
            // 
            this.Lab_Ip_Address.AutoSize = true;
            this.Lab_Ip_Address.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lab_Ip_Address.Location = new System.Drawing.Point(25, 195);
            this.Lab_Ip_Address.Name = "Lab_Ip_Address";
            this.Lab_Ip_Address.Size = new System.Drawing.Size(93, 23);
            this.Lab_Ip_Address.TabIndex = 1;
            this.Lab_Ip_Address.Text = "Ip Address";
            // 
            // txt_TcpPort
            // 
            this.txt_TcpPort.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_TcpPort.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TcpPort.Location = new System.Drawing.Point(153, 265);
            this.txt_TcpPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_TcpPort.Name = "txt_TcpPort";
            this.txt_TcpPort.Size = new System.Drawing.Size(152, 29);
            this.txt_TcpPort.TabIndex = 32;
            this.txt_TcpPort.Text = "505";
            // 
            // txt_RemoteIP
            // 
            this.txt_RemoteIP.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_RemoteIP.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_RemoteIP.Location = new System.Drawing.Point(153, 190);
            this.txt_RemoteIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_RemoteIP.Name = "txt_RemoteIP";
            this.txt_RemoteIP.Size = new System.Drawing.Size(152, 29);
            this.txt_RemoteIP.TabIndex = 32;
            this.txt_RemoteIP.Text = "127.0.0.1";
            // 
            // Connection
            // 
            this.Connection.AutoSize = true;
            this.Connection.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connection.Location = new System.Drawing.Point(153, 42);
            this.Connection.Name = "Connection";
            this.Connection.Size = new System.Drawing.Size(130, 23);
            this.Connection.TabIndex = 33;
            this.Connection.Text = "No   connection";
            // 
            // Timer_Recv
            // 
            this.Timer_Recv.Interval = 1000;
            this.Timer_Recv.Tick += new System.EventHandler(this.Timer_Recv_Tick);
            // 
            // Timer_ScanStatus
            // 
            this.Timer_ScanStatus.Interval = 1000;
            this.Timer_ScanStatus.Tick += new System.EventHandler(this.Timer_ScanStatus_Tick);
            // 
            // Modbus_Tcp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1001, 495);
            this.Controls.Add(this.Btn_Send_Tcp);
            this.Controls.Add(this.groupBox3);
            this.Name = "Modbus_Tcp";
            this.Text = "Modbus_Tcp";
            this.Btn_Send_Tcp.ResumeLayout(false);
            this.Btn_Send_Tcp.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Btn_Send_Tcp;
        public System.Windows.Forms.RichTextBox Txt_DataFrame;
        public System.Windows.Forms.Button Btn_Create_Tcp;
        public System.Windows.Forms.TextBox Txt_UnitID;
        public System.Windows.Forms.TextBox Txt_Amount_Tcp;
        public System.Windows.Forms.ComboBox Cbo_Func_Code;
        public System.Windows.Forms.Button Btn_Send;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox Txt_Addr_Tcp;
        public System.Windows.Forms.TextBox Txt_Counter_Tcp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Btn_Savelog_Tcp;
        private System.Windows.Forms.Button Btn_Clean_Tcp;
        private System.Windows.Forms.TextBox txt_Time_Out;
        private System.Windows.Forms.Label Lab_Time_Out;
        private System.Windows.Forms.Label Lab_Statu;
        private System.Windows.Forms.Label Lab_Remote_Port;
        private System.Windows.Forms.Label Lab_TCP;
        private System.Windows.Forms.Button Btn_Start_Tcp;
        private System.Windows.Forms.Label Lab_Ip_Address;
        private System.Windows.Forms.TextBox txt_TcpPort;
        private System.Windows.Forms.TextBox txt_RemoteIP;
        private System.Windows.Forms.Label Connection;
        private System.Windows.Forms.RichTextBox Txt_Recv;
        private System.Windows.Forms.Timer Timer_Recv;
        private System.Windows.Forms.Timer Timer_ScanStatus;
    }
}

