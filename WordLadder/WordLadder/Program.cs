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
                var result = ProcessRequest(input);
                Console.WriteLine(result);
            }
        }

        internal static string ProcessRequest(string input)
        {
            try
            {
                var args = input.Split(' ').Select(a => a.Trim()).Where(a => !string.IsNullOrEmpty(a));
                if (args.Count() != 4)
                    return "Incorrect number of parameters: Please check the input and try again:";

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return $"An error has occurred. Please try again:";
            }
        }
    }
}
