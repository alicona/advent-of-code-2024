namespace Day06.Tests;

public class Tests
{
    private Solution _sut;
    [SetUp]
    public void Setup()
    {
        _sut = new Solution();
    }

    [Test]
    public void Problem01Test()
    {
        var result = _sut.Problem01();
        Assert.Pass();
    }

    [Test]
    public void Problem02Test() 
    {
        Assert.Pass();
    }
}