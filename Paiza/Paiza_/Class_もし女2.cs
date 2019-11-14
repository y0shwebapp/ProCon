using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paiza_
{
    #region "format"
    static class Class_もし女_format
    {
        public static void Execute()
        {
            string result = string.Empty;


            Console.WriteLine(result);
        }
    }
    #endregion

    #region "桂乃梨子とピンチを乗り越えろ　(Cランク問題)"
    static class Class_もし女_6
    {
        public static void Execute()
        {
            int N = int.Parse(Console.ReadLine());
            int[] line1 = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            int[] line2 = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

            int[][] result = new int[N][];
            for (int i = 0;i < N; ++i)
            {
                result[i] = new int[N];
                for (int j = 0;j < N; ++j)
                {
                    result[i][j] = line1[j] + line2[i];
                }
            }
            foreach(var item in result)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
    }
    #endregion

    #region "六村リオの緊急事態　(Bランク問題)"
    static class Class_もし女_8
    {
        public static void Execute()
        {
            string[] line = Console.ReadLine().Trim().Split(' ');
            Stack<string> l = new Stack<string>();
            foreach (var item in line[0].Split('/'))
            {
                if (item == "") { continue; }
                l.Push(item);
            }

            Queue<string> path = new Queue<string>();
            foreach (var item in line[1].Split('/'))
            {
                if (item == "") { continue; }
                path.Enqueue(item);
            }

            while(path.Count > 0)
            {
                var item = path.Dequeue();
                switch (item)
                {
                    case "..":
                        if ( l.Count() > 0)
                        {
                            l.Pop();
                        }
                        break;
                    case ".":
                        break;
                    default:
                        l.Push(item);
                        break;
                }
            }

            string ans = "/";
            if (l.Count() > 0) { ans += string.Join("/", l.Reverse()); }

            Console.WriteLine(ans);
        }
    }
    #endregion

    #region "緑川つばめを窮地から救え　(Bランク問題)"
    static class Class_もし女_9
    {
        public static void Execute()
        {
            List<int> l = Console.ReadLine().ToCharArray().Select(s => int.Parse(s.ToString())).ToList();
            l.Reverse();

            for (int i = 0;i < l.Count(); ++i)
            {
                if (l[i] >= 5)
                {
                    for (int j = i; j >= 0; --j)
                    {
                        l[j] = 0;
                    }
                    if (i + 1 == l.Count())
                    {
                        l.Add(1);
                    }
                    else
                    {
                        l[i + 1] += 1;
                    }
                }
            }
            l.Reverse();
            Console.WriteLine(string.Join("",l));
        }
    }
    #endregion

}

