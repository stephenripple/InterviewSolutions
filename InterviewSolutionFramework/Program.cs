using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewSolutionFramework
{
    class Program
    {
        public int MAXROW = 20;
        public int MAXY = 20;

        static void Main(string[] args)
        {
            popData();
            var test = string.Empty;
        }

        #region "PascalsTriange"
        public static IList<IList<int>> PascalsTriange(int numRows)
        {
            IList<IList<int>> ret = new List<IList<int>>();
            List<int> listRoot = new List<int>() { 1 };
            List<int> listFirst = new List<int>() { 1, 1 };
            ret.Add(listRoot);
            ret.Add(listFirst);

            for (int x = 2; x < numRows; x++)
            {
                var row = new List<int>() { 1 };
                for (int y = 0; y < (x - 1); y++)
                {
                    row.Add(CalculateRow(ret[x - 1], y));
                }
                row.Add(1);
                ret.Add(row);
            }

            return ret;
        }

        public static int CalculateRow(IList<int> TopRow, int Column)
        {
            return TopRow[Column] + TopRow[Column + 1];
        }

        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < numRows; i++)
            {
                List<int> row = new List<int>() { 1 };

                for (int j = 1; j < i; j++)
                {
                    row.Add(result[i - 1].ElementAt(j - 1) + result[i - 1].ElementAt(j));

                }
                if (i != 0) row.Add(1);
                result.Add(row);

            }

            return result;
        }
        #endregion

        public static int[] SortedSquares(int[] nums)
        {
            var ret = nums.ToList<int>();
            for (int x = 0; x < ret.Count; x++)
            {
                ret[x] = ret[x] * ret[x];
            }
            ret.Sort();
            return ret.ToArray();
        }

        public static string CustomSortString(string order, string s)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < order.Length; i++)
                dict[order[i]] = i;

            for (int i = 0; i < s.Length; i++)
            {
                if (!dict.ContainsKey(s[i]))
                    dict[s[i]] = -1;
            }

            char[] chr = s.ToCharArray();
            Array.Sort(chr, (a, b) =>
            {
                return dict[a] > dict[b] ? 1 : dict[a] == dict[b] ? 0 : -1;
            });

            return new string(chr);
        }

        public static int ABGame(double x)
        {
            int n = 1;

            double a = 1;
            double b = x;

            while (true)
            {
                //B Gives
                if (a <= b)
                {
                    b -= x;
                    a += x;
                }
                //B Takes
                else
                {
                    a -= x;
                    b += x;
                }

                if (a == b)
                    break;
                else
                    n++;
            }

            return n;
        }

        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            TreeNode rootNode = new TreeNode(1, new TreeNode(0), new TreeNode(2));

            return rootNode;
        }


        public static void popData()
        {

            //runway = [9, 7]
            //airplanes = [[9, 9, '^'], [6, 9, '>']] 

            var airplanes = new List<Plane>();
            airplanes.Add(new Plane(9, 7, "X"));
            airplanes.Add(new Plane(9, 9, "^"));
            airplanes.Add(new Plane(6, 9, ">"));

            printGrid(airplanes);

            foreach (var plane in airplanes)
            {
                movePlane(plane);
            }

            Console.WriteLine();
            Console.WriteLine();

            printGrid(airplanes);
        }

        public static void printGrid(List<Plane> airplanes)
        {
            int MAXROW = 20;
            int MAXCOLUMN = 20;

            for (int j = 1; j <= MAXROW; j++)
            {
                for (int i = 1; i <= MAXCOLUMN; i++)
                {
                    if (airplanes.Any(c => c.row == j - 1 && c.col == i - 1))
                    {
                        var airplane = airplanes.First(c => c.row == j - 1 && c.col == i - 1);

                        Console.Write(airplane.icon + " ");
                    }
                    else
                        Console.Write(". ");
                }
                Console.WriteLine();
            }
        }

        public static void movePlane(Plane airplane)
        {
            switch (airplane.icon)
            {
                case "^":
                    airplane.row--;
                    break;
                case ">":
                    airplane.col++;
                    break;
                case "<":
                    airplane.col--;
                    break;
                case "v":
                    airplane.row++;
                    break;
            }
        }
    }

    public class Plane
    {
        public int col;
        public int row;
        public string icon;

        public Plane(int inputCol, int inputRow, string inputIcon)
        {
            col = inputCol;
            row = inputRow;
            icon = inputIcon;
        }

        public bool MatchLocation(int inputCol, int inputRow)
        {
            if (col == inputCol && row == inputRow)
                return true;
            else
                return false;
        }
    }


    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
