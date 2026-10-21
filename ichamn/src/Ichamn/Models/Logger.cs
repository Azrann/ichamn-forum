using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Ichamn.Models
{
    public static class Logger
    {
        private static readonly object MyLock = new object();
        public static void Log(string p_message)
        {
            return;
            lock (MyLock)
            {
                if (!File.Exists(@"C:\Logs\log.txt"))
                {
                    var vs = File.Create(@"C:\Logs\log.txt");
                    vs.Close();
                }
                using (var writer = new StreamWriter(@"C:\Logs\log.txt",true))
                {
                    writer.WriteLine(String.Format("{0:d/M/yyyy HH:mm:ss} : {1}", DateTime.Now, p_message));
                }
            }
        }
    }
}