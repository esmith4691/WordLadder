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
            if (!wordDictionary.TryLoad(requestParams.DictionaryFile))
                return $"Error loading dictionary: Please check file '{requestParams.DictionaryFile}'";

            throw new NotImplementedException();
        }
    }
}
