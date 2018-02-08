using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder.Tests
{
    [TestFixture]
    public class ShortestPathFinderTests
    {
        [Test]
        public void Can_instantiate()
        {
            Assert.DoesNotThrow(() => new ShortestPathFinder(new [] { "word", "ward", "card", "care" }));
        }

        [Test]
        public void Can_instantiate_with_empty_collection()
        {
            Assert.DoesNotThrow(() => new ShortestPathFinder(new string[] { }));
        }

        [Test]
        public void Filters_to_valid_words()
        {
            var input = new[] { "\\9th", "w sh", "wash", "wish", "wishy", "wise", "wipe", "pipe", "was" };
            var expectedWords = new[] { "WASH", "WISH", "WISE", "WIPE", "PIPE" };

            Assert.AreEqual(expectedWords, ShortestPathFinder.FilterToValidWords(input));
        }

        [Test]
        public void Returns_empty_collection_when_no_path()
        {
            var sut = new ShortestPathFinder(new[] { "word", "ward", "card", "care" });

            var result = sut.FindShortestPath("word", "xxxx");

            Assert.IsEmpty(result);
        }

        [Test]
        public void Returns_correct_collection_when_path_exists()
        {
            var sut = new ShortestPathFinder(new[] { "word", "ward", "card", "care" });

            var result = sut.FindShortestPath("word", "care");

            Assert.AreEqual(new[] { "WORD", "WARD", "CARD", "CARE" }, result);
        }

        [Test]
        public void Returns_shortest_collection_when_path_exists()
        {
            var sut = new ShortestPathFinder(new[] { "word", "ward", "card", "care", "cure", "curd" });

            var result = sut.FindShortestPath("word", "curd");

            Assert.AreEqual(new[] { "WORD", "WARD", "CARD", "CURD" }, result);
        }
    }
}
