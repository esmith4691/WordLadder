using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("WordLadder.Tests")]
namespace WordLadder
{
    internal static class Program
    {
        static readonly string desiredFormat = "<dictionaryFile> <startWord> <endWord> <resultFile>";

        static void Main(string[] args)
        {
            Console.Write($"Please enter you request in the format '{desiredFormat}':");

            while (true)
            {
                var input = Console.ReadLine();

                try
                {
                    var result = RequestProcessor.ProcessRequest(input);
                    Console.WriteLine(result);
                }
                catch(Exception)
                {
                    Console.WriteLine($"An error has occurred. Please try again:");
                }
            }
        }
    }
}
