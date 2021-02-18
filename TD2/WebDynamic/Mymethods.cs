using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace WebDynamic
{
    class Mymethods
    {
        public string MyMethod(string param1, string param2)
        {
            return "<HTML><BODY> Hello " + param1 + " et " + param2 + "</BODY></HTML>";
        }
        public string ExecTest(string param1, string param2)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = @"C:\Users\user\Documents\GitHub\eiin839\TD2\ExeTest\bin\Debug\ExeTest.exe";
            start.Arguments = param1 + " " + param2;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
          
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);
                    return result;
                }
            }
        }

        public string Incr(string param1, string param2)
        {
            int val = int.Parse(param1) + 1;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("{ \"val\": ");
            stringBuilder.Append(val.ToString());
            stringBuilder.Append(",");
            stringBuilder.Append("\"success\": true");
            stringBuilder.Append(" }");
            return stringBuilder.ToString();
        }
    }
}
