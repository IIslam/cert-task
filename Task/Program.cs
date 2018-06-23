using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Task
{
    class Program
    {

        static void Main(string[] args)
        {
            bool exit = false;
            string[] values = new string[2];
            Process alpha;
            Process counter;
            Process re;
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
                Console.WriteLine(e.Data);
            });

            alpha = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "Alpha.exe",
                    Arguments = "",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            alpha.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                values[0] = e.Data;
                Console.WriteLine(e.Data);
            });
            counter = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "counter.exe",
                    Arguments = "",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            counter.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                values[1] = e.Data;
                Console.WriteLine(e.Data);
            });

            re = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = "re.exe",
                    Arguments = "",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            re.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
            {
                if (e.Data == "RESTART")
                {
                    counter.CancelOutputRead();
                    counter.Kill();
                    counter.Start();
                    counter.BeginOutputReadLine();
                    alpha.CancelOutputRead();
                    alpha.Kill();
                    alpha.Start();
                    alpha.BeginOutputReadLine();
                }
            });

            alpha.Start();
            alpha.BeginOutputReadLine();
            counter.Start();
            counter.BeginOutputReadLine();
            re.Start();
            re.BeginOutputReadLine();

            Timer timer = new Timer(30 * 1000);
            timer.Elapsed += new ElapsedEventHandler((sender, e) =>
            {
                re.Kill();
                counter.Kill();
                alpha.Kill();
                Console.WriteLine(values[0] + "\t" + values[1]);
                exit = true;
            });
            timer.Start();
            while (!exit)
            {

            }
            timer.Stop();
            re.Dispose();
            counter.Dispose();
            alpha.Dispose();
            timer.Dispose();
            Console.ReadLine();

        }
    }
}
