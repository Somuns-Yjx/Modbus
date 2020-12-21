namespace TcpSlave
{
    partial class TcpSlave
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TcpSlave));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcp连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grpBoxDataView = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.richBoxHistory = new System.Windows.Forms.RichTextBox();
            this.grpBoxDataSettings = new System.Windows.Forms.GroupBox();
            this.txtBoxSkip = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.radioBtnCoil = new System.Windows.Forms.RadioButton();
            this.radioBtnRegister = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnFreshPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.labPageNow = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数值 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerMsg = new System.Windows.Forms.Timer(this.components);
            this.menuStrip.SuspendLayout();
            this.grpBoxDataView.SuspendLayout();
            this.grpBoxDataSettings.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
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
            // grpBoxDataSettings
            // 
            this.grpBoxDataSettings.Controls.Add(this.txtBoxSkip);
            this.grpBoxDataSettings.Controls.Add(this.tableLayoutPanel2);
            this.grpBoxDataSettings.Controls.Add(this.tableLayoutPanel1);
            this.grpBoxDataSettings.Controls.Add(this.labPageNow);
            this.grpBoxDataSettings.Controls.Add(this.dataGridView);
            resources.ApplyResources(this.grpBoxDataSettings, "grpBoxDataSettings");
            this.grpBoxDataSettings.Name = "grpBoxDataSettings";
            this.grpBoxDataSettings.TabStop = false;
            // 
            // txtBoxSkip
            // 
            this.txtBoxSkip.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.txtBoxSkip, "txtBoxSkip");
            this.txtBoxSkip.Name = "txtBoxSkip";
            this.txtBoxSkip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxSkip_KeyPress);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.radioBtnCoil, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.radioBtnRegister, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // radioBtnCoil
            // 
            resources.ApplyResources(this.radioBtnCoil, "radioBtnCoil");
            this.radioBtnCoil.Name = "radioBtnCoil";
            this.radioBtnCoil.TabStop = true;
            this.radioBtnCoil.UseVisualStyleBackColor = true;
            this.radioBtnCoil.Click += new System.EventHandler(this.radioBtnClick);
            // 
            // radioBtnRegister
            // 
            resources.ApplyResources(this.radioBtnRegister, "radioBtnRegister");
            this.radioBtnRegister.Name = "radioBtnRegister";
            this.radioBtnRegister.TabStop = true;
            this.radioBtnRegister.UseVisualStyleBackColor = true;
            this.radioBtnRegister.Click += new System.EventHandler(this.radioBtnClick);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.btnFreshPage, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnFirstPage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnLastPage, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPrevPage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNextPage, 2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // btnFreshPage
            // 
            this.btnFreshPage.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.btnFreshPage, "btnFreshPage");
            this.btnFreshPage.Name = "btnFreshPage";
            this.btnFreshPage.UseVisualStyleBackColor = false;
            this.btnFreshPage.Click += new System.EventHandler(this.btnPageClick);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.btnFirstPage, "btnFirstPage");
            this.btnFirstPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.UseVisualStyleBackColor = false;
            this.btnFirstPage.Click += new System.EventHandler(this.btnPageClick);
            // 
            // btnLastPage
            // 
            this.btnLastPage.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.btnLastPage, "btnLastPage");
            this.btnLastPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.UseVisualStyleBackColor = false;
            this.btnLastPage.Click += new System.EventHandler(this.btnPageClick);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.btnPrevPage, "btnPrevPage");
            this.btnPrevPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.UseVisualStyleBackColor = false;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPageClick);
            // 
            // btnNextPage
            // 
            this.btnNextPage.BackColor = System.Drawing.SystemColors.ScrollBar;
            resources.ApplyResources(this.btnNextPage, "btnNextPage");
            this.btnNextPage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.UseVisualStyleBackColor = false;
            this.btnNextPage.Click += new System.EventHandler(this.btnPageClick);
            // 
            // labPageNow
            // 
            resources.ApplyResources(this.labPageNow, "labPageNow");
            this.labPageNow.Name = "labPageNow";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Addr,
            this.数值});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowTemplate.Height = 27;
            // 
            // Addr
            // 
            resources.ApplyResources(this.Addr, "Addr");
            this.Addr.Name = "Addr";
            this.Addr.ReadOnly = true;
            // 
            // 数值
            // 
            resources.ApplyResources(this.数值, "数值");
            this.数值.Name = "数值";
            this.数值.ReadOnly = true;
            // 
            // timerMsg
            // 
            this.timerMsg.Tick += new System.EventHandler(this.timerMsg_Tick);
            // 
            // TcpSlave
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.grpBoxDataView);
            this.Controls.Add(this.grpBoxDataSettings);
            this.Controls.Add(this.menuStrip);
            this.MaximizeBox = false;
            this.Name = "TcpSlave";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TcpSlave_FormClosing);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.grpBoxDataView.ResumeLayout(false);
            this.grpBoxDataSettings.ResumeLayout(false);
            this.grpBoxDataSettings.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tcp连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpBoxDataView;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpBoxDataSettings;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label labPageNow;
        private System.Windows.Forms.Button btnLastPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.RichTextBox richBoxHistory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton radioBtnCoil;
        private System.Windows.Forms.RadioButton radioBtnRegister;
        private System.Windows.Forms.Button btnFreshPage;
        private System.Windows.Forms.TextBox txtBoxSkip;
        private System.Windows.Forms.Timer timerMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Addr;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数值;
    }
}

