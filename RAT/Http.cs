using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

namespace RAT
{
    class Http
    {
        public static string Get(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 1000000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string temp = readStream.ReadToEnd();
                response.Close();
                return temp;
            }
            catch { }
            return "";
        }

        public static string Post(string url, string param)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Timeout = 1000000;
                request.ContentLength = param.Length;

                StreamWriter sw = new StreamWriter(request.GetRequestStream());
                sw.Write(param);
                sw.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string temp = readStream.ReadToEnd();
                response.Close();
                return temp;
            }
            catch { }
            return "";
        }

        public static string Upload(string url, string file)
        {
            WebClient Client = new System.Net.WebClient();
            Client.Headers.Add("Content-Type", "binary/octet-stream");
            byte[] result = Client.UploadFile(url, "POST", file);
            string s = Encoding.UTF8.GetString(result, 0, result.Length);
            return s;
        }
    }
}
