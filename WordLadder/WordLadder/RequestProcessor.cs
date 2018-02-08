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

            if (requestParams.StartWord == requestParams.EndWord || requestParams.StartWord.IsOneLetterDifferent(requestParams.EndWord))
                return WriteResult(requestParams.ResultFile, new[] { requestParams.StartWord, requestParams.EndWord });

            var words = FileHelper.LoadWordsFrom(requestParams.DictionaryFile);
            if (!words.Any())
                return $"No values loaded for dictionary: Please check file '{requestParams.DictionaryFile}'";

            var result = new string[] { };

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
