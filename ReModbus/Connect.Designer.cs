namespace ReModbus
{
    partial class Connect
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
            this.grpBoxConnectSettings = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtBoxTimeOut = new System.Windows.Forms.TextBox();
            this.labTimeOut = new System.Windows.Forms.Label();
            this.labPort = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.labIp = new System.Windows.Forms.Label();
            this.txtBoxPort = new System.Windows.Forms.TextBox();
            this.txtBoxIp = new System.Windows.Forms.TextBox();
            this.grpBoxConnectSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxConnectSettings
            // 
            this.grpBoxConnectSettings.Controls.Add(this.btnDisconnect);
            this.grpBoxConnectSettings.Controls.Add(this.txtBoxTimeOut);
            this.grpBoxConnectSettings.Controls.Add(this.labTimeOut);
            this.grpBoxConnectSettings.Controls.Add(this.labPort);
            this.grpBoxConnectSettings.Controls.Add(this.btnConnect);
            this.grpBoxConnectSettings.Controls.Add(this.labIp);
            this.grpBoxConnectSettings.Controls.Add(this.txtBoxPort);
            this.grpBoxConnectSettings.Controls.Add(this.txtBoxIp);
            this.grpBoxConnectSettings.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.grpBoxConnectSettings.Location = new System.Drawing.Point(13, 14);
            this.grpBoxConnectSettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBoxConnectSettings.Name = "grpBoxConnectSettings";
            this.grpBoxConnectSettings.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpBoxConnectSettings.Size = new System.Drawing.Size(345, 304);
            this.grpBoxConnectSettings.TabIndex = 41;
            this.grpBoxConnectSettings.TabStop = false;
            this.grpBoxConnectSettings.Text = "Tcp Master/Settings";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDisconnect.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.btnDisconnect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnDisconnect.Location = new System.Drawing.Point(169, 240);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(140, 35);
            this.btnDisconnect.TabIndex = 39;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // txtBoxTimeOut
            // 
            this.txtBoxTimeOut.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtBoxTimeOut.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.txtBoxTimeOut.Location = new System.Drawing.Point(169, 180);
            this.txtBoxTimeOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxTimeOut.Name = "txtBoxTimeOut";
            this.txtBoxTimeOut.Size = new System.Drawing.Size(140, 29);
            this.txtBoxTimeOut.TabIndex = 37;
            this.txtBoxTimeOut.Text = "1000";
            // 
            // labTimeOut
            // 
            this.labTimeOut.AutoSize = true;
            this.labTimeOut.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.labTimeOut.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labTimeOut.Location = new System.Drawing.Point(27, 186);
            this.labTimeOut.Name = "labTimeOut";
            this.labTimeOut.Size = new System.Drawing.Size(119, 23);
            this.labTimeOut.TabIndex = 36;
            this.labTimeOut.Text = "Time Out (ms)";
            // 
            // labPort
            // 
            this.labPort.AutoSize = true;
            this.labPort.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.labPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labPort.Location = new System.Drawing.Point(27, 120);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(106, 23);
            this.labPort.TabIndex = 28;
            this.labPort.Text = "Remote Port";
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnConnect.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.btnConnect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConnect.Location = new System.Drawing.Point(26, 240);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(135, 35);
            this.btnConnect.TabIndex = 34;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // labIp
            // 
            this.labIp.AutoSize = true;
            this.labIp.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.labIp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labIp.Location = new System.Drawing.Point(27, 60);
            this.labIp.Name = "labIp";
            this.labIp.Size = new System.Drawing.Size(93, 23);
            this.labIp.TabIndex = 1;
            this.labIp.Text = "Ip Address";
            // 
            // txtBoxPort
            // 
            this.txtBoxPort.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtBoxPort.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.txtBoxPort.Location = new System.Drawing.Point(169, 114);
            this.txtBoxPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxPort.Name = "txtBoxPort";
            this.txtBoxPort.Size = new System.Drawing.Size(140, 29);
            this.txtBoxPort.TabIndex = 32;
            this.txtBoxPort.Text = "502";
            // 
            // txtBoxIp
            // 
            this.txtBoxIp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtBoxIp.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.txtBoxIp.Location = new System.Drawing.Point(169, 54);
            this.txtBoxIp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxIp.Name = "txtBoxIp";
            this.txtBoxIp.Size = new System.Drawing.Size(140, 29);
            this.txtBoxIp.TabIndex = 32;
            this.txtBoxIp.Text = "127.0.0.1";
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(370, 327);
            this.Controls.Add(this.grpBoxConnectSettings);
            this.MaximizeBox = false;
            this.Name = "Connect";
            this.Text = "Connect";
            this.grpBoxConnectSettings.ResumeLayout(false);
            this.grpBoxConnectSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxConnectSettings;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtBoxTimeOut;
        private System.Windows.Forms.Label labTimeOut;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label labIp;
        private System.Windows.Forms.TextBox txtBoxPort;
        private System.Windows.Forms.TextBox txtBoxIp;
    }
}