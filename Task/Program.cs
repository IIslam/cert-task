using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Task.Processes;

namespace Task
{
    class Program
    {

        static void Main(string[] args)
        {
            bool exit = false;
            string[] values = new string[3];
            Alpha alpha = new Alpha();
            Counter counter = new Counter();
            RestartProcess restart = new RestartProcess();
            DataReceivedEventHandler alphaDataReceivedtHandler = new DataReceivedEventHandler((sender, e) =>
            {
                values[0] = e.Data;
                Console.WriteLine(e.Data);
            });
            DataReceivedEventHandler counterDataReceivedtHandler = new DataReceivedEventHandler((sender, e) =>
            {
                values[1] = e.Data;
                Console.WriteLine(e.Data);
            });
            DataReceivedEventHandler restartDataReceivedtHandler = new DataReceivedEventHandler((sender, e) =>
            {
                values[2] = e.Data;
                if(values[2] == "RESTART")
                {
                    alpha.Restart();
                    counter.Restart();
                }
                Console.WriteLine(e.Data);
            });
            alpha.Start(alphaDataReceivedtHandler);
            counter.Start(alphaDataReceivedtHandler);
            restart.Start(restartDataReceivedtHandler);
            Timer timer = new Timer(30 * 1000);
            timer.Elapsed += new ElapsedEventHandler((sender, e) =>
            {
                restart.Stop();
                counter.Stop();
                alpha.Stop();
                Console.WriteLine(values[0] + "\t" + values[1]);
                exit = true;
            });
            timer.Start();
            while (!exit)
            {

            }
            timer.Stop();
            timer.Dispose();
        }
    }
}
