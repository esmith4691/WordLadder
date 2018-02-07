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


            var wordDictionary = new WordDictionary();
            wordDictionary.Load(requestParams.DictionaryFile);

            if (!wordDictionary.Words.Any())
                return $"No values loaded for dictionary: Please check file '{requestParams.DictionaryFile}'";

            var result = new string[] { };

            return WriteResult(requestParams.ResultFile, result);
        }

        private static string WriteResult(string fileName, IEnumerable<string> result)
        {
            if (!ResultWriter.WriteResult(fileName, result))
                return $"Error writing results: Please check file '{fileName}'";

            return "Success! Results written to file";
        }
    }
}
