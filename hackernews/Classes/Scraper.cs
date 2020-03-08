using hackernews.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace hackernews.Classes
{
    public static class Scraper
    {
        public static async Task<List<Post>> GetHtmlAsync(int numberOfPosts)
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

            IEnumerable<HtmlNode> commentsNodes = containingPoint.Where(n => n.HasClass("subtext"));

            var storyComments = commentsNodes.Select(n => n.SelectSingleNode("//a[3]").InnerText).ToList();

            for (int i = 0; i <= numberOfPosts; i++)
            {

                Post post = new Post();
                post.Title = storyTitle[i].InnerText;
                post.Uri = storyUrl[i].ToString();
                post.Author = storyAuthor[i].InnerText;
                post.Points = Convert.ToInt32(storyScore[i].InnerText);
                //post.Comments = Convert.TostoryComments[i];
                post.Rank = Convert.ToInt32(storyComments[i].ToString());
                posts.Add(post);

            }

            

            return posts;
                
              
            Console.WriteLine();

        }
    }
}
