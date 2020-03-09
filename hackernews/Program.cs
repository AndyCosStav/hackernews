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
            
            //validating args to ensure that what is entered is valid e.g only --posts n are accepted 
            if (args.Count() > 1 && !string.IsNullOrEmpty(args[0]) && args[0].Equals("--posts") &&
                int.TryParse(args[1], out numberOfPostRequested) && numberOfPostRequested <= 100)
            {
                //if correct launch app with number of requested posts
                await Scraper.Posts(numberOfPostRequested);

            }
            else
            {
                //if args are incorrect, displays how to use app
                Console.WriteLine("***********[ HOW TO USE ME ]*********\n\n");
                Console.WriteLine("hackernews.exe --posts n\n");
                Console.WriteLine("n is the number of posts you want to see, less or equal to 100 n\n");
            }



        }
    }
}
