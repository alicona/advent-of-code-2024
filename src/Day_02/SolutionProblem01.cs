namespace Day02
{
    public sealed class SolutionProblem01
    {
        public int Calculate(List<string> input) 
        {
            var totalSafeReports = 0;

            foreach (var item in input) 
            {
                var report = item.Split(' ').Select(i => Convert.ToInt32(i)).ToList();

                if (SafetyChecker.IsSafe(report)) 
                {
                    totalSafeReports++;
                }
            }


            return totalSafeReports;
        }

        
    }
}
