using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;




namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        private bool flag = false;

        public Form1()
        {
            InitializeComponent();
            SetChart();
        }

        private void SetChart() //設定兩圖表的參數
        {
            // 設定ChartArea
            ChartArea area_vibration = new ChartArea("ViewArea");
            area_vibration.AxisX.Minimum = 0;
            area_vibration.AxisY.Minimum = 0;
            area_vibration.AxisY.Maximum = 2;
            area_vibration.AxisX.ScaleView.Size = 20;
            area_vibration.AxisX.Interval = 2;
            area_vibration.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            area_vibration.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            cht_vibration.ChartAreas[0] = area_vibration;
        }

        private void ClearChart(Chart chart)
        {
            for (int i = 0; i < chart.Series.Count; i++)
            {
                chart.Series[i].Points.Clear();
            }
            chart.ChartAreas[0].AxisX.ScaleView.Position = 0;
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            flag = true;
            btn_start.Visible = false;
            btn_stop.Visible = true;
            new Thread(new ThreadStart(delegate
            {
                while (flag == true)
                {
                    List<string> Data = HttpRequest.GetData();
                    List<double> list_Value = new List<double>();
                    foreach (var item in Data)
                    {
                        list_Value.Add(double.Parse(item));
                    }

                    List<ThreadStart> threadParameters = new List<ThreadStart>
                    {
                        new ThreadStart(delegate
                        {
                            Operator.WriteRawDataSafe(txt_message, Data);
                            Operator.RefreshChartSafe(cht_vibration,list_Value);
                        }),
                    };
                    foreach (var task in threadParameters)
                    {
                        new Thread(task).Start();
                    }
                    Thread.Sleep(1000);
                }
            })).Start();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            btn_start.Visible = true;
            btn_stop.Visible = false;
            flag = false;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_message.Clear();
            ClearChart(cht_vibration);
        }
    }
}
