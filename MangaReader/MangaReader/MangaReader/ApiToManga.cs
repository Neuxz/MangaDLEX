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
        {//https://developer.xamarin.com/guides/cross-platform/application_fundamentals/building_cross_platform_applications/part_4_-_platform_divergence_abstraction_divergent_implementation/
            string device = "UNKNOWN";
            #if __IOS__
            device = "IOS";
            #endif
            #if __ANDROID__
            device = "ANDROID";
            #endif
            if (thisObject == null)
            {
                thisObject = new ApiToManga(DeviceName);
                return thisObject;
            }
            return thisObject;
        }


        public bool Connect(String IP, bool login)
        {
            bool canConnect = false;
            string[] onoroff = login ? ApiCommands._LOGON_ : ApiCommands._LOGOFF_;
            HttpWebRequest myRequest =
                 (HttpWebRequest)WebRequest.Create(IP + onoroff[0] + DeviceName + onoroff[1]);
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
        private static class ApiCommands
        {
            public static readonly string[] _LOGON_ = { "/LogIn&?=", "=true" };
            public static readonly string[] _LOGOFF_ = { "/LogIn&?=", "=false" };
            public static readonly string _LOCALINVENTORY_ = "/GetIndex?=";
            public static readonly string[] _MANGAINFO_ = { "/GetInfo?=", "=" };
            public static readonly string[] _MANGAIMAGE_ = { "/GetInfo?=", "=", "&C", "&p" };
        }
    }
}
