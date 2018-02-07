using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
