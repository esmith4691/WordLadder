using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
    internal sealed class ShortestPathFinder
    {
        private List<WordChain> chainsToProcess = new List<WordChain>();
        private Dictionary<string, List<string>> wordBuckets = new Dictionary<string, List<string>>();
        private List<string> possibleWords;

        private ShortestPathFinder() { }
        internal ShortestPathFinder(IEnumerable<string> words)
        {
            possibleWords = FilterToValidWords(words).ToList();
        }

        internal static IEnumerable<string> FilterToValidWords(IEnumerable<string> words)
        {
            return words.Where(w => w.IsValidWord()).Select(w => w.ToUpper());
        }

        internal IEnumerable<string> FindShortestPath(string startWord, string endWord)
        {
            startWord = startWord.ToUpper();
            endWord = endWord.ToUpper();

            chainsToProcess.Add(new WordChain(startWord, startWord));
            possibleWords.Remove(startWord);

            while (chainsToProcess.Any())
            {
                var currentChain = chainsToProcess.First();
                var forwardSteps = GetPossibleNextWords(currentChain.EndWord).ToList();

                if (forwardSteps.Contains(endWord))
                    return new WordChain(currentChain,endWord).Path;

                CreateChains(currentChain, forwardSteps);

                foreach(var word in forwardSteps)
                    possibleWords.Remove(word);
                    
                chainsToProcess.RemoveAt(0);
            }

            return new List<string>();
        }

        private void CreateChains(WordChain currentChain, IEnumerable<string> nextSteps)
        {
            chainsToProcess.AddRange(nextSteps.Select(word => new WordChain(currentChain,word)));
        }

        private IEnumerable<string> GetPossibleNextWords(string word)
        {
            return possibleWords.Where(w => word.IsOneLetterDifferent(w));
        }
    }
}
