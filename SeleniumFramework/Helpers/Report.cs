using System;
using static ReportPortal.Shared.Log;

namespace SeleniumFramework.Helpers
{
    public static class Report
    {
        public static void WriteLog(string message)
        {
            Info(message);
            Console.WriteLine(message);
        }
    }
}
