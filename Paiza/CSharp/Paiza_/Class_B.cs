using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paiza_
{
    #region "format"
    static class Class_B_format
    {
        public static void Execute()
        {
            string line = System.Console.ReadLine().Trim();
            string result = string.Empty;


            System.Console.WriteLine(result);
        }
    }
    #endregion

    #region "B012:チェックディジット"
    static class Class_B_B012
    {
        public static void Execute()
        {
            int num = int.Parse(System.Console.ReadLine());
            //List<int> result = new List<int>();
            int[] result = new int[num];

            for (int i = 0; i < num; i++)
            {
                string numbers = System.Console.ReadLine();
                int even = 0;
                int odd = 0;

                for (int j = 0; j < 15; j++)
                {
                    int no = int.Parse(numbers.Substring(j, 1));
                    if ((j + 2) % 2 == 0)
                    {
                        // 偶数
                        int tmpNo = no * 2;
                        if (tmpNo.ToString().Length > 1)
                        {
                            even += int.Parse(tmpNo.ToString().Substring(0, 1)) +
                                int.Parse(tmpNo.ToString().Substring(1, 1));
                        }
                        else
                        {
                            even += tmpNo;
                        }
                    }
                    else
                    {
                        // 奇数
                        odd += no;
                    }

                }
                result[i] = even + odd;
            }

            for (int i = 0; i < num; i++)
            {
                int ans = 10 - (result[i] % 10);
                if (ans == 10) { ans = 0; }
                System.Console.WriteLine(ans);
            }

        }
    }
    #endregion

    #region " B029:地価の予想 "
    static class Class_B_B029
    {
        public static void Execute()
        {
            string[] line1 = Console.ReadLine().Trim().Split(' ').ToArray();
            int x = int.Parse(line1[0]);
            int y = int.Parse(line1[1]);
            int k = int.Parse(Console.ReadLine());  // 平均を求める範囲
            int N = int.Parse(Console.ReadLine());  // 地価情報数
            //Dictionary<string, int> 価格リスト = new Dictionary<string, int>();
            Dictionary<double, int> 価格リスト = new Dictionary<double, int>();
            int[] line2;
            for (int i = 0; i < N; ++i)
            {
                line2 = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
                //価格リスト.Add($"{line2[0]}_{line2[1]}", line2[2]);
                価格リスト.Add(F(x, y, line2[0], line2[1]), line2[2]);
            }

            var ave = Math.Round(価格リスト.OrderBy(d => d.Key).Take(k).Select(d => d.Value).Average(), 0, MidpointRounding.AwayFromZero);
            Console.WriteLine(ave);
        }

        private static double F(int x, int y, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(x - x2), 2) + Math.Pow(Math.Abs(y - y2), 2));
        }
    }
    #endregion

    #region "B030:氷のダンジョン"
    static class Class_B_B030
    {
        static int H;
        static int W;

        public static void Execute()
        {
            int[] line = Console.ReadLine().Trim().Split(' ').Select(s => int.Parse(s)).ToArray();
            H = line[0];
            W = line[1];
            char[] line2;
            int i;
            int j;
            //Dictionary<Cell,char> map = new Dictionary<Cell, char>();
            char[,] map = new char[W, H];
            for (i = 0; i < H; ++i)
            {
                line2 = Console.ReadLine().Trim().ToCharArray();
                for (j = 0; j < W; ++j)
                {
                    //map.Add(new Cell(j + 1, i + 1), line2[j]);
                    map[j, i] = line2[j];
                }
            }
            // 初期位置
            int[] line3 = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            Cell loc = new Cell(line3[0] - 1, line3[1] - 1);
            int N = int.Parse(Console.ReadLine());
            int moveX = 0;
            int moveY = 0;
            for (i = 0; i < N; ++i)
            {
                switch (Console.ReadLine().ToCharArray().First())
                {
                    case 'U':
                        moveX = 0;
                        moveY = -1;
                        break;
                    case 'R':
                        moveX = 1;
                        moveY = 0;
                        break;
                    case 'D':
                        moveX = 0;
                        moveY = 1;
                        break;
                    case 'L':
                        moveX = -1;
                        moveY = 0;
                        break;
                }

                do
                {
                    if (loc.y + moveY < 0 ||
                        loc.x + moveX < 0 ||
                        loc.y + moveY >= H ||
                        loc.x + moveX >= W)
                    {
                        break;
                    }

                    loc = new Cell(loc.x + moveX, loc.y + moveY);
                }
                while (map[loc.x, loc.y] == '#');
            }

            Console.WriteLine($"{loc.x + 1} {loc.y + 1}");
        }

        // Cellを1次元配列のインデックスに変換
        //private static int ToIndex(Cell cell)
        //{
        //    return cell.x + H * cell.y;
        //}

        public enum マス
        {
            氷,  //#
            土   //.
        }
        public class Cell
        {
            public int x;
            public int y;
            public Cell(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
    #endregion

    #region "B031:コインのウラとオモテ"
    static class Class_B_B031
    {
        public static void Execute()
        {
            int N = int.Parse(Console.ReadLine());
            char[] line = Console.ReadLine().ToCharArray();
            List<ExList> list = new List<ExList>();

            foreach (var item in line)
            {
                if (list.Count > 0 && list.Last().code == item)
                {
                    list.Last().count += 1;
                }
                else
                {
                    list.Add(new ExList(item, 1));
                }
            }

            char c = 'w';
            List<ExList> tmpList;
            while (list.Count() > 2)
            {
                tmpList = new List<ExList>();
                for (int i = 0; i < list.Count(); ++i)
                {
                    if (i == 0 || i == list.Count() - 1)
                    {
                        tmpList.Add(list[i]);
                    }
                    else
                    {
                        switch (list[i].code)
                        {
                            case 'b':
                                c = 'w';
                                break;
                            case 'w':
                                c = 'b';
                                break;
                        }
                        tmpList.Add(new ExList(c, list[i].count));
                    }
                }

                list = new List<ExList>();
                foreach (var item in tmpList)
                {
                    if (list.Count() > 0 && list.Last().code == item.code)
                    {
                        list.Last().count += item.count;
                    }
                    else
                    {
                        list.Add(new ExList(item.code, item.count));
                    }
                }

            }

            int ans = 0;
            foreach (var item in list)
            {
                if (item.code == 'b') { ans = item.count; }
            }
            Console.WriteLine($"{ans}");
        }

        public class ExList
        {
            public char code;
            public int count;
            public ExList(char code, int count)
            {
                this.code = code;
                this.count = count;
            }
        }
    }
    #endregion

    #region "B032:デジタル計算機"
    static class Class_B_B032
    {
        const char 珠 = '*';
        const char 無 = '|';
        const char 枠 = '=';

        public static void Execute()
        {

            int W = int.Parse(Console.ReadLine().Trim());
            int i = 0;
            string[] line2list = new string[8];
            for (i = 0; i < 8; ++i)
            {
                line2list[i] = Console.ReadLine().Trim();
            }
            string[] line3list = new string[8];
            for (i = 0; i < 8; ++i)
            {
                line3list[i] = Console.ReadLine().Trim();
            }

            int[] sumList = new int[W];
            for (i = 0; i < W; ++i)
            {
                sumList[i] = 計算(i, line2list) + 計算(i, line3list);
            }

            string[] 結果 = 結果算出(sumList, W);
            for (i = 0; i < 8; ++i)
            {
                Console.WriteLine(結果[i]);
            }
        }

        private static int 計算(int index, string[] list)
        {
            int cnt = 0;

            for (int i = 0; i < 8; ++i)
            {
                switch (i)
                {
                    case 1:
                        if (list[i].ToString()[index] == 珠) { cnt += 5; }
                        break;
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        if (list[i].ToString()[index] == 無) { cnt += i - 3; }
                        break;
                }
            }
            return cnt;
        }

        private static string[] 結果算出(int[] sumList, int W)
        {
            string[] 結果list = new string[8];
            char[] 結果;
            bool is繰上 = false;
            int cnt = 0;
            foreach (var item in sumList.Reverse())
            {
                結果 = new char[] { 珠, 珠, 枠, 珠, 珠, 珠, 珠, 珠 };
                cnt = item;
                if (is繰上)
                {
                    cnt += 1;
                    is繰上 = false;
                }
                if (cnt > 9)
                {
                    cnt -= 10;
                    is繰上 = true;
                }
                if (cnt >= 5)
                {
                    cnt -= 5;
                    結果[0] = 無;
                }
                else
                {
                    結果[1] = 無;
                }
                結果[cnt + 3] = 無;

                for (int i = 0; i < 8; ++i)
                {
                    結果list[i] = 結果[i] + 結果list[i];
                }
            }

            return 結果list;
        }
    }
    #endregion

    #region "B033:テーブルジェネレーター"
    static class Class_B_B033
    {
        public static void Execute()
        {
            // 例
            // | id | name |
            // | ----| ------------|
            // | 1 | ito |
            // | 2 | sakakibara |
            // | 3 | takahashi |
            List<List<string>> データList = new List<List<string>>();
            int W = int.Parse(Console.ReadLine().Trim());   // 見出しの個数
            List<string> headerList = Console.ReadLine().Trim().Split(' ').ToList();
            foreach (var item in headerList)
            {
                データList.Add(new List<string>() { item });   // ヘッダデータを格納
            }

            int H = int.Parse(Console.ReadLine().Trim());   // データ行数
            int index = 0;
            for (int i = 0; i < H; ++i)
            {
                List<string> dataList = Console.ReadLine().Trim().Split(' ').ToList();

                foreach (var item in dataList)
                {
                    データList[index++].Add(item);
                }
                index = 0;
            }

            // 各列の必要列数の取得
            List<int> 列数List = new List<int>();
            foreach (var item in データList)
            {
                //列数List.Add(item.OrderByDescending(s => s).First().Length + 2);  // 各列の文字数 + 前後の1文字
                列数List.Add(item.OrderByDescending(s => s.Length).First().Length);  // 各列の文字数
            }

            // OUTPUT
            int cnt = 1;
            StringBuilder outLine;
            for (int i = 0; i < H + 1; ++i)
            {
                // 2行目　（ヘッダと明細の区切り）のみ実行
                while (cnt == 2)
                {
                    outLine = new StringBuilder();
                    for (int j = 0; j < W; ++j)
                    {
                        outLine.Append("|-" + "-".PadRight(列数List[j], '-') + "-");
                    }
                    outLine.Append("|");
                    Console.WriteLine(outLine);
                    ++cnt;
                }

                outLine = new StringBuilder();
                for (int j = 0; j < W; ++j)
                {
                    outLine.Append("| " + データList[j][i].PadRight(列数List[j], ' ') + " ");
                }
                outLine.Append("|");
                Console.WriteLine(outLine);
                ++cnt;
            }

        }
    }
    #endregion

    #region "B034:ロボットの歩行実験"
    static class Class_B_B034
    {
        static Dictionary<string, int> 方向数値 = new Dictionary<string, int>() { { "F", 0 }, { "R", 1 }, { "B", 2 }, { "L", 3 } };

        public static void Execute()
        {
            // ｜
            // ｜  △（x, y)スタート　上向き
            // ｜
            // └――――
            string[] line1 = Console.ReadLine().Trim().Split(' ');  // 座標
            Dictionary<string, int> 座標 = new Dictionary<string, int>();  // 0:x 1:y
            座標["X"] = int.Parse(line1[0]);
            座標["Y"] = int.Parse(line1[1]);

            int 向き = 0; // Index 
            int new向き = 0; // Index:0から前方向、右方向、後方向、左方向

            string line2 = Console.ReadLine().Trim();
            List<int> 移動可能距離 = line2.Split(' ').Select(s => int.Parse(s)).ToList(); // Index:0から前方向、右方向、後方向、左方向

            int n = int.Parse(Console.ReadLine().Trim());           // 命令数
            for (int i = 0; i < n; ++i)
            {
                string[] line3 = Console.ReadLine().Trim().Split(' ');   // 命令[m(移動),t(方向転換)] 移動方向/転換方向=[F,R,B,L]
                string 命令 = line3[0];
                string 方向 = line3[1];

                switch (命令)
                {
                    case "m": // 移動
                        座標 = 移動する(座標, 移動可能距離, 方向, 向き, out new向き);
                        向き = new向き;
                        break;
                    case "t": // 方向転換
                        向き = 方向転換する(方向, 向き);
                        break;

                }

            }

            Console.WriteLine($"{座標["X"]} {座標["Y"]}");
        }

        static Dictionary<string, int> 移動する(Dictionary<string, int> 座標, List<int> 移動可能距離, string 方向, int 向き, out int new向き)
        {
            Dictionary<string, int> new座標 = new Dictionary<string, int>(座標);  // 0:x 1:y
            new向き = 向き; // 変わらない
            switch ((方向数値[方向] + (向き + 4)) % 4)    // +4は0除算回避の為
            {
                case 0:   // 北
                    new座標["Y"] = new座標["Y"] + 移動可能距離[方向数値[方向]];
                    break;
                case 1:   // 東
                    new座標["X"] = new座標["X"] + 移動可能距離[方向数値[方向]];
                    break;
                case 2:   // 南
                    new座標["Y"] = new座標["Y"] - 移動可能距離[方向数値[方向]];
                    break;
                case 3:   // 西
                    new座標["X"] = new座標["X"] - 移動可能距離[方向数値[方向]];
                    break;
            }

            return new座標;
        }

        static int 方向転換する(string 方向, int 向き)
        {
            return 方向数値[方向] + 向き;
        }
    }
    #endregion

    #region "B035:ジョギングランキング"
    static class Class_B_B035
    {
        public static void Execute()
        {
            string line1 = Console.ReadLine().Trim();
            List<string> line1List = line1.Split(' ').ToList();
            int N = int.Parse(line1List[0]);    // 部員の人数
            int M = int.Parse(line1List[1]);    // 今月のジョギング記録の数
            int T = int.Parse(line1List[2]);    // 成績表に表示される上位の人数

            Dictionary<string, int> 先月の記録 = new Dictionary<string, int>();
            Dictionary<string, int> 今月の記録 = new Dictionary<string, int>();
            for (int i = 0; i < N; ++i)
            {
                string[] 先月の記録配列 = Console.ReadLine().Trim().Split(' ');
                先月の記録.Add(先月の記録配列[0], int.Parse(先月の記録配列[1]));
                今月の記録.Add(先月の記録配列[0], 0);
            }

            for (int i = 0; i < M; ++i)
            {
                string[] 今月の記録配列 = Console.ReadLine().Trim().Split(' ');
                今月の記録[今月の記録配列[1]] += int.Parse(今月の記録配列[2]);
            }

            var 先月成績list = 先月の記録.OrderByDescending(s => s.Value).ThenBy(s => s.Key).Take(T).Select((c, i) => new { Content = c, Index = i });
            var 成績list = 今月の記録.OrderByDescending(s => s.Value).ThenBy(s => s.Key).Take(T).Select((c, i) => new { Content = c, Index = i });

            foreach (var item in 成績list)
            {
                string result = string.Empty;
                if (先月成績list.Where(s => s.Content.Key == item.Content.Key).Count() == 0)
                {
                    result = "new";
                }
                else if (先月成績list.Where(c => c.Content.Key == item.Content.Key).First().Index > item.Index)
                {
                    result = "up";
                }
                else if (先月成績list.Where(c => c.Content.Key == item.Content.Key).First().Index < item.Index)
                {
                    result = "down";
                }
                else if (先月成績list.Where(c => c.Content.Key == item.Content.Key).First().Index == item.Index)
                {
                    result = "same";
                }

                Console.WriteLine($"{item.Content.Key} {item.Content.Value} {result}");
            }

        }
    }
    #endregion

    #region "B036:大統領選挙 Give Up"
    //static class Class_B_B036
    //{
    //    public static void Execute()
    //    {
    //        int M = int.Parse(Console.ReadLine().Trim());

    //        // 両党の候補者
    //        string Rep = "Rep";
    //        string Dem = "Dem";

    //        Dictionary<int,string> 候補者list = new Dictionary<int,string>();
    //        for (int i = 0;i < M; ++i)
    //        {
    //            候補者list.Add(i, Console.ReadLine().Trim());
    //        }

    //        // 投票リスト
    //        int N = int.Parse(Console.ReadLine().Trim());
    //        List<Dictionary<int, int>> 投票結果 = new List<Dictionary<int, int>>();
    //        for (int i = 0; i < N; ++i)
    //        {
    //            投票結果.Add(new Dictionary<int, int>());
    //            int[] 投票 = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
    //            for (int j = 0; j < M; ++j)
    //            {
    //                投票結果[i].Add(j, 投票[j]);
    //            }
    //        }
    //        string result = string.Empty;

    //        List<Dictionary<int, int>> 順位表リスト1 = new List<Dictionary<int, int>>();
    //        List<Dictionary<int, int>> 順位表リスト2 = new List<Dictionary<int, int>>();
    //        foreach ( var items in 投票結果)
    //        {
    //            Dictionary<int, int> 順位表1 = new Dictionary<int, int>();
    //            Dictionary<int, int> 順位表2 = new Dictionary<int, int>();
    //            for (int i = 0;i < items.Count(); ++i)
    //            {
    //                if (候補者list[items[i] -1] == "Republican")
    //                {
    //                    順位表1.Add(i,items[i]);
    //                }
    //                else
    //                {
    //                    順位表2.Add(i,items[i]);
    //                }
    //            }
    //            順位表リスト1.Add(順位表1);
    //            順位表リスト2.Add(順位表2);
    //        }

    //        //List<int> 各党代表 = new List<int>();
    //        //var 結果リスト1 = 順位表リスト1.GroupBy(s => s.Keys).Select(s => new { 順位 = s, Count = s.Count() }).OrderBy(s => s.順位.key).ThenByDescending(s => s.Count);
    //        //各党代表.Add(結果リスト1.First().順位.value);
    //        //var 結果リスト2 = 順位表リスト2.GroupBy(s => s.Keys).Select(s => new { 順位 = s, Count = s.Count() }).OrderBy(s => s.順位.key).ThenByDescending(s => s.Count);
    //        //var b = 結果リスト2.First().順位.Key;

    //        foreach (var item in 候補者list)
    //        {
    //            if (item.Value == "Republican")
    //            {
    //                順位表リスト1.Where(s => s.Keys == item.Key + 1)
    //            }
    //            else
    //            {
    //                順位表2.Add(i, items[i]);
    //            }
    //        }



    //        //各党代表.Add(結果リスト1.)


    //        Console.WriteLine(result);
    //    }
    //}
    #endregion

    #region "B037:【2017年お正月問題】幸運な1年"
    static class Class_B_B037
    {
        public static void Execute()
        {
            Queue<string> 日付 = Init日付(Console.ReadLine().Trim());    // 日付を分解してQueueに格納
            List<int> 乱数A = 分割(Console.ReadLine().Trim());    // 日付を分解してQueueに格納
            List<int> 乱数B = 分割(Console.ReadLine().Trim());    // 日付を分解してQueueに格納
            List<int> 乱数M = 分割(Console.ReadLine().Trim());    // 日付を分解してQueueに格納

            int cnt = 0;
            List<int> 乱数W = new List<int>();
            List<int> 乱数Wtmp = new List<int>();
            for (int i = 0; i < 10000; ++i)
            {
                if (乱数W.Count == 0)
                {
                    乱数W.Add(0);
                    乱数W.Add(0);
                    乱数W.Add(0);
                    乱数W.Add(0);
                }
                Queue<string> 日付a = new Queue<string>(日付);
                cnt = i + 1;
                List<int> カード = new List<int>();
                乱数Wtmp.Clear();
                for (int j = 0; j < 4; ++j)
                {
                    //カード.Add(((乱数A[j] * 乱数W[j] + 乱数B[j]) % 乱数M[j])% 10);    // 乱数からカードを作成
                    var 余り = ((乱数A[j] * 乱数W[j] + 乱数B[j]) % 乱数M[j]);
                    乱数Wtmp.Add(余り);
                    カード.Add(余り % 10);    // 乱数からカードを作成
                }

                List<int> カードa = new List<int>(カード);
                if (カードチェック(日付a, カード))
                {
                    break;
                }

                乱数W.Clear();
                foreach (var item in 乱数Wtmp)
                {
                    乱数W.Add(item);
                }

            }



            Console.WriteLine(cnt.ToString());
        }

        static Queue<string> Init日付(string line)
        {
            Queue<string> result = new Queue<string>();
            string[] s = line.Split(' ');
            foreach (string item in s)
            {
                if (item.Length == 1)
                {
                    result.Enqueue("0");
                    result.Enqueue(item.Substring(0, 1));
                }
                else
                {
                    result.Enqueue(item.Substring(0, 1));
                    result.Enqueue(item.Substring(1, 1));
                }
            }
            return result;
        }

        static List<int> 分割(string line)
        {
            List<int> list = new List<int>();
            List<string> str = line.Split(' ').ToList();
            foreach (var item in str)
            {
                list.Add(int.Parse(item));
            }
            return list;
        }

        static Boolean カードチェック(Queue<string> 日付, List<int> カード)
        {
            while (日付.Count > 0)
            {
                string s = 日付.Dequeue();
                if (カード.Contains(int.Parse(s)))
                {
                    カード.Remove(int.Parse(s));
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
    #endregion

    #region "B038:つるかめ算"
    static class Class_B_B038
    {
        public static void Execute()
        {
            List<int> list = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            int 総足数 = list[0];
            int 総頭数 = list[1];
            int 鶴の足 = list[2];
            int 亀の足数 = list[3];
            var resultList = new List<int[]>();
            string result = "miss";

            // 総頭数の数だけループさせる
            for (int i = 1; i < 総頭数; ++i)
            {
                if (総足数 == 鶴の足 * i + 亀の足数 * (総頭数 - i))
                {
                    resultList.Add(new int[] { i, 総頭数 - i });
                }
            }

            if (resultList.Count() == 1)
            {
                result = $"{resultList[0][0]} {resultList[0][1]}";
            }

            Console.WriteLine(result);
        }
    }
    #endregion

    #region "B039:雨上がりの道"
    static class Class_B_B039
    {
        public static void Execute()
        {
            int n = int.Parse(Console.ReadLine().Trim());   // 水溜りの個数
            int s = int.Parse(Console.ReadLine().Trim()) - 1;   // 現在の番号
            List<Dictionary<string, int>> 水溜りList = new List<Dictionary<string, int>>();
            int 水溜りindex = 0;

            for (int i = 0; i < n; ++i)
            {
                水溜りList.Add(new Dictionary<string, int>());
                string[] line = Console.ReadLine().Trim().Split(' ');   // x1 y1 x2 y2
                水溜りList[水溜りindex].Add("X1", int.Parse(line[0]));
                水溜りList[水溜りindex].Add("Y1", int.Parse(line[1]));
                水溜りList[水溜りindex].Add("X2", int.Parse(line[2]));
                水溜りList[水溜りindex].Add("Y2", int.Parse(line[3]));

                ++水溜りindex;
            }

            List<int> 進入可Index = new List<int>(s);    // 現在地含む
            List<Dictionary<string, int>> 比較元水溜りListTmp = new List<Dictionary<string, int>>();
            比較元水溜りListTmp.Add(new Dictionary<string, int>(水溜りList[s]));  // 所在地の水溜りをtmpに格納する
            Boolean Is比較 = true;
            while (Is比較)
            {
                Is比較 = false;

                // 初回のみ
                List<Dictionary<string, int>> 比較元水溜りList = new List<Dictionary<string, int>>(比較元水溜りListTmp);     // tmpを比較元にする
                比較元水溜りListTmp.Clear();

                // 全水溜りをループ
                for (int i = 0; i < n; ++i)
                {
                    // 進入できると判断されたものは、比較外
                    if (進入可Index.Contains(i)) { continue; }

                    if (Is座標重複(比較元水溜りList, 水溜りList[i]))
                    {
                        進入可Index.Add(i);
                        比較元水溜りListTmp.Add(new Dictionary<string, int>(水溜りList[i]));  // 移動可能な水溜りは、tmpに格納する
                        Is比較 = true;
                    }
                }

            }

            foreach (var item in 進入可Index.OrderBy(o => o).Select(o => o + 1))  // Indexなので+1
            {
                Console.WriteLine(item);
            }
        }

        static Boolean Is座標重複(List<Dictionary<string, int>> 比較元水溜りList, Dictionary<string, int> 比較水溜り)
        {
            bool Is重複 = false;
            foreach (var item in 比較元水溜りList)
            {
                if (item["X2"] < 比較水溜り["X1"] || 比較水溜り["X2"] < item["X1"])
                {
                    continue;
                }
                if (item["Y2"] < 比較水溜り["Y1"] || 比較水溜り["Y2"] < item["Y1"])
                {
                    continue;
                }
                Is重複 = true;
            }
            return Is重複;
        }
    }
    #endregion

    #region "B040:【キャンペーン問題】たのしい暗号解読"
    static class Class_B_040
    {
        public static void Execute(string line)
        {
            string[] str = line.Split(' ');
            int n = int.Parse(str[0]);  //ループ回数
            Dictionary<string, string> 変換list = Init変換list(new Dictionary<string, string>(), str[1].ToLower());

            List<string> 変換後list = new List<string>();
            List<string> 対象list = new List<string>();
            string 対象列 = Console.ReadLine().ToLower();
            for (int i = 0; i < 対象列.Length; ++i)
            {
                対象list.Add(対象列[i].ToString());
            }

            for (int j = 0; j < n; ++j)
            {
                if (変換後list.Count > 0)
                {
                    対象list = new List<string>(変換後list);
                    変換後list.Clear();
                }

                foreach (string 対象row in 対象list)
                {
                    if (変換list.ContainsKey(対象row))
                    {
                        変換後list.Add(変換list[対象row]);
                    }
                    else
                    {
                        変換後list.Add(対象row);
                    }
                }
            }


            Console.WriteLine(string.Join("", 変換後list));
        }

        public static Dictionary<string, string> Init変換list(Dictionary<string, string> 変換list, string 文字列)
        {
            int i = 0;
            変換list.Add(文字列.Substring(i++, 1), "a");
            変換list.Add(文字列.Substring(i++, 1), "b");
            変換list.Add(文字列.Substring(i++, 1), "c");
            変換list.Add(文字列.Substring(i++, 1), "d");
            変換list.Add(文字列.Substring(i++, 1), "e");
            変換list.Add(文字列.Substring(i++, 1), "f");
            変換list.Add(文字列.Substring(i++, 1), "g");
            変換list.Add(文字列.Substring(i++, 1), "h");
            変換list.Add(文字列.Substring(i++, 1), "i");
            変換list.Add(文字列.Substring(i++, 1), "j");
            変換list.Add(文字列.Substring(i++, 1), "k");
            変換list.Add(文字列.Substring(i++, 1), "l");
            変換list.Add(文字列.Substring(i++, 1), "m");
            変換list.Add(文字列.Substring(i++, 1), "n");
            変換list.Add(文字列.Substring(i++, 1), "o");
            変換list.Add(文字列.Substring(i++, 1), "p");
            変換list.Add(文字列.Substring(i++, 1), "q");
            変換list.Add(文字列.Substring(i++, 1), "r");
            変換list.Add(文字列.Substring(i++, 1), "s");
            変換list.Add(文字列.Substring(i++, 1), "t");
            変換list.Add(文字列.Substring(i++, 1), "u");
            変換list.Add(文字列.Substring(i++, 1), "v");
            変換list.Add(文字列.Substring(i++, 1), "w");
            変換list.Add(文字列.Substring(i++, 1), "x");
            変換list.Add(文字列.Substring(i++, 1), "y");
            変換list.Add(文字列.Substring(i++, 1), "z");

            return 変換list;
        }
    }
    #endregion

    #region "B041:繰り返し模様 "
    static class Class_B_B041
    {
        public static void Execute()
        {
            int k = int.Parse(Console.ReadLine().Trim());
            int n = int.Parse(Console.ReadLine().Trim());
            string result = string.Empty;

            // 図形の取得
            List<string> list = new List<string>();
            for (int i = 0; i < n; ++i)
            {
                list.Add(Console.ReadLine().Trim());
            }

            // 生成
            for (int j = 1; j <= k; ++j)
            {
                int cnt = 0;
                List<string> newList = new List<string>();
                // List = #..
                //        ##.
                //        ###
                foreach (var item in list)
                {
                    // item = #..
                    List<List<string>> tmpList = new List<List<string>>();
                    // tmpListのコンストラクタ
                    for (int q = 0; q < item.Length; ++q)
                    {
                        tmpList.Add(new List<string>());
                    }

                    for (int m = 0; m < item.Length; ++m)
                    {

                        int o = 0;
                        if (item.Substring(m, 1) == ".")
                        {
                            foreach (var item2 in list)
                            {
                                tmpList[o++].Add(item2.Replace('#', '.'));
                            }
                        }
                        else
                        {
                            foreach (var item2 in list)
                            {
                                tmpList[o++].Add(item2);
                            }
                        }

                    }

                    foreach (var item2 in tmpList)
                    {
                        newList.Add(string.Join("", item2));
                    }

                    ++cnt;
                }

                list = newList;

            }


            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

        }
    }
    #endregion

}
