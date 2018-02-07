using System;
using System.Collections.Generic;
using System.IO;

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
