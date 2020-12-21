namespace TcpSlave
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownSlaveId = new System.Windows.Forms.NumericUpDown();
            this.labPort = new System.Windows.Forms.Label();
            this.SlaveID = new System.Windows.Forms.Label();
            this.btnCloseServer = new System.Windows.Forms.Button();
            this.txtBoxPort = new System.Windows.Forms.TextBox();
            this.btnOpenServer = new System.Windows.Forms.Button();
            this.grpBoxConnectSettings.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSlaveId)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxConnectSettings
            // 
            this.grpBoxConnectSettings.Controls.Add(this.tableLayoutPanel);
            this.grpBoxConnectSettings.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.grpBoxConnectSettings.Location = new System.Drawing.Point(12, 13);
            this.grpBoxConnectSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpBoxConnectSettings.Name = "grpBoxConnectSettings";
            this.grpBoxConnectSettings.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grpBoxConnectSettings.Size = new System.Drawing.Size(363, 248);
            this.grpBoxConnectSettings.TabIndex = 2;
            this.grpBoxConnectSettings.TabStop = false;
            this.grpBoxConnectSettings.Text = "Tcp Slave/Settings";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.numericUpDownSlaveId, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labPort, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.SlaveID, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.btnCloseServer, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.txtBoxPort, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.btnOpenServer, 0, 2);
            this.tableLayoutPanel.Location = new System.Drawing.Point(16, 52);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 3;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(320, 172);
            this.tableLayoutPanel.TabIndex = 45;
            // 
            // numericUpDownSlaveId
            // 
            this.numericUpDownSlaveId.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.numericUpDownSlaveId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownSlaveId.Location = new System.Drawing.Point(163, 3);
            this.numericUpDownSlaveId.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownSlaveId.Name = "numericUpDownSlaveId";
            this.numericUpDownSlaveId.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.numericUpDownSlaveId.Size = new System.Drawing.Size(154, 29);
            this.numericUpDownSlaveId.TabIndex = 46;
            this.numericUpDownSlaveId.Tag = "";
            this.numericUpDownSlaveId.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labPort
            // 
            this.labPort.AutoSize = true;
            this.labPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labPort.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.labPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.labPort.Location = new System.Drawing.Point(3, 57);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(154, 57);
            this.labPort.TabIndex = 34;
            this.labPort.Text = "Port";
            // 
            // SlaveID
            // 
            this.SlaveID.AutoSize = true;
            this.SlaveID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SlaveID.Location = new System.Drawing.Point(3, 0);
            this.SlaveID.Name = "SlaveID";
            this.SlaveID.Size = new System.Drawing.Size(154, 57);
            this.SlaveID.TabIndex = 44;
            this.SlaveID.Text = "SlaveId";
            // 
            // btnCloseServer
            // 
            this.btnCloseServer.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnCloseServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCloseServer.Enabled = false;
            this.btnCloseServer.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.btnCloseServer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCloseServer.Location = new System.Drawing.Point(163, 116);
            this.btnCloseServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCloseServer.Name = "btnCloseServer";
            this.btnCloseServer.Size = new System.Drawing.Size(154, 54);
            this.btnCloseServer.TabIndex = 41;
            this.btnCloseServer.Text = "Close Server";
            this.btnCloseServer.UseVisualStyleBackColor = false;
            this.btnCloseServer.Click += new System.EventHandler(this.btnCloseServer_Click);
            // 
            // txtBoxPort
            // 
            this.txtBoxPort.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.txtBoxPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxPort.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.txtBoxPort.Location = new System.Drawing.Point(163, 59);
            this.txtBoxPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBoxPort.Name = "txtBoxPort";
            this.txtBoxPort.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBoxPort.Size = new System.Drawing.Size(154, 29);
            this.txtBoxPort.TabIndex = 35;
            this.txtBoxPort.Text = "502";
            // 
            // btnOpenServer
            // 
            this.btnOpenServer.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnOpenServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnOpenServer.Font = new System.Drawing.Font("Calibri", 10.8F);
            this.btnOpenServer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOpenServer.Location = new System.Drawing.Point(3, 116);
            this.btnOpenServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpenServer.Name = "btnOpenServer";
            this.btnOpenServer.Size = new System.Drawing.Size(154, 54);
            this.btnOpenServer.TabIndex = 40;
            this.btnOpenServer.Text = "Open Server";
            this.btnOpenServer.UseVisualStyleBackColor = false;
            this.btnOpenServer.Click += new System.EventHandler(this.btnOpenServer_Click);
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(387, 281);
            this.Controls.Add(this.grpBoxConnectSettings);
            this.MaximizeBox = false;
            this.Name = "Connect";
            this.Text = "Connect";
            this.grpBoxConnectSettings.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSlaveId)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxConnectSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.Label SlaveID;
        private System.Windows.Forms.Button btnCloseServer;
        private System.Windows.Forms.TextBox txtBoxPort;
        private System.Windows.Forms.Button btnOpenServer;
        private System.Windows.Forms.NumericUpDown numericUpDownSlaveId;
    }
}