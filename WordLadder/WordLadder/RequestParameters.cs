using System.Linq;

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
            var args = input.Split(' ').Where(a => !string.IsNullOrWhiteSpace(a)).ToArray();
            if (!HasCorrectNumberOfParams(args))
                return null;

            var dictionaryFile = args[0];
            var startWord = args[1];
            var endWord = args[2];
            var resultFile = args[3];

            if (!HasValidFileExtension(dictionaryFile) || !HasValidFileExtension(resultFile))
                return null;

            if (!startWord.IsValidWord() || !endWord.IsValidWord())
                return null;

            return new RequestParameters
            {
                DictionaryFile = dictionaryFile,
                StartWord = startWord,
                EndWord = endWord,
                ResultFile = resultFile
            };
        }

        private static bool HasCorrectNumberOfParams(string[] args) => args.Length == 4;
        private static bool HasValidFileExtension(string filename) => filename.EndsWith(".txt");

        private RequestParameters() { }
    }
}
