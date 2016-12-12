namespace EvolutionaryAlgo
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.BestGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Run = new System.Windows.Forms.Button();
            this.btn_last = new System.Windows.Forms.Button();
            this.Rbs_graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chart_AIS = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.BestGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rbs_graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_AIS)).BeginInit();
            this.SuspendLayout();
            // 
            // BestGraph
            // 
            chartArea1.Name = "ChartArea1";
            this.BestGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.BestGraph.Legends.Add(legend1);
            this.BestGraph.Location = new System.Drawing.Point(38, 77);
            this.BestGraph.Name = "BestGraph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.BestGraph.Series.Add(series1);
            this.BestGraph.Size = new System.Drawing.Size(509, 293);
            this.BestGraph.TabIndex = 0;
            this.BestGraph.Text = "chart1";
            this.BestGraph.Click += new System.EventHandler(this.BestGraph_Click);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(38, 30);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 2;
            this.Run.Text = "Next";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // btn_last
            // 
            this.btn_last.Location = new System.Drawing.Point(119, 30);
            this.btn_last.Name = "btn_last";
            this.btn_last.Size = new System.Drawing.Size(75, 23);
            this.btn_last.TabIndex = 3;
            this.btn_last.Text = "last";
            this.btn_last.UseVisualStyleBackColor = true;
            this.btn_last.Click += new System.EventHandler(this.btn_last_Click);
            // 
            // Rbs_graph
            // 
            chartArea2.Name = "ChartArea1";
            this.Rbs_graph.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Rbs_graph.Legends.Add(legend2);
            this.Rbs_graph.Location = new System.Drawing.Point(575, 77);
            this.Rbs_graph.Name = "Rbs_graph";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.Rbs_graph.Series.Add(series2);
            this.Rbs_graph.Size = new System.Drawing.Size(463, 293);
            this.Rbs_graph.TabIndex = 4;
            this.Rbs_graph.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "FPS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(714, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "RBS";
            // 
            // chart_AIS
            // 
            chartArea3.Name = "ChartArea1";
            this.chart_AIS.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart_AIS.Legends.Add(legend3);
            this.chart_AIS.Location = new System.Drawing.Point(575, 404);
            this.chart_AIS.Name = "chart_AIS";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chart_AIS.Series.Add(series3);
            this.chart_AIS.Size = new System.Drawing.Size(463, 306);
            this.chart_AIS.TabIndex = 7;
            this.chart_AIS.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 741);
            this.Controls.Add(this.chart_AIS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rbs_graph);
            this.Controls.Add(this.btn_last);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.BestGraph);
            this.Name = "Form1";
            this.Text = "Algo";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BestGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rbs_graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_AIS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart BestGraph;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.Button btn_last;
        private System.Windows.Forms.DataVisualization.Charting.Chart Rbs_graph;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_AIS;
    }
}

