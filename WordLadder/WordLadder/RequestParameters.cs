using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
    internal sealed class RequestParameters
    {
        internal string DictionaryFile { get; private set; }
        internal string StartWord { get; private set; }
        internal string EndWord { get; private set; }
        internal string ResultFile { get; private set; }

        internal static RequestParameters TryParseParams(string input)
        {
            var args = input.Split(' ').Select(a => a.Trim()).Where(a => !string.IsNullOrEmpty(a)).ToArray();
            if (args.Count() != 4)
                return null;

            return new RequestParameters
            {
                DictionaryFile = args[0],
                StartWord = args[1],
                EndWord = args[2],
                ResultFile = args[3],
            };
        }

        private RequestParameters() { }
    }
}
