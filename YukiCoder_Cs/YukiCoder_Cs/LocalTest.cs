using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YukiCoder_Cs
{
    class LocalTest
    {
        static void Main(string[] args)
        {
            int cnt = 0;
            while (true)
            {
                Console.WriteLine($"*** START {++cnt} ***");
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                sw.Start();
                Program.Main();
                sw.Stop();
                Console.WriteLine($"{sw.Elapsed}");
                Console.WriteLine($"*** END {cnt}   ***");
            }

        }

    }
}
