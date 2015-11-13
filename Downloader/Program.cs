using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Downloader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string Url = "http://www.sfstats.net/hockey/leagues/2_Extraleague/2005-2006/allresults";
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();

            File.WriteAllText("../../../result.html", result, Encoding.UTF8);
        }
    }
}
