namespace N6700
{
    partial class ConfigSet
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_SeqDelay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Chassis_Delay = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Digitizer_Seconds = new System.Windows.Forms.TextBox();
            this.txt_Digitizer_GraphPoint = new System.Windows.Forms.TextBox();
            this.txt_Digitizer_OffsetPoint = new System.Windows.Forms.TextBox();
            this.txt_Delay = new System.Windows.Forms.TextBox();
            this.Combo_Measure = new System.Windows.Forms.ComboBox();
            this.Combo_PowerLeft = new System.Windows.Forms.ComboBox();
            this.bt_Cancel = new System.Windows.Forms.Button();
            this.bt_OK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CB_SHUTDOWN = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TB_Delay = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TB_ClientIP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TB_PORT = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Power Left On or Off after sequence?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Measure Current or Measure Voltage?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "SYSRST* Delay (Sec) ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "#Points Offset to Trigger Digitizer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 143);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(226, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "#of Digitizer Graph Points (<64K)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 175);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "#of Seconds to Digitizer";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.Txt_SeqDelay);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_Chassis_Delay);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_Digitizer_Seconds);
            this.groupBox1.Controls.Add(this.txt_Digitizer_GraphPoint);
            this.groupBox1.Controls.Add(this.txt_Digitizer_OffsetPoint);
            this.groupBox1.Controls.Add(this.txt_Delay);
            this.groupBox1.Controls.Add(this.Combo_Measure);
            this.groupBox1.Controls.Add(this.Combo_PowerLeft);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(8, 7);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(398, 260);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config Setting";
            // 
            // Txt_SeqDelay
            // 
            this.Txt_SeqDelay.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_SeqDelay.Location = new System.Drawing.Point(292, 227);
            this.Txt_SeqDelay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Txt_SeqDelay.MaxLength = 5;
            this.Txt_SeqDelay.Name = "Txt_SeqDelay";
            this.Txt_SeqDelay.Size = new System.Drawing.Size(95, 23);
            this.Txt_SeqDelay.TabIndex = 15;
            this.Txt_SeqDelay.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 231);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(290, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Delay from click to sequences start (Sec) ";
            // 
            // txt_Chassis_Delay
            // 
            this.txt_Chassis_Delay.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Chassis_Delay.Location = new System.Drawing.Point(292, 198);
            this.txt_Chassis_Delay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Chassis_Delay.Name = "txt_Chassis_Delay";
            this.txt_Chassis_Delay.Size = new System.Drawing.Size(95, 23);
            this.txt_Chassis_Delay.TabIndex = 13;
            this.txt_Chassis_Delay.Text = "0";
            this.txt_Chassis_Delay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Chassis_Delay_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 204);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(275, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Delay from click to chassis inhibit (Sec) ";
            // 
            // txt_Digitizer_Seconds
            // 
            this.txt_Digitizer_Seconds.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Digitizer_Seconds.Location = new System.Drawing.Point(292, 169);
            this.txt_Digitizer_Seconds.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Digitizer_Seconds.MaxLength = 5;
            this.txt_Digitizer_Seconds.Name = "txt_Digitizer_Seconds";
            this.txt_Digitizer_Seconds.Size = new System.Drawing.Size(95, 23);
            this.txt_Digitizer_Seconds.TabIndex = 11;
            this.txt_Digitizer_Seconds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Digitizer_Seconds_KeyPress);
            // 
            // txt_Digitizer_GraphPoint
            // 
            this.txt_Digitizer_GraphPoint.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Digitizer_GraphPoint.Location = new System.Drawing.Point(292, 139);
            this.txt_Digitizer_GraphPoint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Digitizer_GraphPoint.MaxLength = 5;
            this.txt_Digitizer_GraphPoint.Name = "txt_Digitizer_GraphPoint";
            this.txt_Digitizer_GraphPoint.Size = new System.Drawing.Size(95, 23);
            this.txt_Digitizer_GraphPoint.TabIndex = 10;
            this.txt_Digitizer_GraphPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Digitizer_GraphPoint_KeyPress);
            // 
            // txt_Digitizer_OffsetPoint
            // 
            this.txt_Digitizer_OffsetPoint.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Digitizer_OffsetPoint.Location = new System.Drawing.Point(292, 110);
            this.txt_Digitizer_OffsetPoint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Digitizer_OffsetPoint.MaxLength = 6;
            this.txt_Digitizer_OffsetPoint.Name = "txt_Digitizer_OffsetPoint";
            this.txt_Digitizer_OffsetPoint.Size = new System.Drawing.Size(95, 23);
            this.txt_Digitizer_OffsetPoint.TabIndex = 9;
            this.txt_Digitizer_OffsetPoint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Digitizer_OffsetPoint_KeyPress);
            // 
            // txt_Delay
            // 
            this.txt_Delay.Enabled = false;
            this.txt_Delay.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Delay.Location = new System.Drawing.Point(292, 82);
            this.txt_Delay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Delay.MaxLength = 6;
            this.txt_Delay.Name = "txt_Delay";
            this.txt_Delay.Size = new System.Drawing.Size(95, 23);
            this.txt_Delay.TabIndex = 8;
            this.txt_Delay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Delay_KeyPress);
            // 
            // Combo_Measure
            // 
            this.Combo_Measure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_Measure.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Combo_Measure.FormattingEnabled = true;
            this.Combo_Measure.Items.AddRange(new object[] {
            "Current",
            "Voltage"});
            this.Combo_Measure.Location = new System.Drawing.Point(292, 51);
            this.Combo_Measure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Combo_Measure.Name = "Combo_Measure";
            this.Combo_Measure.Size = new System.Drawing.Size(95, 24);
            this.Combo_Measure.TabIndex = 7;
            this.Combo_Measure.SelectedIndexChanged += new System.EventHandler(this.Combo_Measure_SelectedIndexChanged);
            // 
            // Combo_PowerLeft
            // 
            this.Combo_PowerLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_PowerLeft.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Combo_PowerLeft.FormattingEnabled = true;
            this.Combo_PowerLeft.Items.AddRange(new object[] {
            "ON",
            "OFF"});
            this.Combo_PowerLeft.Location = new System.Drawing.Point(292, 21);
            this.Combo_PowerLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Combo_PowerLeft.Name = "Combo_PowerLeft";
            this.Combo_PowerLeft.Size = new System.Drawing.Size(95, 24);
            this.Combo_PowerLeft.TabIndex = 6;
            this.Combo_PowerLeft.SelectedIndexChanged += new System.EventHandler(this.Combo_PowerLeft_SelectedIndexChanged);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Cancel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Cancel.Image = global::N6700.Properties.Resources.Cancel_16;
            this.bt_Cancel.Location = new System.Drawing.Point(215, 420);
            this.bt_Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(83, 33);
            this.bt_Cancel.TabIndex = 8;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Cancel.UseVisualStyleBackColor = true;
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // bt_OK
            // 
            this.bt_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_OK.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_OK.Image = global::N6700.Properties.Resources.OK_16;
            this.bt_OK.Location = new System.Drawing.Point(92, 420);
            this.bt_OK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(79, 33);
            this.bt_OK.TabIndex = 6;
            this.bt_OK.Text = "OK";
            this.bt_OK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_OK.UseVisualStyleBackColor = true;
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CB_SHUTDOWN);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TB_Delay);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.TB_ClientIP);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.TB_PORT);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(8, 277);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(398, 134);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Remote Shutdown Setting";
            // 
            // CB_SHUTDOWN
            // 
            this.CB_SHUTDOWN.AutoSize = true;
            this.CB_SHUTDOWN.Location = new System.Drawing.Point(6, 23);
            this.CB_SHUTDOWN.Name = "CB_SHUTDOWN";
            this.CB_SHUTDOWN.Size = new System.Drawing.Size(375, 20);
            this.CB_SHUTDOWN.TabIndex = 20;
            this.CB_SHUTDOWN.Text = "Send Romote Shutdown Command to PXIe Controller";
            this.CB_SHUTDOWN.UseVisualStyleBackColor = true;
            this.CB_SHUTDOWN.CheckedChanged += new System.EventHandler(this.CB_SHUTDOWN_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(2, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(214, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Send shutdown command after";
            // 
            // TB_Delay
            // 
            this.TB_Delay.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Delay.Location = new System.Drawing.Point(219, 100);
            this.TB_Delay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_Delay.MaxLength = 5;
            this.TB_Delay.Name = "TB_Delay";
            this.TB_Delay.Size = new System.Drawing.Size(39, 23);
            this.TB_Delay.TabIndex = 18;
            this.TB_Delay.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(264, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Second";
            // 
            // TB_ClientIP
            // 
            this.TB_ClientIP.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_ClientIP.Location = new System.Drawing.Point(137, 47);
            this.TB_ClientIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_ClientIP.MaxLength = 20;
            this.TB_ClientIP.Name = "TB_ClientIP";
            this.TB_ClientIP.Size = new System.Drawing.Size(129, 23);
            this.TB_ClientIP.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 49);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(130, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "PXIe Controller IP:";
            // 
            // TB_PORT
            // 
            this.TB_PORT.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_PORT.Location = new System.Drawing.Point(47, 75);
            this.TB_PORT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TB_PORT.MaxLength = 4;
            this.TB_PORT.Name = "TB_PORT";
            this.TB_PORT.Size = new System.Drawing.Size(101, 23);
            this.TB_PORT.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 75);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "Port:";
            // 
            // ConfigSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 462);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.bt_OK);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ConfigSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfigSet";
            this.Load += new System.EventHandler(this.ConfigSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bt_OK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox Combo_Measure;
        private System.Windows.Forms.ComboBox Combo_PowerLeft;
        private System.Windows.Forms.TextBox txt_Digitizer_Seconds;
        private System.Windows.Forms.TextBox txt_Digitizer_GraphPoint;
        private System.Windows.Forms.TextBox txt_Digitizer_OffsetPoint;
        private System.Windows.Forms.TextBox txt_Delay;
        private System.Windows.Forms.Button bt_Cancel;
        private System.Windows.Forms.TextBox txt_Chassis_Delay;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Txt_SeqDelay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TB_Delay;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TB_ClientIP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TB_PORT;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox CB_SHUTDOWN;
    }
}