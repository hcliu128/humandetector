using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication2
{
    abstract class HttpRequest
    {
        static public List<string> GetData()
        {
            JObject jsonData = new JObject();
            List<string> Data = new List<string>();
            try
            {
                string url = "http://localhost:8080/HumanDetector/get";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    jsonData = JObject.Parse(result.Trim('[', ']'));

                    Data.Add(jsonData["message"].ToString());
                }
            }
            catch (Exception exp)
            {
            }
            return Data;
        }
    }
}
