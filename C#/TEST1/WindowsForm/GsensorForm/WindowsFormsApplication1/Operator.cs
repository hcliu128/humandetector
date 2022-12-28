using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json.Linq;

namespace WindowsFormsApplication1
{
    abstract class Operator
    {
        static private int TimeCount = 0;
        
        static public void WriteRawDataSafe(TextBox myTextBox, JObject jsonData) //原始字串->左側textBox
        {
            //根據C#官方文件:
            //https://docs.microsoft.com/zh-tw/dotnet/desktop/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls?view=netframeworkdesktop-4.8 
            //要跨執行緒控制視窗控制項需要用Invoke搭配委派的方式來達成
            Action safeAction = delegate
            {
                if(double.Parse(jsonData["message"].ToString()) == 1)
                    myTextBox.AppendText(jsonData.ToString() + "\r\n" + "偵測有人經過" +"\r\n");
                else
                    myTextBox.AppendText(jsonData.ToString() + "\r\n");
            };
            myTextBox.Invoke(safeAction);
        }
        static public void RefreshChartSafe(Chart myChart, double Data) //角度圖->右上Chart
        {
            Action safeAction = delegate
            {
                int Count = myChart.Series[0].Points.Count;
                myChart.Series[0].Points.AddXY(Count, Data);
                if (Count > 100)
                {
                    myChart.ChartAreas[0].AxisX.ScaleView.Position = Count - 100; //將時序圖顯示範圍維持在最新點處
                }
                new Thread(new ThreadStart(delegate { PostRequest.PostData(Data); })).Start();
            };
            myChart.Invoke(safeAction);
        }
        static public void WarningPicture(PictureBox PicBox, double humanData)
        {
            Action safeAction = delegate
            {
                if (humanData == 1)
                    PicBox.Visible = true;
                else
                    PicBox.Visible = false;
            };
            PicBox.Invoke(safeAction);
        }

    }
}
