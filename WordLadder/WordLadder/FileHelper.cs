using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
    internal static class FileHelper
    {
        internal static bool TryWriteResult(string filename, IEnumerable<string> content)
        {
            try
            {
                File.WriteAllLines(filename, content);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        internal static IEnumerable<string> LoadWordsFrom(string filename)
        {
            var content = new List<string>();

            try
            {
                content = File.ReadAllLines(filename).ToList();
            }
            catch (Exception)
            {
            }

            return GetValidWords(content).Distinct();
        }

        private static IEnumerable<string> GetValidWords(IEnumerable<string> content)
        {
            return content.Select(w => w.Trim()).Where(w => !string.IsNullOrEmpty(w) && w.IsValidWord());
        }
        
    }
}
