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

        public DashboardForm()
        {
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToShortDateString();
            _processList = new List<Process>();
        }

        private void buttonLaunch_Click(object sender, EventArgs e)
        {
            string[] modules = {@"Modules\ModuleA", @"Modules\ModuleB", @"Modules\ModuleC"};
            //string[] modules = { @"Modules\ModuleA" };

            foreach (var p in modules)
            {
                var processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = p;
                processStartInfo.Arguments = Process.GetCurrentProcess().Id.ToString();
                var process = Process.Start(processStartInfo);
                _processList.Add(process);
                textBoxProcess.Text = textBoxProcess.Text + Environment.NewLine + p + " : " + process.Id;
            }

            var RecieverThread = new Thread(StartServerListner);
            RecieverThread.Start();
        }

        private void buttonTerminate_Click(object sender, EventArgs e)
        {
            foreach (var process in _processList)
                if(!process.HasExited)
                    process.Kill();

            _processList = new List<Process>();
        }


        private void StartServerListner()
        {
            using (var pipeStream = new NamedPipeServerStream("PipeTo" + Process.GetCurrentProcess().Id))
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
                        Console.WriteLine("{0}: {1}", DateTime.Now, message);
                }
            }
            Console.WriteLine("Connection lost");
        }
    }
}