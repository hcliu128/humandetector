using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//以下using要自己加
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json.Linq; //這邊有使用Newtonsoft.Json的套件來處理json字串，同學們可能要自己安裝NuGet來安裝此套件
using System.IO.Ports;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private SerialPort _serialPort;

        public Form1()
        {
            InitializeComponent();
            SetChart();
            InitialPort();
            cmb_com.SelectedIndex = 0;
            picbox.Visible = false;
            picbox.Image = Image.FromFile("D:\\Users\\super87\\Desktop\\TEST1\\WindowsForm\\GsensorForm\\WindowsFormsApplication1\\bin\\Debug\\pic.jpg");
        }
        private void InitialPort() //初始化port把全部有連線的port name找出來加到 cmb_com 的集合中
        {
            string[] ports = SerialPort.GetPortNames();
            for (int i = 0; i < ports.Count(); i++)
            {
                cmb_com.Items.AddRange(new object[] {
                ports[i]});
            }
        }
        private void SetPort() //設定port參數
        {
            _serialPort = new SerialPort
            {
                PortName = cmb_com.SelectedItem.ToString(),
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None,
                Handshake = Handshake.None,
                ReadTimeout = 500,
                RtsEnable = true
            };
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }
        private void SetChart() //設定兩圖表的參數
        {
            // 設定ChartArea
            ChartArea datavaule = new ChartArea("ViewData");
            datavaule.AxisX.Minimum = 0; //X軸數值從0開始
            datavaule.AxisY.Minimum = 0;
            datavaule.AxisY.Maximum = 2;
            datavaule.AxisX.ScaleView.Size = 20; //設定視窗範圍內一開始顯示多少點
            datavaule.AxisX.Interval = 2; //設定格線間隔為20
            datavaule.AxisX.IntervalAutoMode = IntervalAutoMode.FixedCount;
            datavaule.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All; //設定scrollbar
            cht_data.ChartAreas[0] = datavaule; //將設定好的ChartArea放進Chart
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string indata = (sender as SerialPort).ReadLine();
                JObject jsonData = JObject.Parse(indata);
                double humanData = double.Parse(jsonData["message"].ToString());
                /*double[] angleData = new double[]
                {
                    double.Parse(jsonData["aX"].ToString()) / 100,
                    double.Parse(jsonData["aY"].ToString()) / 100,
                    double.Parse(jsonData["aZ"].ToString()) / 100
                };
                double[] accelerationData = new double[]
                {
                    double.Parse(jsonData["gX"].ToString()) / 100,
                    double.Parse(jsonData["gY"].ToString()) / 100,
                    double.Parse(jsonData["gZ"].ToString()) / 100
                };*/
                //為避免視窗因工作量大造成卡頓，建立多執行緒控制視窗程式
                //將執行緒任務包成List，並且將寫好的方法用委派傳入執行緒中
                //這樣以後新增任務只要在List中加上: 
                //new ThreadStart(delegate { Some things you want to do });
                List<ThreadStart> threadParameters = new List<ThreadStart>
                {
                    new ThreadStart(delegate { Operator.WriteRawDataSafe(this.txt_data, jsonData); }),
                    new ThreadStart(delegate { Operator.RefreshChartSafe(this.cht_data, humanData);}),
                    new ThreadStart(delegate { Operator.WarningPicture(this.picbox, humanData);}),
                    
                };
                foreach (var task in threadParameters)
                {
                    new Thread(task).Start();
                }

            }
            catch (Exception exp)
            {
            }
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
            try
            {
                SetPort();
                btn_start.Visible = false;
                btn_stop.Visible = true;
                _serialPort.Open();
            }
            catch (Exception exp)
            {
                btn_stop.PerformClick();
                txt_data.AppendText(exp.ToString() + "\r\n");
            }
        }
        private void btn_stop_Click(object sender, EventArgs e)
        {
                btn_start.Visible = true;
                btn_stop.Visible = false;
                _serialPort.Close();
        }
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_data.Clear();
            ClearChart(cht_data);
        }

    }
}
