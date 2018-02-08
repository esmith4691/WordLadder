using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
    internal sealed class ShortestPathFinder
    {
        private List<string> possibleWords;
        private List<WordChain> chainsToProcess;

        private ShortestPathFinder() { }
        internal ShortestPathFinder(IEnumerable<string> words)
        {
            possibleWords = words.Select(w => w.ToUpper()).ToList();
            chainsToProcess = new List<WordChain>();
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
                var currentWord = currentChain.EndWord;

                var forwardSteps = GetPossibleNextWords(currentWord).ToList();

                if (forwardSteps.Contains(endWord))
                    return new WordChain(currentChain,endWord).Path;

                var newChains = CreateChains(currentChain, forwardSteps);

                foreach(var word in forwardSteps)
                    possibleWords.Remove(word);

                chainsToProcess.AddRange(newChains);
                chainsToProcess.RemoveAt(0);
            }

            return new List<string>();
        }

        private IEnumerable<WordChain> CreateChains(WordChain currentChain, IEnumerable<string> nextSteps)
        {
            return nextSteps.Select(word => new WordChain(currentChain,word));
        }

        private IEnumerable<string> GetPossibleNextWords(string word)
        {
            return possibleWords.Where(w => word.IsOneLetterDifferent(w)); // TODO - this is going to be very slow for a big set
        }
    }
}
