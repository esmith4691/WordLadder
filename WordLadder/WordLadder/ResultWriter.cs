using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordLadder
{
    internal static class ResultWriter
    {
        internal static bool WriteResult(string filename, IEnumerable<string> content)
        {
            try
            {
                File.WriteAllLines(filename, content);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
