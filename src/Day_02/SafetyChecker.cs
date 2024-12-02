using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal static class SafetyChecker
    {
        public static bool IsSafe(IList<int> report)
        {
            int num1 = report[0];
            int num2 = report[1];

            if (num1 == num2) return false;

            if (IsAscending(num1, num2))
            {
                return CheckAscendingConditions(report);
            }

            if (IsDescending(num1, num2))
            {
                return CheckDescendingConditions(report);
            }

            return false;
        }

        private static bool IsAscending(int num1, int num2)
        {
            if (num2 < num1) return false;

            var difference = num2 - num1;

            if (difference > 0 && difference <= 3) return true;

            return false;
        }

        private static bool IsDescending(int num1, int num2)
        {
            if (num2 > num1) return false;

            var difference = num1 - num2;

            if (difference > 0 && difference <= 3) return true;

            return false;
        }

        private static bool CheckAscendingConditions(IList<int> report)
        {
            for (int i = 1; i < report.Count; i++)
            {
                if (!IsAscending(report[i - 1], report[i])) return false;
            }

            return true;
        }

        private static bool CheckDescendingConditions(IList<int> report)
        {
            for (int i = 1; i < report.Count; i++)
            {
                if (!IsDescending(report[i - 1], report[i])) return false;
            }

            return true;
        }
    }
}
