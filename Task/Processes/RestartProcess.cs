using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Processes
{
    public class RestartProcess : MyProcess
    {
        public RestartProcess()
        {
            _startInfo = new ProcessStartInfo()
            {
                FileName = "re.exe",
                Arguments = "",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
        }
    }
}
