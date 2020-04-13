using System;
using ReportPortal.Shared;

namespace SeleniumFramework.Helpers
{
    public class Report
    {
        public static void WriteLog(string message)
        {
            Log.Info(message);
            //Console.WriteLine(message);
        }
    }
}
