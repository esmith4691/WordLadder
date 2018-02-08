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
            possibleWords.Remove(startWord);

            while (wordsToProcess.Any())
            {
                var currentWord = wordsToProcess.First();

                var forwardSteps = GetPossibleNextWords(currentWord);

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
            var chainToUpdate = chains.FirstOrDefault(c => c.EndWord == startWord);

            if (chainToUpdate == null)
                chains.AddRange(nextSteps.Select(word => new WordChain(startWord, word)));
            else
                foreach (var word in nextSteps)
                    chainToUpdate.AddWordToChain(word);
        }

        private IEnumerable<string> GetRouteTo(string word)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> GetPossibleNextWords(string word)
        {
            return possibleWords.Where(w => word.IsOneLetterDifferent(w)); // TODO - this is going to be very slow for a big set
        }
    }
}
