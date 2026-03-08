using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceOOP.ECommerceOOP.Domain.Logging
{
    internal class ConsoleLogger : ILogger
    {
        public void Error(string message)
        {
            Console.WriteLine($"[ERROR] {message}");
        }

        public void Info(string message)
        {
            Console.WriteLine($"[INFO] {message}");
        }

        public void Warn(string message)
        {
            Console.WriteLine($"[WARN] {message}");
        }
    }
}
