namespace Day05
{
    public class SolutionProblem01
    {
        public static int Calculate(List<Rule> rules, List<List<int>> updates)
        {
            var rulesDictionary = Helpers.CreateDictionaryOfRules(rules); 

            var total = 0;
            foreach (var update in updates) 
            {
                if (Helpers.IsValidUpdate(rulesDictionary, update, out _, out _)) 
                {
                    var indexOfMiddlePage = update.Count / 2;
                    total += update[indexOfMiddlePage];
                }
            }
            return total;
        }
    }
}
