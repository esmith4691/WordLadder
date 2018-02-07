using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder.Tests
{
    [TestFixture]
    public class ExtensionsTests
    {
        [Test]
        public void Check_all_letter_word_of_correct_size_is_valid()
        {
            Assert.IsTrue("word".IsValidWord());
        }

        [Test]
        public void Check_all_letter_word_of_wrong_size_is_invalid()
        {
            Assert.IsFalse("wordy".IsValidWord());
        }

        [Test]
        public void Check_word_with_number_of_correct_size_is_invalid()
        {
            Assert.IsFalse("w0rd".IsValidWord());
        }

        [Test]
        public void Check_word_with_punctuation_of_correct_size_is_invalid()
        {
            Assert.IsFalse("w_rd".IsValidWord());
        }
    }
}
