using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace MangaReadAndDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            CurenDevice cdir = new CurenDevice();//Does Stuff
            cdir.CD = Environment.CurrentDirectory;
            cdir.MaName = Environment.MachineName;
            cdir.PCC = Environment.ProcessorCount;
            cdir.Dmin = Environment.UserDomainName;
            cdir.NameU = Environment.UserName;
            cdir.IA = Environment.UserInteractive;
            Ping pingReq = new Ping();
            try
            {
                PingReply pirpy = pingReq.Send("www.google.de");
                if (pirpy == null)
                { cdir.prxy = false; };

                cdir.prxy = (pirpy.Status != IPStatus.Success);

            }
            catch (PingException pie)
            {
                cdir.prxy = true;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("CurrentDirectory: " +
                cdir.CD);
            sb.Append("\r\n");
            sb.Append("Devicename: " +
                cdir.MaName);
            sb.Append("\r\n");
            sb.Append("ProzessorCount: " +
                cdir.PCC);
            sb.Append("\r\n");
            sb.Append("CurrentDomain: " +
                cdir.Dmin);
            sb.Append("\r\n");
            sb.Append("User :" +
                cdir.NameU);
            sb.Append("\r\n");
            sb.Append("This.IsAktive: " +
                cdir.IA);
            sb.Append("\r\n");
            sb.Append("Proxy is: " + (cdir.prxy ? "Aktive" : "Not Aktive"));

            Console.WriteLine(sb.ToString());//SET
            Console.ReadKey();
        }
    }
}
