using System;
using System.IO;
using System.Net;

namespace SimpleRESTReader
{
    class Program
    {
        static void Main(string[] args)
        {

            string streznik = "https://localhost:44359",
                dolzina = "600",
                sirina = "50",
                radius = "5",
                razMedSos = "3",
                razMedStran = "2";

            if(args.Length == 5)
            {
                dolzina = args[0];
                sirina = args[1];
                radius = args[2];
                razMedSos = args[3];
                razMedStran = args[4];
            }
            else if (args.Length == 6)
            {
                streznik = args[0];
                dolzina = args[1];
                sirina = args[2];
                radius = args[3];
                razMedSos = args[4];
                razMedStran = args[5];
            }

            string url = string.Format("{0}/api/izsekaj/{1},{2},{3},{4},{5}", streznik, dolzina, sirina, radius, razMedSos, razMedStran);

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "GET";
            req.Credentials = CredentialCache.DefaultCredentials;
            req.Accept = "application/json;odata=verbose";

            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            {
                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    //MessageBox.Show(resp.ToString());
                    using (Stream dataStream = resp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(dataStream);
                        string respFromSrv = reader.ReadToEnd();

                        Console.WriteLine(respFromSrv);
                    }
                }
            }
        }
    }
}
