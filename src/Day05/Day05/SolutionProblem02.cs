namespace Day05
{
    public class SolutionProblem02
    {
        public int Calculate(List<Rule> rules, List<List<int>> updates)
        {
            var rulesDictionary = Helpers.CreateDictionaryOfRules(rules);

            var total = 0;
            foreach (var update in updates)
            {
                total += Helpers.FixUpdate(rulesDictionary, update);
            }
            return total;
        }
    }
}
