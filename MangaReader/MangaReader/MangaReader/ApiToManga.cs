using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MangaReader
{
    class ApiToManga
    {
        private static ApiToManga thisObject;
        private string DeviceName;

        private ApiToManga()
        {
            DeviceName = ("UnknownDevice");
        }
        private ApiToManga(string DeviceName)
        {
            this.DeviceName = DeviceName;
        }

        public static ApiToManga GetApiToManga(String DeviceName)
        {
            if(thisObject == null)
            {
                thisObject = new ApiToManga(DeviceName);
                return thisObject;
            }
            return thisObject;
        }

        public bool Connect(String IP)
        {
            bool canConnect = false;

            HttpWebRequest myRequest =
                 (HttpWebRequest)WebRequest.Create(IP + "/LogIn&?=" + DeviceName);
            Console.WriteLine(myRequest.GetResponse());
            try
            {
                canConnect = WebRequestStringResult(myRequest).Equals("Success");
            }
            catch(Exception ex)
            {
                canConnect = false;
            }


            return canConnect;
        }
        private string WebRequestStringResult(HttpWebRequest myRequest)
        {
            String returner = null;
            using (WebResponse response = myRequest.GetResponse())
            {
                Console.WriteLine(response.GetResponseStream());
                using (System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream()))
                {

                    returner = reader.ReadToEnd();
                }
            }
            return returner;
        }
    }
}
