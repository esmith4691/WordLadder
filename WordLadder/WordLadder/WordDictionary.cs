using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordLadder
{
    internal class WordDictionary
    {
        // TODO: maybe make this a singleton
        internal List<string> Words = new List<string>();

        internal void Load(string filename)
        {
            var content = new List<string>();

            try
            {
                content = File.ReadAllLines(filename).ToList();
            }
            catch(Exception)
            {
                return;
            }

            this.Words = GetValidWords(content).Distinct().Select(w => w.ToUpper()).ToList();
        }

        private static IEnumerable<string> GetValidWords(IEnumerable<string> content)
        {
            return content.Select(w => w.Trim()).Where(w => !string.IsNullOrEmpty(w) && w.IsValidWord());
        }
    }
}
