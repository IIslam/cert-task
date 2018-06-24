using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Processes
{
    public class Counter : MyProcess
    {
        public Counter()
        {
            _startInfo = new ProcessStartInfo()
            {
                FileName = "Counter.exe",
                Arguments = "",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
        }
    }
}
