using System.Reflection;

namespace TestHelpers;

public static class TestHelper 
{
    public static char[][] ConvertToCharMatrix(IEnumerable<string> input) 
    {
        return input.Select(str => str.ToArray()).ToArray();
    }

    public static IEnumerable<string> ReadFile(string fileName, Assembly assembly)
    {
        var resourceName = assembly.GetManifestResourceNames()
        .Single(str => str.EndsWith(fileName));

        using var stream = assembly.GetManifestResourceStream(resourceName);
        using var reader = new StreamReader(stream);

        while (reader.ReadLine() is string line)
        {
            yield return line;
        }
    }
}
