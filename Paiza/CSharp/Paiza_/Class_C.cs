using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paiza_
{

    #region "format"
    static class Class_C_format
    {
        public static void Execute()
        {
            string result = string.Empty;
            var line = System.Console.ReadLine().Trim();
            
            System.Console.WriteLine(result);
        }
    }
    #endregion

    #region "問題05"
    static class Class_C_C005
    {
        public static void Execute(string line)
        {

            var N = Int32.Parse(line);
            string[] ip = new string[N];
            for (var i = 0; i < N; ++i)
            {
                ip[i] = System.Console.ReadLine().Trim();
            }

            foreach (string ln in ip)
            {
                string result = "True";
                string[] splt = ln.Split('.');
                try
                {
                    for (int i = 0; i < splt.Count(); ++i)
                    {
                        if (int.Parse(splt[i]) < 0)
                        {
                            result = "False";
                            break;
                        }
                        else if (int.Parse(splt[i]) > 255)
                        {
                            result = "False";
                            break;
                        }
                        else if (i > 4)
                        {
                            result = "False";
                            break;
                        }
                    }
                }
                catch
                {
                    result = "False";
                }

                Console.WriteLine(result);

            }
        }
    }
    #endregion

    #region "問題05_ver2"
    static class Class_C_C005_2
    {
        public static void Execute(string line)
        {
            int 回数 = int.Parse(line);
            List<string> list = new List<string>();

            for (int i = 0; i < 回数; ++i)
            {
                try
                {
                    string[] ip = Console.ReadLine().Trim().Split('.');
                    string result = "True";
                    if (ip.Count() != 4)
                    {
                        result = "False";
                    }
                    foreach (string str in ip)
                    {
                        if (int.Parse(str) > 255 || int.Parse(str) < 0)
                        {
                            result = "False";
                        }
                    }
                    list.Add(result);
                }
                catch
                {
                    list.Add("False");
                }
            }

            foreach (string str in list)
            {
                Console.WriteLine(str);
            }
        }
    }
    #endregion

    #region "C022:ローソク足"
    static class Class_C_C022
    {
        public static void Execute()
        {
            string result = string.Empty;
            var n = int.Parse(System.Console.ReadLine().Trim());
            int start = 0;
            int end = 0;
            int? min = null;
            int? max = null;
            for (int i = 0; i < n; i++)
            {
                var num = System.Console.ReadLine().Split(' ');
                if (i == 0) { start = int.Parse(num[0]); }
                if (i == n - 1) { end = int.Parse(num[1]); }
                if (max == null || int.Parse(num[2]) > max) { max = int.Parse(num[2]); }
                if (min == null || int.Parse(num[3]) < min) { min = int.Parse(num[3]); }
            }

            System.Console.WriteLine(string.Format("{0} {1} {2} {3}",start,end,max,min));
        }
    }
    #endregion

    #region "C024:ミニ・コンピュータ"
    static class Class_C_C024
    {
        public static void Execute()
        {
            var N = int.Parse(System.Console.ReadLine().Trim());
            int a = 0;
            int b = 0;
            for (int i = 0; i < N; ++i)
            {
                string[] line = Console.ReadLine().Split(' ');
                switch (line[0])
                {
                    case "SET":
                        if (line[1] == "1")
                        {
                            a = int.Parse(line[2]);
                        }
                        else
                        {
                            b = int.Parse(line[2]);
                        }
                        break;
                    case "ADD":
                        b = a + int.Parse(line[1]);
                        break;
                    case "SUB":
                        b = a - int.Parse(line[1]);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine($"{a} {b}");
        }
    }
    #endregion

    #region "C025:ファックスの用紙回収"
    static class Class_C_C025
    {
        public static void Execute()
        {
            var M = int.Parse(System.Console.ReadLine().Trim());
            var N = int.Parse(System.Console.ReadLine().Trim());
            Dictionary<int, int> list = new Dictionary<int, int>();

            for (int i = 0;i < N; ++i)
            {
                int[] line = System.Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToArray();
                if (list.ContainsKey(line[0]))
                {
                    list[line[0]] += line[2];
                }
                else
                {
                    list.Add(line[0], line[2]);
                }
                
            }

            int cnt = 0;
            foreach(var item in list)
            {
                cnt += (item.Value + M - 1) / M;
            }
            Console.WriteLine(cnt);
        }
    }
    #endregion

    #region "C026:ウサギと人参"
    static class Class_C_C026
    {
        public static void Execute()
        {
            string[] line = System.Console.ReadLine().Trim().Split(' ');
            int N = int.Parse(line[0]);
            int S = int.Parse(line[1]);
            int p = int.Parse(line[2]);

            Dictionary<int, int> list = new Dictionary<int, int>();
            for (int i = 0;i < N; ++i)
            {
                int[] line2 = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToArray();

                if (line2[1] >= S - p && line2[1] <= S + p)
                {
                    list.Add(i + 1, line2[0]);
                }

            }

            string ans;
            if (list.Count() == 0)
            {
                ans = "not found";
            }
            else
            {
                ans = list.OrderByDescending(o => o.Value).ThenBy(t => t.Key).Select(s => s.Key).First().ToString();
            }

            Console.WriteLine(ans);
        }
    }
    #endregion

    #region "C028:単語テストの採点"
    static class Class_C_C028
    {
        public static void Execute()
        {
            //string result = string.Empty;
            var n = int.Parse(System.Console.ReadLine().Trim());
            int point = 0;
            int errCnt = 0;

            for (int i = 0;i < n; ++i)
            {
                var line = Console.ReadLine().Trim().Split(' ');
                var q = line[0].ToCharArray();
                var a = line[1].ToCharArray();
                errCnt = 0;

                if (q.Length != a.Length) { continue; }
                for (int j = 0;j < q.Length; ++j)
                {
                    if(q[j] != a[j]) { ++errCnt; }
                }

                switch (errCnt)
                {
                    case 0:
                        point += 2;
                        break;
                    case 1:
                        point++;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(point);
        }
    }
    #endregion

    #region "C029:旅行の計画"
    static class Class_C_C029
    {
        public static void Execute()
        {
            int[] line = System.Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            int M = line[0];    // 連休日数
            int N = line[1];    // 旅行日数
            Dictionary<int, int> 日程 = new Dictionary<int, int>();   //0:日付 1:降水確率
            for (int i = 0;i < M; ++i)
            {
                int[] line2 = System.Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                日程.Add(line2[0], line2[1]);
            }
            int 連休初日 = 日程.First().Key;


            Dictionary<int, int> 降水確率List = new Dictionary<int, int>(); // 0:初日の日数 1:合計降水確率
            for (int i = 連休初日; i < 連休初日 + M - (N - 1); ++i)
            {
                降水確率List.Add(i, 降水確率算出(日程, i, N));
            }

            var result = 降水確率List.OrderBy(s => s.Value).ThenBy(s => s.Key).First();
            Console.WriteLine($"{result.Key} {result.Key + (N - 1)}");
        }

        static int 降水確率算出(Dictionary<int, int> 日程,int 開始Index,int 日数)
        {
            int total = 0;
            for (int i = 開始Index;i < 開始Index + 日数; ++i)
            {
                total += 日程[i];
            }
            return total;
        }
    }
    #endregion

    #region "C030:白にするか黒にするか"
    static class Class_C_C030
    {
        public static void Execute()
        {
            string[] line = System.Console.ReadLine().Trim().Split(' ');
            int H = int.Parse(line[0]);
            int W = int.Parse(line[1]);

            List<List<int>> result = new List<List<int>>();
            int cnt = 0;
            for (int i = 0; i < H; ++i)
            {
                List<int> line2list = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToList();

                result.Add(new List<int>());
                foreach (var item in line2list)
                {
                    result[cnt].Add((item >= 128) ? 1 : 0);
                }
                ++cnt;
            }


            foreach (var items in result)
            {
                Console.WriteLine(string.Join(" ", items));
            }
        }
    }
    #endregion

    #region "C031:時差を求めたい"
    static class Class_C_C031
    {
        public static void Execute()
        {
            int n = int.Parse(System.Console.ReadLine().Trim()); //都市数
            Dictionary<string, int> 時差リスト = new Dictionary<string, int>();  // 都市名,時差(時)
            string[] line2;
            for (int i = 0;i < n; ++i)
            {
                line2 = Console.ReadLine().Trim().Split(' ');
                時差リスト.Add(line2[0] , int.Parse(line2[1]));
            }   
            string[] line3 = Console.ReadLine().Trim().Split(' ');  // 所在地,現在時刻
            string q = line3[0];
            DateTime t = DateTime.Parse($"{line3[1]}:00");

            foreach (var item in 時差リスト)
            {
                string result = t.AddHours(時差リスト[item.Key] - 時差リスト[q]).ToString("HH:mm");
                Console.WriteLine(result);
            }
        }
    }
    #endregion

    #region "C032:お得な買い物"
    static class Class_C_C032
    {
        public static void Execute()
        {
            var n = int.Parse(System.Console.ReadLine().Trim());
            Dictionary<string,int> 集計リスト = Init集計リスト();
            Dictionary<string, int> ポイントリスト = Initポイントリスト();

            for (int i = 0;i < n; ++i)
            {
                string[] str = Console.ReadLine().Trim().Split(' ');
                string 種類 = str[0];
                int  金額 = int.Parse(str[1]);

                集計リスト[種類] += 金額;

            }

            int result = 0;
            foreach(var item in 集計リスト)
            {
                if (item.Value > 0)
                {
                    var a = ポイントリスト[item.Key];
                    result += (item.Value / 100 ) * ポイントリスト[item.Key];
                }
            }

            Console.WriteLine(result.ToString());
        }

        static Dictionary<string,int> Init集計リスト()
        {
            Dictionary<string, int> 集計リスト = new Dictionary<string, int>();
            集計リスト.Add("0", 0);
            集計リスト.Add("1", 0);
            集計リスト.Add("2", 0);
            集計リスト.Add("3", 0);
            return 集計リスト;
        }

        static Dictionary<string, int> Initポイントリスト()
        {
            Dictionary<string, int> ポイントリスト = new Dictionary<string, int>();
            ポイントリスト.Add("0", 5);
            ポイントリスト.Add("1", 3);
            ポイントリスト.Add("2", 2);
            ポイントリスト.Add("3", 1);
            return ポイントリスト;
        }
    }
    #endregion

    #region "C033:野球の審判"
    static class Class_C_C033
    {
        public static void Execute()
        {
            List<string> result = new List<string>();
            var n = int.Parse(System.Console.ReadLine().Trim());

            Queue<string> ストライク判定 = new Queue<string>();
            Queue<string> ボール判定 = new Queue<string>();
            for (int i = 0;i < n; ++i)
            {
                string str = Console.ReadLine().Trim();

                if (str == "strike")
                {
                    if (ストライク判定.Count >= 2)
                    {
                        result.Add("out!");
                        ストライク判定.Enqueue(str);
                    }
                    else
                    {
                        result.Add("strike!");
                        ストライク判定.Enqueue(str);
                    }
                }
                else if (str == "ball")
                {
                    if (ボール判定.Count >= 3)
                    {
                        result.Add("fourball!");
                        ボール判定.Enqueue(str);
                    }
                    else
                    {
                        result.Add("ball!");
                        ボール判定.Enqueue(str);
                    }
                }

            }

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
    #endregion

    #region "C034:先生の宿題"
    static class Class_C_C034
    {
        public static void Execute()
        {
            var line = System.Console.ReadLine().Trim();    // "a op b = c"
            string a = line.Substring(0, 1);
            string op = line.Substring(2, 1);
            string b = line.Substring(4, 1);
            string c = line.Substring(8, 1);
            int result = 0;
            
            if (c == "x")
            {
                if(op == "+")
                {
                    result = int.Parse(a) + int.Parse(b);
                }
                else
                {
                    result = int.Parse(a) - int.Parse(b);
                }
            }
            else if (a == "x")
            {
                if (op == "+")
                {
                    result = int.Parse(c) - int.Parse(b);
                }
                else
                {
                    result = int.Parse(b) + int.Parse(c);
                }
            }
            else 
            {
                if (op == "+")
                {
                    result = int.Parse(c) - int.Parse(a);
                }
                else
                {
                    result = int.Parse(a) - int.Parse(c);
                }
            }
            
            Console.WriteLine(result.ToString());
        }
    }
    #endregion

    #region "C035:試験の合格判定"
    static class Class_C_C035
    {
        public static void Execute()
        {
            int n = int.Parse(Console.ReadLine().Trim());   //系は "l" ("L" の小文字)、理系は "s" 

            int cnt = 0;
            for (int i = 0;i < n; ++i)
            {
                // t_i と、英語、数学、理科、国語、地理歴史
                string line = Console.ReadLine().Trim();
                string 科目 = line.Substring(0, 1);
                List<int> list = line.Substring(2).Split(' ').Select(s => int.Parse(s)).ToList();

                if (list.Sum() < 350)
                {
                    continue;
                }

                switch (科目)
                {
                    case "s":
                        if (list[1] + list[2] < 160)
                        {
                            continue;
                        }
                        break;
                    case "l":
                        if (list[3] + list[4] < 160)
                        {
                            continue;
                        }
                        break;

                }

                ++cnt;
            }

            Console.WriteLine(cnt.ToString());
        }
    }
    #endregion

    #region "C036:[もし女コラボ問題]犬ぞりトーナメント"
    static class Class_C_C036
    {
        public static void Execute()
        {
            int[] list = new int[2];
            int[] line1 = System.Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            int[] line2 = System.Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

            int[] line3 = System.Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            if (line3[line1[0] - 1] < line3[line1[1] -1])
            {
                list[0] = line1[0];
            }
            else
            {
                list[0] = line1[1];
            }
            if (line3[line2[0] -1] < line3[line2[1] - 1])
            {
                list[1] = line2[0];
            }
            else
            {
                list[1] = line2[1];
            }
            int[] line4 = System.Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            Array.Sort(list);
            if (line4[0] < line4[1])
            {
                Console.WriteLine(list[0]);
                Console.WriteLine(list[1]);
            }
            else
            {
                Console.WriteLine(list[1]);
                Console.WriteLine(list[0]);
            }

        }
    }
    #endregion

    #region "C037:アニメの日時"
    static class Class_C_C037
    {
        public static void Execute()
        {
            string result = string.Empty;
            var line = System.Console.ReadLine().Trim();    //  "MM/dd hh:mm" 
            int 月 = int.Parse(line.Substring(0, 2));
            int 日 = int.Parse(line.Substring(3, 2));
            int 時 = int.Parse(line.Substring(6, 2));
            int 分 = int.Parse(line.Substring(9, 2));

            if (時 / 24 >= 1)
            {
                日 = 日 + (時 / 24);
                時 = 時 % 24;
            }

            result = $"{月:00}/{日:00} {時:00}:{分:00}";
            Console.WriteLine(result);
        }
    }
    #endregion

    #region "C038:お菓子の分配"
    static class Class_C_C038
    {
        public static void Execute()
        {
            //string result = string.Empty;
            var line1 = System.Console.ReadLine().Trim();    // [M N] M:機械の数　N:容器の容量
            List<string> list1 = line1.Split(' ').ToList<string>();
            int m = int.Parse(list1[0]);    // 機械の数
            int n = int.Parse(list1[1]);    // 容器の容量

            List<int> 機械list = new List<int>();
            for ( int i = 0;i < m; ++i)
            {
                機械list.Add(int.Parse(Console.ReadLine()));  // 各機械の梱包容量
            }

            int 容器 = 0;
            int 余り = 0;
            int tmp容器 = 0;
            int tmp余り = 0;
            int result = 0;
            for (int i = 0;i < 機械list.Count(); ++i)
            {
                if (i == 0)
                {
                    容器 = 機械list[i];
                    余り = (n % 機械list[i]);
                    result = 1;
                    continue;
                }
                else
                {
                    tmp容器 = 機械list[i];
                    tmp余り = (n % 機械list[i]);

                }

                if (tmp余り > 余り)
                {
                    continue;
                }
                else
                {
                    if (tmp余り == 余り && tmp容器 <= 容器)
                    {
                        continue;
                    }
                    容器 = tmp容器;
                    余り = tmp余り;
                    result = i + 1;
                }
                
            }
            
            Console.WriteLine(result.ToString());
        }
    }
    #endregion

    #region "C039:古代の数式"
    static class Class_C_C039
    {
        public static void Execute(string line)
        {
            string result = string.Empty;

            List<string> list = line.Trim().Split('+').ToList<string>();
            List<int> 数値list = new List<int>();

            foreach (var item in list)
            {
                int 数値 = 0;
                for (int i = 0;i < item.Length; ++i)
                {
                    switch (item.Substring(i, 1))
                    {
                        case "/":
                            数値 += 1;
                            break;
                        case "<":
                            数値 += 10;
                            break;
                        default:
                            break;
                    }
                }
                数値list.Add(数値);
            }

            result = 数値list.Sum().ToString();

            Console.WriteLine(result);
        }
    }
    #endregion

    #region "C040:【ロジサマコラボ問題】背比べ"
    static class Class_C_C040
    {
        public static void Execute(string line)
        {
            int n = int.Parse(line);
            float max = 200F;
            float min = 100F;

            for (int i = 0; i < n; ++i)
            {
                string str = Console.ReadLine().Trim();
                //if (i == n - 1) { break; } // 最終行の改行は無視
                string[] list = str.Split(' ');

                switch (list[0])
                {
                    case "le":  // 以下
                        if (max > float.Parse(list[1]))
                        {
                            max = float.Parse(list[1]);
                        }
                        break;
                    case "ge":  // 超過
                        if (min < float.Parse(list[1]))
                        {
                            min = float.Parse(list[1]);
                        }
                        break;
                }
            }

            string result = $"{min:0.0} {max:0.0}";

            Console.WriteLine(result);
        }
    }
    #endregion

    #region "C041:メダルランキングの作成"
    static class Class_C_C041
    {
        public static void Execute()
        {
            var N = int.Parse(System.Console.ReadLine().Trim());
            List<メダル情報> list = new List<メダル情報>();
            for (int i = 0;i < N; ++i)
            {
                var s = Console.ReadLine().Split(' ').Select(c => int.Parse(c)).ToArray();
                list.Add(new メダル情報(s[0], s[1], s[2]));
            }

            foreach (var item in list.OrderByDescending(s => s.金).ThenByDescending(s => s.銀).ThenByDescending(s => s.銅))
            {
                Console.WriteLine($"{item.金} {item.銀} {item.銅}");
            }


        }

        private class メダル情報
        {
            public int 金 { get; set; }
            public int 銀 { get; set; }
            public int 銅 { get; set; }
            
            public メダル情報(int 金,int 銀,int 銅)
            {
                this.金 = 金;
                this.銀 = 銀;
                this.銅 = 銅;
            }
        }
    }
    #endregion


}
