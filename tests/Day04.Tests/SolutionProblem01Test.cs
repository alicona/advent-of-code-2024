using System.Reflection;

namespace Day04
{
    [TestFixture]
    internal sealed class SolutionProblem01Test
    {
        private SolutionProblem01 _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new SolutionProblem01();
        }

        [Test]
        public void Test1()
        {
            var input =  GetInput();
            var result = _sut.Calculate(input, "XMAS");

            Assert.Pass();
        }

        private char[][] GetInput() 
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames()
                .Single(str => str.EndsWith("input.aoc"));

            var charlist = new List<List<char>>();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var l =  new List<char>();
                    foreach (char c in line) 
                    {
                        l.Add(c);
                    }
                    charlist.Add(l);
                }

                // Convert to char array

                return charlist.Select(c => c.ToArray()).ToArray();
            }
        }
    }
}