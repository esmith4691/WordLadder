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
        private List<string> wordsToProcess;
        private List<WordChain> chains;

        private ShortestPathFinder() { }
        internal ShortestPathFinder(IEnumerable<string> words)
        {
            possibleWords = words.Select(w => w.ToUpper()).ToList();
            wordsToProcess = new List<string>();
            chains = new List<WordChain>();
        }

        internal IEnumerable<string> FindShortestPath(string startWord, string endWord)
        {
            startWord = startWord.ToUpper();
            endWord = endWord.ToUpper();

            wordsToProcess.Add(startWord);
            chains.Add(new WordChain(startWord, startWord));
            possibleWords.Remove(startWord);

            while (wordsToProcess.Any())
            {
                var currentWord = wordsToProcess.First();

                var forwardSteps = GetPossibleNextWords(currentWord).ToList();

                if (forwardSteps.Contains(endWord))
                    return GetRouteTo(currentWord).Union(new[] { endWord });

                CreateChains(currentWord, forwardSteps);

                foreach(var word in forwardSteps)
                    possibleWords.Remove(word);

                wordsToProcess.AddRange(forwardSteps);
                wordsToProcess.RemoveAt(0);
            }

            return new List<string>();
        }

        private void CreateChains(string startWord, IEnumerable<string> nextSteps)
        {
            var chainToUpdate = chains.First(c => c.EndWord == startWord);

            foreach (var word in nextSteps)
                chainToUpdate.AddWordToChain(word);
        }

        private IEnumerable<string> GetRouteTo(string word)
        {
            // TODO - this query is also above, find a way of not needing to perform this
            return chains.First(c => c.EndWord == word).Path;
        }

        private IEnumerable<string> GetPossibleNextWords(string word)
        {
            return possibleWords.Where(w => word.IsOneLetterDifferent(w)); // TODO - this is going to be very slow for a big set
        }
    }
}
