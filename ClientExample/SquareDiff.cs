using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientExample
{
    public static class SquareDiff
    {
        public static double GetSquareDiff(List<double> list)
        {
            return Math.Sqrt(GetDisp(list));
        }

        private static double GetDisp(List<double> list)
        {
            double res = 0;
            double matOj = GetMatOj(list);
            for (int i = 0; i < list.Count; i++)
            {
                res += (list[i] - matOj) * (list[i] - matOj);
            }
            return res / list.Count;
        }
        private static double GetMatOj(List<double> list)
        {
            return (list.Sum() / list.Count);
        }
    }
}
