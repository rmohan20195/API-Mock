using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace capredv2.backend.console.processor.TopShelf
{
    public static class TopShelfLogs
    {
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine($"Message  :{logMessage}");
            w.WriteLine("-------------------------------");
        }
    }
}
