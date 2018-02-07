using System.Linq;

namespace WordLadder
{
    internal static class Extensions
    {
        internal static bool HasOnlyLetters(this string word)
        {
            var characters = word.ToCharArray();
            return characters.All(c => char.IsLetter(c));
        }

        internal static bool IsValidWord(this string word)
        {
            return word.Length == Constants.WordSize && word.HasOnlyLetters();
        }

        internal static bool IsOneLetterDifferent(this string word, string otherWord)
        {
            if (word.Length != otherWord.Length || word == otherWord)
                return false;

            var numberOfLettersDifferent = 0;

            for(var i = 0; i < word.Length; i ++)
            {
                if (word[i] != otherWord[i])
                    numberOfLettersDifferent++;
            }

            return numberOfLettersDifferent == 1;
        }
    }
}
