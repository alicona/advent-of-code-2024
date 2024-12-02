namespace Day02
{

    public sealed class SolutionProblem02
    {
        public int Calculate(List<string> input) 
        {
            var totalSafeReports = 0;

            foreach (var item in input)
            {
                var report = item.Split(' ').Select(i => Convert.ToInt32(i)).ToList();

                // if the list is safe, count
                if (SafetyChecker.IsSafe(report))
                {
                    totalSafeReports++;
                }
                // if the list is not safe, bruteforce removing one element at a time.
                else 
                {
                    for (int i = 0; i < report.Count; i++) 
                    {
                        // make a copy of the original report
                        var newReport = new List<int>(report);
                        
                        // remove one element.
                        newReport.RemoveAt(i);

                        // check if it is safe
                        if (SafetyChecker.IsSafe(newReport))
                        {
                            totalSafeReports++;
                            break;
                        }                    
                    }
                }
            }

            return totalSafeReports;
        }
    }
}
