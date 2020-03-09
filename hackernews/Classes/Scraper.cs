using hackernews.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace hackernews.Classes
{
    public static class Scraper
    {
        public static async Task<string> Posts(int numberOfPosts)
        {
            var posts = new List<Post>();

            var url = "https://news.ycombinator.com/";

            var client = new HttpClient();
            var html = await client.GetStringAsync(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html.Replace("&nbsp;", ""));

            var containingPoint = htmlDoc.DocumentNode.Descendants();

            var storyTitle = containingPoint.Where(n => n.HasClass("storylink")).ToList();

            var storyAuthor = containingPoint.Where(n => n.HasClass("hnuser")).ToList();

            var storyScore = containingPoint.Where(n => n.HasClass("score")).ToList();

            var storyRank = containingPoint.Where(n => n.HasClass("rank")).ToList();

            IEnumerable<HtmlNode> urlNodes = storyTitle;

            var storyUrl = urlNodes.Select(n => n.GetAttributeValue("href", string.Empty)).ToList();


            var storyComments  =
                htmlDoc.DocumentNode.SelectNodes("//td[@class = 'subtext']/a[starts-with(@href, 'item')]").ToList();

            for (int i = 0; i < numberOfPosts; i++)
            {
                Post post = new Post();
                post.Title = Utility.ValidateString(storyTitle[i].InnerText);
                post.Uri = Utility.ValidateUrl(storyUrl[i]);
                post.Author = Utility.ValidateString(storyAuthor[i].InnerText);
                post.Points = int.Parse(storyScore[i].InnerText.Replace(" points", ""));
                post.Comments = Utility.ConvertComments(storyComments[i].InnerText);
                post.Rank = Convert.ToInt32(storyRank[i].InnerText.Replace(".", ""));
                posts.Add(post);
            }

            

            string json = JsonConvert.SerializeObject(posts, Formatting.Indented);

            Console.WriteLine(json);


            return json;

        }
    }
}
