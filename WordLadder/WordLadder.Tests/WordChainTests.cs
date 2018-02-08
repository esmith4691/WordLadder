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
        public void Initialises_chain_correctly_if_start_word_is_end_word()
        {
            var sut = new WordChain("word", "word");

            Assert.AreEqual("word", sut.EndWord);
            Assert.AreEqual(new[] { "word" }, sut.Path);
        }

        [Test]
        public void Adds_another_word_correctly()
        {
            var sut = new WordChain("word", "anotherWord");
            var result = new WordChain(sut,"finalWord");

            Assert.AreEqual("finalWord", result.EndWord);
            Assert.AreEqual(new[] { "word", "anotherWord", "finalWord" }, result.Path);
        }

        [Test]
        public void Adds_another_word_correctly_if_word_is_already_end_word()
        {
            var sut = new WordChain("word", "anotherWord");
            var result = new WordChain(sut, "anotherWord");

            Assert.AreEqual("anotherWord", result.EndWord);
            Assert.AreEqual(new[] { "word", "anotherWord" }, result.Path);
        }
    }
}
