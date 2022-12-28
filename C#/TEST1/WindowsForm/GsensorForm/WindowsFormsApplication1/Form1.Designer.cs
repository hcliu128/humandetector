namespace WindowsFormsApplication1
{
    partial class Form1
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txt_data = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.cht_data = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmb_com = new System.Windows.Forms.ComboBox();
            this.picbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cht_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_data
            // 
            this.txt_data.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_data.Location = new System.Drawing.Point(12, 39);
            this.txt_data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_data.Multiline = true;
            this.txt_data.Name = "txt_data";
            this.txt_data.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_data.Size = new System.Drawing.Size(642, 194);
            this.txt_data.TabIndex = 0;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(139, 12);
            this.btn_start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 25);
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(140, 12);
            this.btn_stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 25);
            this.btn_stop.TabIndex = 2;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Visible = false;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(220, 12);
            this.btn_clear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 25);
            this.btn_clear.TabIndex = 3;
            this.btn_clear.Text = "Clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // cht_data
            // 
            chartArea1.BorderColor = System.Drawing.Color.LightGray;
            chartArea1.Name = "ChartArea1";
            this.cht_data.ChartAreas.Add(chartArea1);
            this.cht_data.Cursor = System.Windows.Forms.Cursors.Default;
            legend1.Name = "Legend1";
            this.cht_data.Legends.Add(legend1);
            this.cht_data.Location = new System.Drawing.Point(12, 237);
            this.cht_data.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cht_data.Name = "cht_data";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "data";
            this.cht_data.Series.Add(series1);
            this.cht_data.Size = new System.Drawing.Size(848, 230);
            this.cht_data.TabIndex = 6;
            this.cht_data.Text = "cht_data";
            // 
            // cmb_com
            // 
            this.cmb_com.FormattingEnabled = true;
            this.cmb_com.Location = new System.Drawing.Point(12, 12);
            this.cmb_com.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_com.Name = "cmb_com";
            this.cmb_com.Size = new System.Drawing.Size(121, 23);
            this.cmb_com.TabIndex = 7;
            // 
            // picbox
            // 
            this.picbox.Image = global::WindowsFormsApplication1.Properties.Resources.pic;
            this.picbox.Location = new System.Drawing.Point(660, 38);
            this.picbox.Name = "picbox";
            this.picbox.Size = new System.Drawing.Size(200, 194);
            this.picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbox.TabIndex = 8;
            this.picbox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 495);
            this.Controls.Add(this.picbox);
            this.Controls.Add(this.cmb_com);
            this.Controls.Add(this.cht_data);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txt_data);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.cht_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_data;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_data;
        private System.Windows.Forms.ComboBox cmb_com;
        private System.Windows.Forms.PictureBox picbox;
    }
}

