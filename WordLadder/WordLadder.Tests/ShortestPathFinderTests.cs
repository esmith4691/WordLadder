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
        ShortestPathFinderTests sut;

        [Test]
        public void CanInstantiate()
        {
            Assert.DoesNotThrow(() => new ShortestPathFinder(new [] { "word", "ward", "card", "care" }));
        }

        [Test]
        public void CanInstantiateWithEmptyCollection()
        {
            Assert.DoesNotThrow(() => new ShortestPathFinder(new string[] { }));
        }
    }
}
