using Day02;

namespace SolutionTest
{
    public sealed class SolutionTest
    {
        private Solution _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Solution();    
        }

        [Test]
        public void ShouldReturnCorrectNumberOfSafeReports()
        {
            var input = GetSampleInput();

            var result = _sut.Day02(input);

            Assert.That(result, Is.EqualTo(2));
        }

        private List<string> GetSampleInput() =>
            [
                "7 6 4 2 1",
                "1 2 7 8 9",
                "9 7 6 2 1",
                "1 3 2 4 5",
                "8 6 4 4 1",
                "1 3 6 7 9"
            ];
    }
}