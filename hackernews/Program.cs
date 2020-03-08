using hackernews.Classes;
using System;
using System.Threading.Tasks;

namespace hackernews
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Scraper.GetHtmlAsync(10);
        }
    }
}
