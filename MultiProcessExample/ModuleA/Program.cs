using System;
using ModuleCommon;

namespace ModuleA
{
    internal class Program : Heartbeat
    {
        private static void Main(string[] args)
        {
            if (args != null)
                StartBeating(args[0], "A");

            Console.ReadLine();
        }
    }
}