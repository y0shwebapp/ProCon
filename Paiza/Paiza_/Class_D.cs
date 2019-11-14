using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paiza_
{
    #region "format"
    static class Class_D_Main
    {
        public static void Execute()
        {
            string result = string.Empty;

            System.Console.WriteLine(result);
        }
    }
    #endregion

    #region "D007:N倍の文字列"
    static class Class_D_007
    {
        public static void Execute(string line)
        {
            string result = string.Empty;
            for (int i = 0; i < int.Parse(line); ++i)
            {
                result += "*";

            }

            Console.WriteLine(result);
        }
    }
    #endregion

    #region "format"
    //static class Class_D_format
    //{
    //    public static void Execute()
    //    {
    //        string result = string.Empty;


    //        Console.WriteLine(result);
    //    }
    //}
    #endregion

    #region "D029:サイコロの裏面"
    static class Class_D_D029
    {
        public static void Execute()
        {
            string result = string.Empty;
            int num = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine($"{7 - num}");
        }
    }
    #endregion

    #region "D046:不思議なタマゴ"
    static class Class_D_D046
    {
        public static void Execute()
        {
            var result = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToList();

            Console.WriteLine(result.Max());
        }
    }
    #endregion

    #region "D048:台風の間隔"
    static class Class_D_D048
    {
        public static void Execute()
        {
            int N = int.Parse(Console.ReadLine().Trim());
            int n;
            for (int i = 0; i < 4; ++i)
            {
                n = int.Parse(Console.ReadLine().Trim());
                Console.WriteLine($"{n - N}");
                N = n;
            }

        }
    }
    #endregion

    #region "D049:◯◯の秋"
    static class Class_D_D049
    {
        public static void Execute()
        {
            string conv = "noaki";
            string s = Console.ReadLine().Trim();

            Console.WriteLine(s.Replace(conv, ""));
        }
    }
    #endregion

    #region "D050:お月見だんご"
    static class Class_D_D050
    {
        public static void Execute()
        {
            List<int> list = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            int cnt = 0;
            foreach (var item in list)
            {
                cnt += (item > 5) ? 5 : item;
            }

            Console.WriteLine(cnt);
        }
    }
    #endregion

    #region "D051:衣替え"
    static class Class_D_D051
    {
        public static void Execute()
        {
            List<string> list = Console.ReadLine().Trim().Split(' ').ToList();
            string result = (Convert.ToDecimal(list.Count) / 2 <= list.Where(s => s == "W").Count() ? "OK" : "NG");


            Console.WriteLine(result);
        }
    }
    #endregion

    #region "D052:ピラミッドの作り方"
    static class Class_D_D052
    {
        public static void Execute()
        {
            int n = int.Parse(Console.ReadLine().Trim());
            int cnt = 0;
            for (int i = 1; i <= n; ++i)
            {
                cnt += i;
            }


            Console.WriteLine(cnt);
        }
    }
    #endregion

    #region "D053:トリック・オア・トリート"
    static class Class_D_D053
    {
        public static void Execute()
        {
            string line1 = Console.ReadLine().Trim();
            switch (line1)
            {
                case "chocolate":
                case "candy":
                    Console.WriteLine("Thanks!");
                    break;
                default:
                    Console.WriteLine("No!");
                    break;
            }


        }
    }
    #endregion

    #region "D054:11/11"
    static class Class_D_D054
    {
        public static void Execute()
        {
            var line = Console.ReadLine().Trim();


            Console.WriteLine((line.Length >= 11) ? "OK" : $"{11 - line.Length}");
        }
    }
    #endregion

    #region "D055:ワインのキャッチコピー"
    static class Class_D_D055
    {
        public static void Execute()
        {
            string result = Console.ReadLine().Trim();


            Console.WriteLine($"Best in {result}");
        }
    }
    #endregion

    #region "D056:かまくらづくり"
    static class Class_D_D056
    {
        public static void Execute()
        {
            int[] line = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            int result = Convert.ToInt32(Math.Pow(line[0], 3) - Math.Pow(line[1], 3));


            Console.WriteLine(result);
        }
    }
    #endregion

    #region "D057:プレゼント選び"
    static class Class_D_D057
    {
        public static void Execute()
        {
            var 成績 = int.Parse(Console.ReadLine().Trim());
            var List = Console.ReadLine().Trim().Split(' ').ToList();



            Console.WriteLine(List[成績 - 1]);
        }
    }
    #endregion

    #region "D058:初詣で"
    static class Class_D_D058
    {
        public static void Execute()
        {
            var list = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            StringBuilder result = new StringBuilder();
            int cnt = 0;
            foreach (var item in list)
            {
                string s = (++cnt == 2) ? "B" : "A";
                for (int i = 0; i < item; ++i)
                {
                    result.Append(s);
                }
            }

            Console.WriteLine(result);
        }
    }
    #endregion

    #region "D059:トランプ占い"
    static class Class_D_D059
    {
        public static void Execute()
        {
            List<string> card = Console.ReadLine().Trim().Split(' ').ToList();

            if (card.Where(s => s == "J").Count() == 2)
            {
                card[1] = "Q";
            }

            Console.WriteLine(string.Join(" ", card));
        }
    }
    #endregion

    #region "D060:AボタンとBボタン"
    static class Class_D_D060
    {
        public static void Execute()
        {
            int[] line = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToArray();

            Console.WriteLine((line[0] - line[1]));
        }
    }
    #endregion

    #region "D061:3倍返し？"
    static class Class_D_D061
    {
        public static void Execute()
        {
            int n = int.Parse(Console.ReadLine());
            int r = 0;

            if (n == 0)
            {
                r = 1;
            }
            else
            {
                r = n * 3;
            }

            Console.WriteLine(r.ToString());
        }
    }
    #endregion

    #region " D062:ひな祭り "
    static class Class_D_D062
    {
        public static void Execute(string line)
        {
            List<string> list = line.Split(' ').ToList<string>();
            List<string> ひな壇 = new List<string>();

            Queue<string> 人形q = Init雛人形リスト();
            foreach (var item in list)
            {
                int n = int.Parse(item);
                string 雛人形列 = string.Empty;

                for (int i = 0; i < n; ++i)
                {
                    雛人形列 = 雛人形列 + 人形q.Dequeue();
                }

                ひな壇.Add(雛人形列);
            }

            foreach (var item in ひな壇)
            {
                Console.WriteLine(item);
            }
        }

        static Queue<string> Init雛人形リスト()
        {
            Queue<string> 人形q = new Queue<string>();
            人形q.Enqueue("A");
            人形q.Enqueue("B");
            人形q.Enqueue("C");
            人形q.Enqueue("D");
            人形q.Enqueue("E");
            人形q.Enqueue("F");
            人形q.Enqueue("G");
            人形q.Enqueue("H");
            人形q.Enqueue("I");
            人形q.Enqueue("J");

            return 人形q;
        }
    }
    #endregion

    #region "D063:お花見の場所取り 70点"
    static class Class_D_D063
    {
        public static void Execute(string line)
        {
            List<string> list = line.Split(' ').ToList<string>();

            int Me = int.Parse(Console.ReadLine().Trim());

            int cnt = 1;
            foreach (string row in list.OrderBy(n => n))
            {
                if (int.Parse(row) > Me)
                {
                    break;
                }
                cnt++;
            }

            Console.WriteLine(cnt.ToString());
        }
    }
    #endregion

    #region "D064:嘘つきの日"
    static class Class_D_D064
    {
        public static void Execute(string line)
        {
            string result = string.Empty;


            Console.WriteLine(line.Replace("False", "True"));
        }
    }
    #endregion

    #region "D065:エラーコードの分類"
    static class Class_D_D065
    {
        public static void Execute(string line)
        {
            string result = string.Empty;
            switch (line.Trim().Substring(0, 1))
            {
                case "2":
                    result = "ok";
                    break;
                case "4":
                    result = "error";
                    break;
                default:
                    result = "unknown";
                    break;
            }


            Console.WriteLine(result);
        }
    }
    #endregion

    #region "D067:スイッチのオンオフ"
    static class Class_D_067
    {
        public static void Execute(string line)
        {
            string result = string.Empty;
            int n = int.Parse(line);
            if (n % 2 == 0)
            {
                result = "OFF";
            }
            else
            {
                result = "ON";
            }


            Console.WriteLine(result);
        }
    }
    #endregion

    #region "D068:雨と晴れの記録"
    static class Class_D_D068
    {
        public static void Execute()
        {
            int n = int.Parse(Console.ReadLine());
            char[] s = Console.ReadLine().ToArray();
            int S = s.Where(c => c == 'S').Count();
            int R = s.Where(c => c == 'R').Count();


            Console.WriteLine($"{S} {R}");
        }
    }
    #endregion

    #region "D114:税込の価格"
    static class Class_D_D114
    {
        public static void Execute()
        {
            var n = System.Console.ReadLine().Split(' ');
            int par = int.Parse(n[0]);
            int price = int.Parse(n[1]);

            System.Console.WriteLine(price + System.Math.Floor(price * (par * 0.01)));
        }
    }
    #endregion

    #region "D098:ボーナスの計算"
    static class Class_D_D098
    {
        public static void Execute()
        {
            string[] i = System.Console.ReadLine().Split(' ');
            System.Console.WriteLine(int.Parse(i[0]) * int.Parse(i[1]));
        }
    }
    #endregion

    #region "format"
    static class Class_D_138
    {
        public static void Execute()
        {
            int[] nw = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var lst = new List<string>();
            for (int i = 1; i <= nw[1]; i++)
            {
                lst.Add(Console.ReadLine());
            }
            foreach (string item in lst)
            {
                Console.WriteLine(item);
            }
        }
    }
    #endregion

    #region "format"
    static class Class_D_139
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] l = Console.ReadLine().Split();
            int cntG = l.Where(s => s == "G").Count();
            int cntP = l.Where(s => s == "P").Count();
            string ret = "Draw";
            if (cntG != 0 && cntG < cntP) { ret = "G"; }
            if (cntP != 0 && cntG > cntP) { ret = "P"; }
            Console.WriteLine(ret);
        }
    }
    #endregion

}
