namespace ReModbus
{
    partial class TcpMaster
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TcpMaster));
            this.btnSend = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.grpBoxDataSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelfunc = new System.Windows.Forms.Label();
            this.labelamount = new System.Windows.Forms.Label();
            this.labeladdr = new System.Windows.Forms.Label();
            this.labeltrans = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDownAmt = new System.Windows.Forms.NumericUpDown();
            this.txtBoxTrans = new System.Windows.Forms.TextBox();
            this.numericUpDownSlaveId = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAddr = new System.Windows.Forms.NumericUpDown();
            this.comboFunc = new System.Windows.Forms.ComboBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcp连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpBoxDataView = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.richBoxHistory = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.grpBoxDataSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSlaveId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAddr)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.grpBoxDataView.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.btnSend, "btnSend");
            this.btnSend.Name = "btnSend";
            this.btnSend.UseVisualStyleBackColor = false;
            this.btnSend.Click += new System.EventHandler(this.btnsend_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 27;
            // 
            // grpBoxDataSettings
            // 
            this.grpBoxDataSettings.Controls.Add(this.tableLayoutPanel2);
            this.grpBoxDataSettings.Controls.Add(this.tableLayoutPanel1);
            this.grpBoxDataSettings.Controls.Add(this.tableLayoutPanel);
            this.grpBoxDataSettings.Controls.Add(this.dataGridView);
            resources.ApplyResources(this.grpBoxDataSettings, "grpBoxDataSettings");
            this.grpBoxDataSettings.Name = "grpBoxDataSettings";
            this.grpBoxDataSettings.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.btnSend, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCreate, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnSave, 0, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.btnCreate, "btnCreate");
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.labelfunc, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelamount, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.labeladdr, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labeltrans, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelId, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // labelfunc
            // 
            resources.ApplyResources(this.labelfunc, "labelfunc");
            this.labelfunc.Name = "labelfunc";
            // 
            // labelamount
            // 
            resources.ApplyResources(this.labelamount, "labelamount");
            this.labelamount.Name = "labelamount";
            // 
            // labeladdr
            // 
            resources.ApplyResources(this.labeladdr, "labeladdr");
            this.labeladdr.Name = "labeladdr";
            // 
            // labeltrans
            // 
            resources.ApplyResources(this.labeltrans, "labeltrans");
            this.labeltrans.Name = "labeltrans";
            // 
            // labelId
            // 
            resources.ApplyResources(this.labelId, "labelId");
            this.labelId.Name = "labelId";
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.numericUpDownAmt, 4, 0);
            this.tableLayoutPanel.Controls.Add(this.txtBoxTrans, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.numericUpDownSlaveId, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.numericUpDownAddr, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.comboFunc, 2, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // numericUpDownAmt
            // 
            this.numericUpDownAmt.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.numericUpDownAmt, "numericUpDownAmt");
            this.numericUpDownAmt.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownAmt.Name = "numericUpDownAmt";
            // 
            // txtBoxTrans
            // 
            this.txtBoxTrans.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.txtBoxTrans, "txtBoxTrans");
            this.txtBoxTrans.Name = "txtBoxTrans";
            this.txtBoxTrans.ReadOnly = true;
            // 
            // numericUpDownSlaveId
            // 
            this.numericUpDownSlaveId.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.numericUpDownSlaveId, "numericUpDownSlaveId");
            this.numericUpDownSlaveId.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownSlaveId.Name = "numericUpDownSlaveId";
            // 
            // numericUpDownAddr
            // 
            this.numericUpDownAddr.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.numericUpDownAddr, "numericUpDownAddr");
            this.numericUpDownAddr.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownAddr.Name = "numericUpDownAddr";
            // 
            // comboFunc
            // 
            this.comboFunc.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.comboFunc, "comboFunc");
            this.comboFunc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFunc.FormattingEnabled = true;
            this.comboFunc.Items.AddRange(new object[] {
            resources.GetString("comboFunc.Items"),
            resources.GetString("comboFunc.Items1"),
            resources.GetString("comboFunc.Items2"),
            resources.GetString("comboFunc.Items3")});
            this.comboFunc.Name = "comboFunc";
            this.comboFunc.SelectedValueChanged += new System.EventHandler(this.comboFunc_SelectedValueChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            // 
            // 菜单ToolStripMenuItem
            // 
            this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tcp连接ToolStripMenuItem});
            this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
            resources.ApplyResources(this.菜单ToolStripMenuItem, "菜单ToolStripMenuItem");
            // 
            // tcp连接ToolStripMenuItem
            // 
            this.tcp连接ToolStripMenuItem.Name = "tcp连接ToolStripMenuItem";
            resources.ApplyResources(this.tcp连接ToolStripMenuItem, "tcp连接ToolStripMenuItem");
            this.tcp连接ToolStripMenuItem.Click += new System.EventHandler(this.tcp连接ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            resources.ApplyResources(this.帮助ToolStripMenuItem, "帮助ToolStripMenuItem");
            // 
            // grpBoxDataView
            // 
            this.grpBoxDataView.Controls.Add(this.btnClear);
            this.grpBoxDataView.Controls.Add(this.richBoxHistory);
            resources.ApplyResources(this.grpBoxDataView, "grpBoxDataView");
            this.grpBoxDataView.Name = "grpBoxDataView";
            this.grpBoxDataView.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.btnClear, "btnClear");
            this.btnClear.Name = "btnClear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // richBoxHistory
            // 
            this.richBoxHistory.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.richBoxHistory, "richBoxHistory");
            this.richBoxHistory.Name = "richBoxHistory";
            this.richBoxHistory.ReadOnly = true;
            // 
            // TcpMaster
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.grpBoxDataView);
            this.Controls.Add(this.grpBoxDataSettings);
            this.Controls.Add(this.menuStrip);
            this.MaximizeBox = false;
            this.Name = "TcpMaster";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TcpMaster_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.grpBoxDataSettings.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSlaveId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAddr)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.grpBoxDataView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox grpBoxDataSettings;
        private System.Windows.Forms.Label labelamount;
        private System.Windows.Forms.Label labeladdr;
        private System.Windows.Forms.Label labelfunc;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labeltrans;
        public System.Windows.Forms.Button btnCreate;
        public System.Windows.Forms.ComboBox comboFunc;
        public System.Windows.Forms.TextBox txtBoxTrans;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numericUpDownAddr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.NumericUpDown numericUpDownSlaveId;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tcp连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDownAmt;
        private System.Windows.Forms.GroupBox grpBoxDataView;
        private System.Windows.Forms.RichTextBox richBoxHistory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnClear;
    }
}

