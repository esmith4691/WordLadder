using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder.Tests
{
    [TestFixture]
    public class ResultWriterTests
    {
        [SetUp]
        public void SetUp()
        {
            Directory.CreateDirectory(Path.Combine(GetAssemblyDirectory(), "output"));
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(Path.Combine(GetAssemblyDirectory(), "output"), recursive: true);
        }

        [Test]
        public void Verify_result_written_correctly()
        {
            var content = new[] { "test", "results", "look", "like", "this" };
            var filename = Path.Combine(GetAssemblyDirectory(), "output", "testResult.txt");
            var result = ResultWriter.WriteResult(filename, content );

            Assert.IsTrue(result);
            var fileContent = File.ReadAllLines(filename);
            Assert.AreEqual(content, fileContent);
        }

        string GetAssemblyDirectory()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyFileName = assembly.Location;
            return assemblyFileName.Remove(assemblyFileName.LastIndexOf('\\'));
        }
    }
}
