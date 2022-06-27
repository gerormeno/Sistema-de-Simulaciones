namespace TP4.Forms
{
    partial class GraficosRk
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartRK1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRK2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRK3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRK4 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartRK1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRK2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRK3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRK4)).BeginInit();
            this.SuspendLayout();
            // 
            // chartRK1
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRK1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chartRK1.Legends.Add(legend1);
            this.chartRK1.Location = new System.Drawing.Point(21, 23);
            this.chartRK1.Name = "chartRK1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartRK1.Series.Add(series1);
            this.chartRK1.Size = new System.Drawing.Size(574, 311);
            this.chartRK1.TabIndex = 4;
            this.chartRK1.Text = "chart1";
            // 
            // chartRK2
            // 
            chartArea2.Name = "ChartArea1";
            this.chartRK2.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chartRK2.Legends.Add(legend2);
            this.chartRK2.Location = new System.Drawing.Point(621, 23);
            this.chartRK2.Name = "chartRK2";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartRK2.Series.Add(series2);
            this.chartRK2.Size = new System.Drawing.Size(574, 311);
            this.chartRK2.TabIndex = 5;
            this.chartRK2.Text = "chart1";
            // 
            // chartRK3
            // 
            chartArea3.Name = "ChartArea1";
            this.chartRK3.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.chartRK3.Legends.Add(legend3);
            this.chartRK3.Location = new System.Drawing.Point(21, 369);
            this.chartRK3.Name = "chartRK3";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartRK3.Series.Add(series3);
            this.chartRK3.Size = new System.Drawing.Size(574, 311);
            this.chartRK3.TabIndex = 6;
            this.chartRK3.Text = "chart2";
            // 
            // chartRK4
            // 
            chartArea4.Name = "ChartArea1";
            this.chartRK4.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartRK4.Legends.Add(legend4);
            this.chartRK4.Location = new System.Drawing.Point(621, 369);
            this.chartRK4.Name = "chartRK4";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Legend = "Legend1";
            series4.LegendText = "X";
            series4.Name = "Series1";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Legend = "Legend1";
            series5.LegendText = "X\'";
            series5.Name = "Series2";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Legend = "Legend1";
            series6.LegendText = "X\'\'";
            series6.Name = "Series3";
            this.chartRK4.Series.Add(series4);
            this.chartRK4.Series.Add(series5);
            this.chartRK4.Series.Add(series6);
            this.chartRK4.Size = new System.Drawing.Size(574, 311);
            this.chartRK4.TabIndex = 7;
            this.chartRK4.Text = "chart3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "X\' en funcion de X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(832, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "X\'\' en funcion de X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "X\'\' en funcion de X\'";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(832, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "X, X\', X\'\' en funcion del Tiempo";
            // 
            // GraficosRk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 728);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartRK4);
            this.Controls.Add(this.chartRK3);
            this.Controls.Add(this.chartRK2);
            this.Controls.Add(this.chartRK1);
            this.Name = "GraficosRk";
            this.Text = "GraficosRk";
            ((System.ComponentModel.ISupportInitialize)(this.chartRK1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRK2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRK3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRK4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartRK1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRK2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRK3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRK4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}