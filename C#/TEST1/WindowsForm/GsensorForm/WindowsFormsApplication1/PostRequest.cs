using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;


namespace WindowsFormsApplication1
{
    abstract class PostRequest
    {
        static public void PostData(double inData)
        {
            try
            {
                JObject jsonData = new JObject();
                jsonData.Add("message", inData.ToString());

                string url = "http://localhost:8080/HumanDetector/log";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonData.ToString());
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch (Exception exp)
            {
            }
            
        }
    }
}
