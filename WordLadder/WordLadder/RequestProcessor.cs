using System;

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

            if(!ResultWriter.WriteResult(requestParams.ResultFile, result))
                return $"Error writing results: Please check file '{requestParams.ResultFile}'";

            throw new NotImplementedException();
        }
    }
}
