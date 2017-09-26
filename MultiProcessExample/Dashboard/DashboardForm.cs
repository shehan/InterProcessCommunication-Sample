using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class DashboardForm : Form
    {
        private List<Process> _processList;
        private Dictionary<string, bool> _modules;

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            _processList = new List<Process>();
            _modules = new Dictionary<string, bool>();
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            string[] modules = {@"Modules\ModuleA", @"Modules\ModuleB", @"Modules\ModuleC"};
                     

            foreach (var p in modules)
            {
                //Create pipe
                var pipedServerThread = new Thread(StartServerListner);
                pipedServerThread.Start();

                //Launch modules as child processes
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = p,
                    Arguments = Process.GetCurrentProcess().Id.ToString()
                };
                var process = Process.Start(processStartInfo);

                _processList.Add(process);

                UpdateLog($"Process spawned: {p} (Id: {process.Id})");
            }


        }

        private void buttonTerminate_Click(object sender, EventArgs e)
        {
            foreach (var process in _processList)
                if(!process.HasExited)
                    process.Kill();

            _processList = new List<Process>();
            _modules = new Dictionary<string, bool>();
        }

        private void StartServerListner()
        {
            string module=string.Empty;
            using (var pipeStream =
                new NamedPipeServerStream("PipeTo" + Process.GetCurrentProcess().Id, PipeDirection.InOut, 10))
            {

                Console.WriteLine("[Server] Pipe Created, the current process ID is {0}",
                    Process.GetCurrentProcess().Id);

                //wait for a connection from another process
                pipeStream.WaitForConnection();
                Console.WriteLine("[Server] Pipe connection established");

                using (var sr = new StreamReader(pipeStream))
                {
                    string message;
                    //wait for message to arrive from the pipe, when message arrive print date/time and the message to the console.
                    while ((message = sr.ReadLine()) != null)
                    {
                        module = message.Split(';')[0];
                        if (!_modules.ContainsKey(module))
                        {
                            _modules.Add(module,true);
                            UpdateLog("Connection Established: " + module);
                        }
                    }
                        Console.WriteLine("{0}: {1}", DateTime.Now, message);
                }
            }

            UpdateLog("Connection Lost: " + module);

        }

        private void UpdateLog(string text)
        {
            if (this.textBoxHeartbeatLog.InvokeRequired)
            {
                UpdateLogCallback callback = new UpdateLogCallback(UpdateLog);
                this.Invoke(callback, new object[] { text });
            }
            else
            {
                textBoxHeartbeatLog.Text = textBoxHeartbeatLog.Text + Environment.NewLine + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + " " + text;
            }
        }

        delegate void UpdateLogCallback(string text);

    }
}