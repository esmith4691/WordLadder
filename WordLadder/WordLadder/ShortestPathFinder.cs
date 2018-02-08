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

        private ShortestPathFinder() { }
        internal ShortestPathFinder(IEnumerable<string> words)
        {
            possibleWords = words.Select(w => w.ToUpper()).ToList();
            wordsToProcess = new List<string>();
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

                CreateChains(forwardSteps);

                foreach(var word in forwardSteps)
                    possibleWords.Remove(word);

                wordsToProcess.AddRange(forwardSteps);
                wordsToProcess.RemoveAt(0);
            }

            return new List<string>();
        }

        private void CreateChains(IEnumerable<string> nextSteps)
        {
            throw new NotImplementedException();
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
