using System.Text.RegularExpressions;

namespace Day03
{
    internal static class Parser
    {
        public static long Parse(string s) 
        {
            long total = 0;
            string regex = @"mul\([0-9]{1,3},[0-9]{1,3}\)";
            var matches = Regex.Matches(s, regex).ToList();

            foreach (var m in matches)
            {
                var index1 = m.Value.IndexOf('(');
                var index2 = m.Value.IndexOf(')');

                var nums = m.Value.Substring(index1 + 1, index2 - index1 - 1).Split(',').Select(n => Convert.ToInt32(n)).ToList();

                total += nums[0] * nums[1];
            }

            return total;
        }
    }
}
