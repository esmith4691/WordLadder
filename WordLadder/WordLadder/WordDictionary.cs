using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
    internal class WordDictionary
    {
        internal List<string> Words = new List<string>();

        internal bool TryLoad(string filename)
        {
            var content = new List<string>();

            try
            {
                content = File.ReadAllLines(filename).ToList();
            }
            catch(Exception)
            {
                return false;
            }

            this.Words = GetValidWords(content).Distinct().Select(w => w.ToUpper()).ToList();
            return true;
        }

        private static IEnumerable<string> GetValidWords(IEnumerable<string> content)
        {
            return content.Select(w => w.Trim()).Where(w => !string.IsNullOrEmpty(w) && w.IsValidWord());
        }
    }
}
