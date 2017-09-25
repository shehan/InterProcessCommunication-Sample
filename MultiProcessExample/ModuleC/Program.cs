using System;
using System.Timers;
using ModuleCommon;

namespace ModuleC
{
    internal class Program : Heartbeat
    {

        private static void Main(string[] args)
        {
            if (args != null)
                StartBeating(args[0], "C");

            Console.ReadLine();
        }
    }
}