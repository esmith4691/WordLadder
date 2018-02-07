using System.IO;
using System.Reflection;

namespace WordLadder.Tests
{
    internal static class TestHelper
    {
        internal static string GetAssemblyDirectory()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyFileName = assembly.Location;
            return assemblyFileName.Remove(assemblyFileName.LastIndexOf('\\'));
        }

        internal static string GetTestFilePath() => Path.Combine(TestHelper.GetAssemblyDirectory(), "Resources", "testFile.txt");
    }
}
