using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication2
{
    abstract class Operator
    {
        static public void WriteRawDataSafe(TextBox myTextBox, List<string> Data) //原始字串->左側textBox
        {
            //根據C#官方文件:
            //https://docs.microsoft.com/zh-tw/dotnet/desktop/winforms/controls/how-to-make-thread-safe-calls-to-windows-forms-controls?view=netframeworkdesktop-4.8 
            //要跨執行緒控制視窗控制項需要用Invoke搭配委派的方式來達成
            Action safeAction = delegate
            {
                try
                {
                    myTextBox.AppendText("mseeage = " + Data[0]  + "\r\n");
                }
                catch (Exception exp)
                {
                }
            };
            myTextBox.Invoke(safeAction);
        }

        static public void RefreshChartSafe(Chart myChart, List<double> Data) //角度圖->右上Chart
        {
            Action safeAction = delegate
            {
                int Count = myChart.Series[0].Points.Count;
                for (int index = 0; index < Data.Count(); index++)
                {
                    myChart.Series[index].Points.AddXY(Count, Data[index]);
                }
                if (Count > 100)
                {
                    myChart.ChartAreas[0].AxisX.ScaleView.Position = Count - 100; //將時序圖顯示範圍維持在最新點處
                }
            };
            myChart.Invoke(safeAction);
        }
        
    }
}
