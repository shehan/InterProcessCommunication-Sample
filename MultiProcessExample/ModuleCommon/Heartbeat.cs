using System.IO;
using System.IO.Pipes;
using System.Timers;

namespace ModuleCommon
{
    public abstract class Heartbeat
    {
        private static string _parentProcessId;
        private static string _module;
        private static NamedPipeClientStream _pipeStream;
        private static StreamWriter _streamWriter;

        public static void StartBeating(string parentPocessId, string module)
        {
            _parentProcessId = parentPocessId;
            _module = module;

            var timer = new Timer {Interval = 1000};
            timer.Elapsed += Timer_Elapsed;
            timer.Enabled = true;
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_pipeStream == null)
            {
                _pipeStream = new NamedPipeClientStream("PipeTo" + _parentProcessId);
                _pipeStream.Connect();
                _streamWriter = new StreamWriter(_pipeStream);
            }

            _streamWriter.AutoFlush = true;
            _streamWriter.WriteLine($"{_module};Alive");
        }
    }
}