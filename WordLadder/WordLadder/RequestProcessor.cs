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

            throw new NotImplementedException();
        }
    }
}
