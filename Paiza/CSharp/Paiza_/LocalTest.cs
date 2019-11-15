using System;

namespace LocalTest
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
                Paiza_.MainClass.Main();
                sw.Stop();
                Console.WriteLine($"{sw.Elapsed}");
                Console.WriteLine($"*** END {cnt}   ***");
            }

        }

    }
}
