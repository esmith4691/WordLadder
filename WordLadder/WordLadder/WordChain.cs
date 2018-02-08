using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
    internal class WordChain
    {
        internal string EndWord { get; private set; }
        internal List<string> Path { get; private set; }

        internal WordChain(string startWord, string endWord)
        {
            EndWord = endWord;
            Path = new List<string> { startWord, endWord };
        }

        internal void AddWordToChain(string word)
        {
            EndWord = word;
            Path.Add(word);
        }
    }
}
