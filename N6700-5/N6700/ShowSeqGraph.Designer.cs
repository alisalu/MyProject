namespace N6700
{
    partial class ShowSeqGraph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart_seq = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bt_exit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart_seq)).BeginInit();
            this.SuspendLayout();
            // 
            // chart_seq
            // 
            this.chart_seq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart_seq.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_seq.Legends.Add(legend1);
            this.chart_seq.Location = new System.Drawing.Point(6, 7);
            this.chart_seq.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chart_seq.Name = "chart_seq";
            this.chart_seq.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart_seq.Size = new System.Drawing.Size(962, 532);
            this.chart_seq.TabIndex = 1;
            this.chart_seq.Text = "chart1";
            // 
            // bt_exit
            // 
            this.bt_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_exit.Image = global::N6700.Properties.Resources.exit_32;
            this.bt_exit.Location = new System.Drawing.Point(976, 4);
            this.bt_exit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.bt_exit.Name = "bt_exit";
            this.bt_exit.Size = new System.Drawing.Size(82, 48);
            this.bt_exit.TabIndex = 0;
            this.bt_exit.Text = "Exit";
            this.bt_exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bt_exit.UseVisualStyleBackColor = true;
            this.bt_exit.Click += new System.EventHandler(this.bt_exit_Click);
            // 
            // ShowSeqGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 551);
            this.Controls.Add(this.chart_seq);
            this.Controls.Add(this.bt_exit);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ShowSeqGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowSeqGraph";
            this.Load += new System.EventHandler(this.ShowSeqGraph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart_seq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_exit;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_seq;


    }
}