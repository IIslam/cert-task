using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Processes
{
    public class Alpha :MyProcess
    {

        public Alpha()
        {
            _startInfo = new ProcessStartInfo()
            {
                FileName = "Alpha.exe",
                Arguments = "",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
        }
    }
}
