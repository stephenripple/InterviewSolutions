using System;
using System.Collections.Generic;

namespace InterviewSolutions
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = PascalsTriange(5);
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

        //public IList<IList<int>> Generate(int numRows)
        //{
        //    IList<IList<int>> result = new List<IList<int>>();

        //    for (int i = 0; i < numRows; i++)
        //    {
        //        List<int> row = new List<int>() { 1 };

        //        for (int j = 1; j < i; j++)
        //        {
        //            row.Add(result[i - 1].ElementAt(j - 1) + result[i - 1].ElementAt(j));

        //        }
        //        if (i != 0) row.Add(1);
        //        result.Add(row);

        //    }

        //    return result;
        //}
        #endregion
    }
}
