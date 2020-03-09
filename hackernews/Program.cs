using hackernews.Classes;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace hackernews
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("up an running");

            var numberOfPostRequested = 0;

            if (args.Count() > 1 && !string.IsNullOrEmpty(args[0]) && args[0].Equals("--posts") &&
                int.TryParse(args[1], out numberOfPostRequested) && numberOfPostRequested <= 100)
            {
                await Scraper.Posts(numberOfPostRequested);

            }
            else
            {
                Console.WriteLine("***********[ HOW TO USE ME ]*********\n\n");
                Console.WriteLine("hackernews.exe --posts n\n");
                Console.WriteLine("n is the number of posts you want to see, less or equal to 100 n\n");
            }



        }
    }
}
