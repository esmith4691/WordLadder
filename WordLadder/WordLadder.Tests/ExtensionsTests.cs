using NUnit.Framework;

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


        [TestCase("word", "aword")]
        [TestCase("word", "wrd")]
        
        [TestCase("word", "word")]
        [TestCase("word", "card")]
        [Test]
        public void Check_words_do_not_have_one_letter_different(string word, string otherWord)
        {
            Assert.IsFalse(word.IsOneLetterDifferent(otherWord));
        }

        [TestCase("word", "lord")]
        [TestCase("word", "ward")]
        [TestCase("word", "woed")]
        [TestCase("word", "work")]
        [TestCase("word", "wArd")]
        [Test]
        public void Check_words_do_have_one_letter_different(string word, string otherWord)
        {
            Assert.IsTrue(word.IsOneLetterDifferent(otherWord));
        }
    }
}
