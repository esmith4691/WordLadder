using System;
using System.Collections.Generic;
using System.Linq;

namespace WordLadder
{
    internal static class RequestProcessor
    {
        internal static string ProcessRequest(string input)
        {
            var requestParams = RequestParameters.TryParseParams(input);

            if (requestParams == null)
                return "Invalid parameters: Please check the input and try again:";

            var startWord = requestParams.StartWord;
            var endWord = requestParams.EndWord;

            if (startWord == endWord || startWord.IsOneLetterDifferent(endWord))
                return WriteResult(requestParams.ResultFile, new[] { startWord, endWord });

            var words = FileHelper.LoadWordsFrom(requestParams.DictionaryFile);
            if (!words.Any())
                return $"No values loaded for dictionary: Please check file '{requestParams.DictionaryFile}'";

            var result = new ShortestPathFinder(words).FindShortestPath(startWord, endWord);
            if (!result.Any())
                return $"No path found between {startWord} and {endWord}";

            return WriteResult(requestParams.ResultFile, result);
        }

        private static string WriteResult(string filename, IEnumerable<string> content)
        {
            if(!FileHelper.TryWriteResult(filename, content))
                return $"Error writing results: Please check file '{filename}'";
            return "Success! Results written to file";
        }
    }
}
