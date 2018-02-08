using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
    internal sealed class ShortestPathFinder
    {
        internal IEnumerable<string> Result { get; private set; }
        private IEnumerable<string> possibleWords;

        private ShortestPathFinder() { }
        internal ShortestPathFinder(IEnumerable<string> words)
        {
            possibleWords = words.Select(w => w.ToUpper());
        }
    }
}
