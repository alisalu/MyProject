namespace N6700
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tab_Model = new System.Windows.Forms.TabControl();
            this.tab_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_AddModel = new System.Windows.Forms.Button();
            this.datagrid_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bt_SAVEAS = new System.Windows.Forms.Button();
            this.bt_ImportSeq = new System.Windows.Forms.Button();
            this.bt_Save = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bt_RunSeq = new System.Windows.Forms.Button();
            this.bt_TurnOff = new System.Windows.Forms.Button();
            this.CB_RUNNOREST = new System.Windows.Forms.CheckBox();
            this.bt_ViewDataGraph = new System.Windows.Forms.Button();
            this.bt_ViewSeqGraph = new System.Windows.Forms.Button();
            this.bt_Settings = new System.Windows.Forms.Button();
            this.TB_MSG = new System.Windows.Forms.TextBox();
            this.tab_contextMenu.SuspendLayout();
            this.datagrid_contextMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_Model
            // 
            this.tab_Model.Location = new System.Drawing.Point(6, 99);
            this.tab_Model.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tab_Model.Name = "tab_Model";
            this.tab_Model.SelectedIndex = 0;
            this.tab_Model.Size = new System.Drawing.Size(831, 661);
            this.tab_Model.TabIndex = 0;
            // 
            // tab_contextMenu
            // 
            this.tab_contextMenu.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.tab_contextMenu.Name = "tab_contextMenu";
            this.tab_contextMenu.Size = new System.Drawing.Size(143, 48);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.addToolStripMenuItem.Text = "Add Tab";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.deleteToolStripMenuItem.Text = "Delete Tab";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // bt_AddModel
            // 
            this.bt_AddModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_AddModel.Location = new System.Drawing.Point(845, 70);
            this.bt_AddModel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bt_AddModel.Name = "bt_AddModel";
            this.bt_AddModel.Size = new System.Drawing.Size(117, 41);
            this.bt_AddModel.TabIndex = 1;
            this.bt_AddModel.Text = "Add Model";
            this.bt_AddModel.UseVisualStyleBackColor = true;
            this.bt_AddModel.Visible = false;
            this.bt_AddModel.Click += new System.EventHandler(this.bt_AddModel_Click);
            // 
            // datagrid_contextMenu
            // 
            this.datagrid_contextMenu.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datagrid_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRowToolStripMenuItem,
            this.copyRowToolStripMenuItem,
            this.deleteRowToolStripMenuItem});
            this.datagrid_contextMenu.Name = "datagrid_contextMenu";
            this.datagrid_contextMenu.Size = new System.Drawing.Size(147, 70);
            // 
            // addRowToolStripMenuItem
            // 
            this.addRowToolStripMenuItem.Name = "addRowToolStripMenuItem";
            this.addRowToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.addRowToolStripMenuItem.Text = "Add Row";
            this.addRowToolStripMenuItem.Visible = false;
            this.addRowToolStripMenuItem.Click += new System.EventHandler(this.addRowToolStripMenuItem_Click);
            // 
            // copyRowToolStripMenuItem
            // 
            this.copyRowToolStripMenuItem.Name = "copyRowToolStripMenuItem";
            this.copyRowToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.copyRowToolStripMenuItem.Text = "Copy Row";
            this.copyRowToolStripMenuItem.Click += new System.EventHandler(this.copyRowToolStripMenuItem_Click);
            // 
            // deleteRowToolStripMenuItem
            // 
            this.deleteRowToolStripMenuItem.Name = "deleteRowToolStripMenuItem";
            this.deleteRowToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.deleteRowToolStripMenuItem.Text = "Delete Row";
            this.deleteRowToolStripMenuItem.Click += new System.EventHandler(this.deleteRowToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bt_SAVEAS);
            this.groupBox2.Controls.Add(this.bt_ImportSeq);
            this.groupBox2.Controls.Add(this.bt_Save);
            this.groupBox2.Location = new System.Drawing.Point(6, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 62);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // bt_SAVEAS
            // 
            this.bt_SAVEAS.BackColor = System.Drawing.SystemColors.Control;
            this.bt_SAVEAS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_SAVEAS.Image = ((System.Drawing.Image)(resources.GetObject("bt_SAVEAS.Image")));
            this.bt_SAVEAS.Location = new System.Drawing.Point(148, 12);
            this.bt_SAVEAS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bt_SAVEAS.Name = "bt_SAVEAS";
            this.bt_SAVEAS.Size = new System.Drawing.Size(84, 41);
            this.bt_SAVEAS.TabIndex = 8;
            this.bt_SAVEAS.Text = "Save as";
            this.bt_SAVEAS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_SAVEAS.UseVisualStyleBackColor = false;
            this.bt_SAVEAS.Click += new System.EventHandler(this.bt_ExportSeq_Click);
            // 
            // bt_ImportSeq
            // 
            this.bt_ImportSeq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ImportSeq.Image = ((System.Drawing.Image)(resources.GetObject("bt_ImportSeq.Image")));
            this.bt_ImportSeq.Location = new System.Drawing.Point(7, 12);
            this.bt_ImportSeq.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bt_ImportSeq.Name = "bt_ImportSeq";
            this.bt_ImportSeq.Size = new System.Drawing.Size(114, 41);
            this.bt_ImportSeq.TabIndex = 7;
            this.bt_ImportSeq.Text = "Import Sequence";
            this.bt_ImportSeq.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_ImportSeq.UseVisualStyleBackColor = true;
            this.bt_ImportSeq.Click += new System.EventHandler(this.bt_ImportSeq_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Save.Image = ((System.Drawing.Image)(resources.GetObject("bt_Save.Image")));
            this.bt_Save.Location = new System.Drawing.Point(236, 12);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(80, 41);
            this.bt_Save.TabIndex = 9;
            this.bt_Save.Text = "Save";
            this.bt_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Save.UseVisualStyleBackColor = false;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bt_RunSeq);
            this.groupBox3.Controls.Add(this.bt_TurnOff);
            this.groupBox3.Location = new System.Drawing.Point(608, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 63);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // bt_RunSeq
            // 
            this.bt_RunSeq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_RunSeq.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bt_RunSeq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_RunSeq.Image = ((System.Drawing.Image)(resources.GetObject("bt_RunSeq.Image")));
            this.bt_RunSeq.Location = new System.Drawing.Point(9, 14);
            this.bt_RunSeq.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bt_RunSeq.Name = "bt_RunSeq";
            this.bt_RunSeq.Size = new System.Drawing.Size(93, 41);
            this.bt_RunSeq.TabIndex = 2;
            this.bt_RunSeq.Text = "Run Seqs";
            this.bt_RunSeq.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_RunSeq.UseVisualStyleBackColor = false;
            this.bt_RunSeq.Click += new System.EventHandler(this.bt_RunSeq_Click);
            // 
            // bt_TurnOff
            // 
            this.bt_TurnOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_TurnOff.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.bt_TurnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_TurnOff.Image = ((System.Drawing.Image)(resources.GetObject("bt_TurnOff.Image")));
            this.bt_TurnOff.Location = new System.Drawing.Point(111, 14);
            this.bt_TurnOff.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bt_TurnOff.Name = "bt_TurnOff";
            this.bt_TurnOff.Size = new System.Drawing.Size(93, 41);
            this.bt_TurnOff.TabIndex = 6;
            this.bt_TurnOff.Text = "Turn Off";
            this.bt_TurnOff.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_TurnOff.UseVisualStyleBackColor = false;
            this.bt_TurnOff.Click += new System.EventHandler(this.bt_TurnOff_Click);
            // 
            // CB_RUNNOREST
            // 
            this.CB_RUNNOREST.AutoSize = true;
            this.CB_RUNNOREST.Location = new System.Drawing.Point(461, 26);
            this.CB_RUNNOREST.Name = "CB_RUNNOREST";
            this.CB_RUNNOREST.Size = new System.Drawing.Size(144, 18);
            this.CB_RUNNOREST.TabIndex = 13;
            this.CB_RUNNOREST.Text = "Run Without Reset";
            this.CB_RUNNOREST.UseVisualStyleBackColor = true;
            // 
            // bt_ViewDataGraph
            // 
            this.bt_ViewDataGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ViewDataGraph.BackColor = System.Drawing.SystemColors.Control;
            this.bt_ViewDataGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ViewDataGraph.Image = ((System.Drawing.Image)(resources.GetObject("bt_ViewDataGraph.Image")));
            this.bt_ViewDataGraph.Location = new System.Drawing.Point(845, 211);
            this.bt_ViewDataGraph.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bt_ViewDataGraph.Name = "bt_ViewDataGraph";
            this.bt_ViewDataGraph.Size = new System.Drawing.Size(117, 41);
            this.bt_ViewDataGraph.TabIndex = 5;
            this.bt_ViewDataGraph.Text = "Digitizer Data";
            this.bt_ViewDataGraph.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_ViewDataGraph.UseVisualStyleBackColor = false;
            this.bt_ViewDataGraph.Click += new System.EventHandler(this.bt_ViewDataGraph_Click);
            // 
            // bt_ViewSeqGraph
            // 
            this.bt_ViewSeqGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ViewSeqGraph.BackColor = System.Drawing.SystemColors.Control;
            this.bt_ViewSeqGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_ViewSeqGraph.Image = ((System.Drawing.Image)(resources.GetObject("bt_ViewSeqGraph.Image")));
            this.bt_ViewSeqGraph.Location = new System.Drawing.Point(845, 164);
            this.bt_ViewSeqGraph.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bt_ViewSeqGraph.Name = "bt_ViewSeqGraph";
            this.bt_ViewSeqGraph.Size = new System.Drawing.Size(117, 41);
            this.bt_ViewSeqGraph.TabIndex = 4;
            this.bt_ViewSeqGraph.Text = "Sequence Graph";
            this.bt_ViewSeqGraph.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_ViewSeqGraph.UseVisualStyleBackColor = false;
            this.bt_ViewSeqGraph.Click += new System.EventHandler(this.bt_ViewSeqGraph_Click);
            // 
            // bt_Settings
            // 
            this.bt_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Settings.BackColor = System.Drawing.SystemColors.Control;
            this.bt_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Settings.Image = ((System.Drawing.Image)(resources.GetObject("bt_Settings.Image")));
            this.bt_Settings.Location = new System.Drawing.Point(845, 117);
            this.bt_Settings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bt_Settings.Name = "bt_Settings";
            this.bt_Settings.Size = new System.Drawing.Size(117, 41);
            this.bt_Settings.TabIndex = 3;
            this.bt_Settings.Text = "Settings";
            this.bt_Settings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Settings.UseVisualStyleBackColor = false;
            this.bt_Settings.Click += new System.EventHandler(this.bt_Settings_Click);
            // 
            // TB_MSG
            // 
            this.TB_MSG.ForeColor = System.Drawing.Color.Blue;
            this.TB_MSG.Location = new System.Drawing.Point(9, 72);
            this.TB_MSG.Name = "TB_MSG";
            this.TB_MSG.Size = new System.Drawing.Size(811, 22);
            this.TB_MSG.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 765);
            this.Controls.Add(this.TB_MSG);
            this.Controls.Add(this.CB_RUNNOREST);
            this.Controls.Add(this.bt_ViewDataGraph);
            this.Controls.Add(this.bt_ViewSeqGraph);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bt_Settings);
            this.Controls.Add(this.bt_AddModel);
            this.Controls.Add(this.tab_Model);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PXI Power Simulator Software version 6.0";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.tab_contextMenu.ResumeLayout(false);
            this.datagrid_contextMenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tab_Model;
        private System.Windows.Forms.Button bt_AddModel;
        private System.Windows.Forms.Button bt_RunSeq;
        private System.Windows.Forms.Button bt_Settings;
        private System.Windows.Forms.Button bt_ViewSeqGraph;
        private System.Windows.Forms.Button bt_ViewDataGraph;
        private System.Windows.Forms.Button bt_TurnOff;
        private System.Windows.Forms.Button bt_ImportSeq;
        private System.Windows.Forms.Button bt_SAVEAS;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.ContextMenuStrip tab_contextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip datagrid_contextMenu;
        private System.Windows.Forms.ToolStripMenuItem addRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyRowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteRowToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox CB_RUNNOREST;
        private System.Windows.Forms.TextBox TB_MSG;
    }
}

