using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder.Tests
{
    [TestFixture]
    public class WordChainTests
    {
        [Test]
        public void Initialises_chain_correctly()
        {
            var sut = new WordChain("word", "anotherWord");

            Assert.AreEqual("anotherWord", sut.EndWord);
            Assert.AreEqual(new[] { "word", "anotherWord" }, sut.Path);
        }

        [Test]
        public void Adds_another_word_correctly()
        {
            var sut = new WordChain("word", "anotherWord");
            sut.AddWordToChain("finalWord");

            Assert.AreEqual("finalWord", sut.EndWord);
            Assert.AreEqual(new[] { "word", "anotherWord", "finalWord" }, sut.Path);
        }
    }
}
