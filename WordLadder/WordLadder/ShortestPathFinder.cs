﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
    internal sealed class ShortestPathFinder
    {
        private HashSet<string> processedWords = new HashSet<string>();
        private List<WordChain> chainsToProcess = new List<WordChain>();
        private Dictionary<string, List<string>> wordBuckets = new Dictionary<string, List<string>>();

        private ShortestPathFinder() { }
        internal ShortestPathFinder(IEnumerable<string> words)
        {
            FillBuckets(words.Select(w => w.ToUpper()).ToList());
        }

        internal IEnumerable<string> FindShortestPath(string startWord, string endWord)
        {
            startWord = startWord.ToUpper();
            endWord = endWord.ToUpper();

            chainsToProcess.Add(new WordChain(startWord, startWord));
            processedWords.Add(startWord);

            while (chainsToProcess.Any())
            {
                var currentChain = chainsToProcess.First();
                var forwardSteps = GetPossibleNextWords(currentChain.EndWord).ToList();

                if (forwardSteps.Contains(endWord))
                    return new WordChain(currentChain,endWord).Path;

                CreateChains(currentChain, forwardSteps);

                foreach(var word in forwardSteps)
                    processedWords.Add(word);

                chainsToProcess.RemoveAt(0);
            }

            return new List<string>();
        }

        private void FillBuckets(IEnumerable<string> words)
        {
            var arrWords = words.ToArray();

            for(var j = 0; j < arrWords.Length; j++)
            {
                var word = arrWords[j];

                for (var i = 0; i < word.Length; i++)
                {
                    var bucketKey = GetBucketKey(word, i);
                    var bucketWords = new List<string>();

                    List<string> existingWords;
                    if (wordBuckets.TryGetValue(bucketKey, out existingWords))
                        bucketWords.AddRange(existingWords);

                    bucketWords.Add(word);
                    wordBuckets[bucketKey] = bucketWords;
                }
            }
        }

        private string GetBucketKey(string word, int index)
        {
            var sb = new StringBuilder(word);
            sb[index] = '_';
            return sb.ToString();
        }

        private void CreateChains(WordChain currentChain, IEnumerable<string> nextSteps)
        {
            chainsToProcess.AddRange(nextSteps.Select(word => new WordChain(currentChain,word)));
        }

        private IEnumerable<string> GetPossibleNextWords(string word)
        {
            var bucketKeys = word.ToCharArray().Select((n, i) => GetBucketKey(word, i));
            return bucketKeys.SelectMany(k => GetUnprocessedWordsFromBucket(k)).Distinct().Except(new[] { word });
        }

        private IEnumerable<string> GetUnprocessedWordsFromBucket(string bucketKey)
        {
            return wordBuckets[bucketKey].Except(processedWords);
        }
    }
}
