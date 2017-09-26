using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class DashboardForm : Form
    {
        private Dictionary<string,Process> _processList;
        private Dictionary<string, bool> _modules;
        private bool _forceTerminate=false;

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            _processList = new Dictionary<string, Process>();
            _modules = new Dictionary<string, bool>();
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            string[] modules = {@"Modules\ModuleA", @"Modules\ModuleB", @"Modules\ModuleC"};
                             
            foreach (var p in modules)
            {
                var id = SpawnProcess(p);
                UpdateLog($"Process spawned: {p} (Id: {id})",Color.DodgerBlue);
            }
        }

        private int SpawnProcess(string file)
        {
            //Create pipe
            var pipedServerThread = new Thread(StartServerListner);
            pipedServerThread.Start();

            //Launch modules as child processes
            var processStartInfo = new ProcessStartInfo
            {
                FileName = file,
                Arguments = Process.GetCurrentProcess().Id.ToString()
            };
            var process = Process.Start(processStartInfo);

            _processList.Add(file,process);
            return process.Id;
        }

        private void buttonTerminate_Click(object sender, EventArgs e)
        {
            _forceTerminate = true;
            foreach (var process in _processList.Values)           
                if(!process.HasExited)
                    process.Kill();

            _processList = new Dictionary<string, Process>();
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
                            UpdateLog("Connection Established: " + module,Color.DarkCyan);
                        }
                    }
                        Console.WriteLine("{0}: {1}", DateTime.Now, message);
                }
            }

            UpdateLog("Connection Lost: " + module,Color.Red);
            ReSpawn(module);

        }

        private void ReSpawn(string module)
        {
            if (_forceTerminate)
                return;

            var process = $@"Modules\Module{module}";
            _modules.Remove(module);
            _processList.Remove(process);

            var id = SpawnProcess(process);
            UpdateLog($"Process re-spawned: {process} (Id: {id})",Color.DarkOrange);
        }

        private void UpdateLog(string text,Color fontColor)
        {
            if (this.textBoxHeartbeatLog.InvokeRequired)
            {
                UpdateLogCallback callback = new UpdateLogCallback(UpdateLog);
                this.Invoke(callback, new object[] { text,fontColor });
            }
            else
            {
                textBoxHeartbeatLog.Focus();
                textBoxHeartbeatLog.SelectionColor = fontColor;
                textBoxHeartbeatLog.AppendText(Environment.NewLine + text);
            }
        }

        delegate void UpdateLogCallback(string text, Color fontColor);

    }
}