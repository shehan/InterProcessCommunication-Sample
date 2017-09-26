using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Timers;
using ModuleCommon;

namespace ModuleA
{
    internal class Program : Heartbeat
    {
        private static void Main(string[] args)
        {
            if (args != null)
                StartBeating(args[0], "A");

            var crashTimer = new Timer {Interval = 3000};
            crashTimer.Elapsed += CrashTimer_Elapsed;
            crashTimer.Enabled = true;

            Console.ReadLine();
        }

        private static void CrashTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var random = new Random();
                var randomNumber = random.Next(0, 3);
                randomNumber = 100 / randomNumber;
            }
            catch (Exception ex)
            {
                Process.GetCurrentProcess().Kill();
            }
        }
    }
}