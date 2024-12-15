namespace Day05
{
    public record Rule (int PageBefore, int PageAfter);
    internal static class Helpers
    {
        public static Dictionary<int, List<int>> CreateDictionaryOfRules(List<Rule> rules) 
        {
            var rulesDictionary = new Dictionary<int, List<int>>();
            // Create dictionary of rules
            foreach (var rule in rules)
            {

                if (!rulesDictionary.ContainsKey(rule.PageBefore))
                {
                    rulesDictionary.Add(rule.PageBefore, new List<int>());
                }

                rulesDictionary[rule.PageBefore].Add(rule.PageAfter);
            }

            return rulesDictionary;
        }

        public static bool IsValidUpdate(Dictionary<int, List<int>> rules, List<int> update, out int currentPage, out int invalidPage )
        {
            var hashset = new HashSet<int>();
            currentPage = -1;
            invalidPage = -1;

            foreach (var page in update)
            {
                if (rules.TryGetValue(page, out var list))
                {
                    for (int i = 0; i < list.Count; i++) 
                    {
                        var l = list[i];
                        if (hashset.Contains(l))
                        { 
                            currentPage = update.IndexOf(page);
                            invalidPage =  update.IndexOf(l);
                            return false; 
                        } 
                    }
                }
                hashset.Add(page);

            }
            return true;
        }

        public static int FixUpdate(Dictionary<int, List<int>> rules, List<int> update) 
        {
            var isValid = IsValidUpdate(rules, update, out int currentPage, out int invalidPage);
            if (isValid) return 0;

            while (!isValid)
            {
                var invalidPageValue = update[invalidPage];
                update[invalidPage] = update[currentPage];
                update[currentPage] = invalidPageValue;

                isValid = IsValidUpdate(rules, update, out currentPage, out invalidPage);
            }

            return update[update.Count / 2];
        }
    }
}
