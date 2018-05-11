namespace N6700
{
    partial class DataGraph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGraph));
            this.chart_Data = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bt_Save = new System.Windows.Forms.Button();
            this.bt_exit = new System.Windows.Forms.Button();
            this.BT_SAVEIMG = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_Data
            // 
            this.chart_Data.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.chart_Data.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_Data.Legends.Add(legend2);
            this.chart_Data.Location = new System.Drawing.Point(13, 63);
            this.chart_Data.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chart_Data.Name = "chart_Data";
            this.chart_Data.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart_Data.Size = new System.Drawing.Size(1112, 613);
            this.chart_Data.TabIndex = 0;
            this.chart_Data.Text = "chart1";
            // 
            // bt_Save
            // 
            this.bt_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Save.Image = ((System.Drawing.Image)(resources.GetObject("bt_Save.Image")));
            this.bt_Save.Location = new System.Drawing.Point(965, 5);
            this.bt_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(80, 50);
            this.bt_Save.TabIndex = 1;
            this.bt_Save.Text = "Save";
            this.bt_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // bt_exit
            // 
            this.bt_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_exit.Image = global::N6700.Properties.Resources.exit_32;
            this.bt_exit.Location = new System.Drawing.Point(1053, 5);
            this.bt_exit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(72, 50);
            this.bt_exit.TabIndex = 2;
            this.bt_exit.Text = "Exit";
            this.bt_exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // BT_SAVEIMG
            // 
            this.BT_SAVEIMG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_SAVEIMG.Location = new System.Drawing.Point(893, 9);
            this.BT_SAVEIMG.Name = "BT_SAVEIMG";
            this.BT_SAVEIMG.Size = new System.Drawing.Size(60, 45);
            this.BT_SAVEIMG.TabIndex = 3;
            this.BT_SAVEIMG.Text = "Save Img";
            this.BT_SAVEIMG.UseVisualStyleBackColor = true;
            this.BT_SAVEIMG.Click += new System.EventHandler(this.BT_SAVEIMG_Click);
            // 
            // DataGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 683);
            this.Controls.Add(this.BT_SAVEIMG);
            this.Controls.Add(this.bt_exit);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.chart_Data);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DataGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataGraph";
            this.Load += new System.EventHandler(this.DataGraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Data;
        private System.Windows.Forms.Button bt_Save;
        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.Button BT_SAVEIMG;
    }
}