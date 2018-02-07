using System;
using System.Linq;

namespace WordLadder
{
    internal static class RequestProcessor
    {
        internal static string ProcessRequest(string input)
        {
            var args = input.Split(' ').Select(a => a.Trim()).Where(a => !string.IsNullOrEmpty(a));
            if (args.Count() != 4)
                return "Incorrect number of parameters: Please check the input and try again:";

            throw new NotImplementedException();
        }
    }
}
