using Day05;
using System.Reflection;

namespace Day05Test
{
    internal sealed class SolutionProblem01Test
    {
        private SolutionProblem01 _sut;

        [SetUp]
        public void SetUp() 
        {
            _sut = new SolutionProblem01();
        }

        [TestCase("rules_sample.txt", "input_sample.txt", 143)]
        [TestCase("rules.txt", "input.txt", 5639)]
        public void Test(string rulesFileName, string inputFileName, int expected) 
        {
            var rules = GetRules(rulesFileName);
            var updates = GetUpdates(inputFileName);

            var result = SolutionProblem01.Calculate(rules, updates);

            Assert.That(result, Is.EqualTo(expected));
        }

        private List<Rule> GetRules(string fileName) 
        {
            var rules = ReadFile(fileName);
            var list = new List<Rule>();
            foreach (var rule in rules) 
            {
                var r = rule.Split('|').Select(i => Convert.ToInt32(i)).ToArray();
                list.Add(new Rule(r[0], r[1]));
            }

            return list;
        
        }

        private List<List<int>> GetUpdates(string fileName) 
        {
            var fileContent = ReadFile(fileName);
            var list = new List<List<int>>();
            foreach (var line in fileContent) 
            {
                var l = line.Split(",").Select(i => Convert.ToInt32(i)).ToList();
                list.Add(new List<int>(l));
                
            }

            return list;
        }

        private IEnumerable<string> ReadFile(string fileName) 
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith(fileName));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
