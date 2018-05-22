using log4net;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Log4NetDemo
{
    class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            Logger.Info("Hello World!");

            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 10; i++)
            {
               tasks.Add(Task.Factory.StartNew(() => DelayedLog(string.Format("Log {0}", i))));
            }

            Task.WhenAll(tasks);

            Console.ReadLine();
        }

        public static async Task DelayedLog(string message)
        {
            await Task.Run(() => DoStuff());

            Logger.Info(message);
        }

        public static void DoStuff()
        {
            for (int i = 0; i < Int32.MaxValue; i++)
            {
                // Do stuff
            }
        }
    }
}
