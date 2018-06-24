using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Processes
{
    public abstract class MyProcess
    {
        protected ProcessStartInfo _startInfo;
        protected Process _currentProcess;
        protected DataReceivedEventHandler _currentDataRecievedHandler;
        public virtual void Start(DataReceivedEventHandler dataReceivedHandler)
        {
            _currentProcess = new Process()
            {
                StartInfo = _startInfo
            };
            _currentDataRecievedHandler = dataReceivedHandler;
            _currentProcess.OutputDataReceived += dataReceivedHandler;
            _currentProcess.Start();
            _currentProcess.BeginOutputReadLine();
        }
        public virtual void Stop()
        {
            _currentProcess.OutputDataReceived -= _currentDataRecievedHandler;
            _currentProcess.Kill();
            _currentProcess.Dispose();
            _currentDataRecievedHandler = null;
        }
        public virtual void Restart()
        {
            var dataRecievedHandler = _currentDataRecievedHandler;
            this.Stop();
            this.Start(dataRecievedHandler);
        }
    }
}
