using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paiza_
{
    #region "format"
    static class Class_ロジサマ_format
    {
        public static void Execute()
        {
            string line1 = Console.ReadLine().Trim();


            Console.WriteLine("");
        }
    }
    #endregion

    #region "復活の呪文　(封印レベルD)"
    static class Class_ロジサマ_1004
    {
        public static void Execute(string line)
        {
            string line2 = Console.ReadLine();

            string result = "NG";

            if (line.Trim() == line2.Trim())
            {
                result = "OK";
            }



            Console.WriteLine(result);
        }
    }
    #endregion

    #region "圧縮　　(封印レベルC)"
    static class Class_ロジサマ_2001
    {
        public static void Execute(string line)
        {
            List<string> result = new List<string>();
            int cnt = 0;
            string tmp = "b";

            for (int i = 0;i < line.Trim().Length; ++i)
            {
                string s = line.Substring(i, 1);
                
                if (tmp == s)
                {
                    cnt += 1;
                }
                else
                {
                    result.Add(cnt.ToString());
                    tmp = s;
                    cnt = 1;
                }


            }

            if (cnt > 0) { result.Add(cnt.ToString()); }
            


            Console.WriteLine(string.Join(" ",result));
        }
    }
    #endregion

    #region "攻撃コマンド　(封印レベルD)"
    static class Class_ロジサマ_3001
    {
        public static void Execute()
        {
            string result = string.Empty;

            int cnt = 0;

            for (int i = 1;i <= 5; ++i)
            {
                string line = Console.ReadLine().Trim();
                if (line == "Attack")
                {
                    cnt += 100;
                }
            }

            result = cnt.ToString();
            Console.WriteLine(result);
        }
    }
    #endregion

    #region "魔法陣　(封印レベルB)　※あきらめた"
    static class Class_ロジサマ_2002
    { 
        public static void Execute()
        {
            int n = int.Parse(Console.ReadLine().Trim());  //ループ回数
            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < n; ++i)
            {
                List<string> 数値list = Console.ReadLine().Trim().Split(' ').ToList();
                list.Add(new List<int>());
                for (int j = 0;j < n; ++j)
                {
                    list[i].Add(int.Parse(数値list[j])); 
                }
            }

            int max = 0;    // 魔法陣の1行の和を求める
            foreach (var item in list)
            {
                if (item.Sum() > max) { max = item.Sum(); }
            }

            //横の比較
            List<List<int>> resultList = new List<List<int>>();
            foreach (var item in list)
            {
                if (item.Where(i2 => i2 == 0).Count() == 1)
                {
                    resultList.Add(new List<int>(Update横List(item,max)));
                }
                else if (item.Where(i2 => i2 == 0).Count() == 0)
                {
                    resultList.Add(new List<int>(item));
                }
                else if (item.Where(i2 => i2 == 0).Count() >= 2)
                {
                    resultList.Add(new List<int>(Update横List0有り(item, max, list)));
                }
            }
            
            // 結果表示
            foreach(var item in resultList)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }

        static List<int> Update横List(List<int> list, int max)
        {
            List<int> result = new List<int>();
            int x = max - list.Sum();
            foreach (var item in list)
            {
                if (item == 0)
                {
                    result.Add(x);
                }
                else
                {
                    result.Add(item);
                }
            }
            return result;
        }

        static List<int> Update横List0有り(List<int> items, int max, List<List<int>> list)
        {
            List<int> result = new List<int>();
            int x = max - items.Sum();
            int row = 0;
            foreach (var item in items)
            {
                if (item == 0)
                {
                    int 列total = 0;
                    for (int i = 0;i < list.Count(); ++i)
                    {
                        列total += list[i][row];
                    }
                    result.Add(max - 列total);
                }
                else
                {
                    result.Add(item);
                }
                row++;
            }
            return result;
        }
        
    }
    #endregion

    #region "魔法陣　(封印レベルB) ※再※"
    static class Class_ロジサマ_2002_2
    {
        public static void Execute()
        {
            int n = int.Parse(Console.ReadLine().Trim());

            // 魔法陣作成
            List<List<int>> list = new List<List<int>>();
            for (int i = 0;i < n; ++i)
            {
                int[] line = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToArray();
                list.Add(new List<int>());
                for (int j = 0;j < line.Length; ++j)
                {
                    list[i].Add(line[j]);
                }
            }

            // 魔法陣の一列の和
            int max = n * (n * n + 1) / 2;
            for (int i = 0;i < n; ++i)
            {
                if (list[i].Sum() == max) { continue; }
                if (list[i].Where(s => s == 0).Count() == 1)
                {
                    int ind = list[i].IndexOf(0);
                    list[i][ind] = max - list[i].Sum(); 
                }
                else
                {
                    while (list[i].IndexOf(0) != -1)
                    {
                        int ind = list[i].IndexOf(0);
                        int clm = 0;
                        for (int k = 0;k < n; ++k)
                        {
                            clm += list[k][ind];    // 列の合計値を取得
                        }
                        list[i][ind] = max - clm;

                    }
                }
            }

            foreach (var item in list)
            {
                Console.WriteLine(string.Join(" ",item));
            }

        }
    }
    #endregion

    #region "オートチャージ　(封印レベルC)"
    static class Class_ロジサマ_3002
    {
        public static void Execute()
        {
            string[] line1list = Console.ReadLine().Trim().Split(' ');
            int n = int.Parse(line1list[0]);
            int 体力 = int.Parse(line1list[1]);
            int 閾値 = int.Parse(line1list[2]);
            int 回復量 = int.Parse(line1list[3]);

            List<int> ダメージList = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToList();
            foreach(var item in ダメージList)
            {
                体力 += item;
                if (体力 <= 閾値)
                {
                    体力 += 回復量;
                }
            }
                        
            Console.WriteLine(体力.ToString());  // ダメージと回復の件数 n、最初の体力 m、自動回復のしきい値 a, 回復量 b 


        }
    }
    #endregion

    #region "装備品　(封印レベルD)"
    static class Class_ロジサマ_4001
    {
        public static void Execute()
        {
            float[] line1 = Console.ReadLine().Trim().Split(' ').Select(s => float.Parse(s)).ToArray();
            float[] line2 = Console.ReadLine().Trim().Split(' ').Select(s => float.Parse(s)).ToArray();


            Console.WriteLine((line1[0] / line1[1] > line2[0] / line2[1])? line1[1]:line2[1]) ;
        }
    }
    #endregion

    #region "回復アイテムを揃えろ　(封印レベルD)"
    static class Class_ロジサマ_4002
    {
        public static void Execute()
        {
            List<int> line1 = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToList();


            Console.WriteLine(line1[0] * line1[1]);
        }
    }
    #endregion

    #region "回復の呪文　(封印レベルD)"
    static class Class_ロジサマ_4003
    {
        public static void Execute()
        {
            string line1 = Console.ReadLine().Trim();
            int 体力 = (int.Parse(line1) + 50);

            Console.WriteLine((体力 > 100)? 100 : 体力);
        }
    }
    #endregion

    #region "ログの結合　(封印レベルC)"
    static class Class_ロジサマ_4004
    {
        public static void Execute()
        {
            int n = int.Parse(Console.ReadLine().Trim());
            Dictionary<string, string> list = new Dictionary<string, string>();
            for (int i = 0;i < n; ++i)
            {
                string[] line = Console.ReadLine().Trim().Split(' '); 
                if (list.ContainsKey(line[0]))
                {
                    list[line[0]] += line[1];
                }
                else
                {
                    list.Add(line[0], line[1]);
                }
            }

            foreach (var item in list)
                {
                //Console.WriteLine(string.Join(" ",item));
                Console.WriteLine($"{item.Key} {item.Value}");

            }
        }
    }
    #endregion

    #region "ダメージ床　(封印レベルD)"
    static class Class_ロジサマ_3003
    {
        public static void Execute()
        {
            List<int> line1 = Console.ReadLine().Trim().ToCharArray().Select(s => int.Parse(s.ToString())).ToList();
            int vit = int.Parse(Console.ReadLine().Trim());
                
            Console.WriteLine((vit - line1.Sum() > 0)? (vit - line1.Sum()).ToString():"No");
        }
    }
    #endregion

    #region "魔法の呪文　(封印レベルS)"
    static class Class_ロジサマ_4005
    {
        public static void Execute()
        {
            string[] line = Console.ReadLine().Trim().Split(' ');
            int H = int.Parse(line[0]);
            int W = int.Parse(line[1]);
            int N = int.Parse(line[2]);

            //List<int

            Console.WriteLine("");
        }
    }
    #endregion

}
