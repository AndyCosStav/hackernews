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
            //generate empty list where completed posts will sit
            var posts = new List<Post>();

            var url = "https://news.ycombinator.com/";

            var client = new HttpClient();
            var html = await client.GetStringAsync(url);

            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html.Replace("&nbsp;", ""));

            //using HtmlAgilityPack to get the value of each class I require for my model and adding them to individual lists 
            var containingPoint = htmlDoc.DocumentNode.Descendants();

            //use HasClass method to grab elements that contain the properites I require
            var storyTitle = containingPoint.Where(n => n.HasClass("storylink")).ToList();

            var storyAuthor = containingPoint.Where(n => n.HasClass("hnuser")).ToList();

            var storyScore = containingPoint.Where(n => n.HasClass("score")).ToList();

            var storyRank = containingPoint.Where(n => n.HasClass("rank")).ToList();

            IEnumerable<HtmlNode> urlNodes = storyTitle;

            var storyUrl = urlNodes.Select(n => n.GetAttributeValue("href", string.Empty)).ToList();

            //comments have no distinct class, so grab containing class and filter by element and its contents 
            var storyComments  =
                htmlDoc.DocumentNode.SelectNodes("//td[@class = 'subtext']/a[starts-with(@href, 'item')]").ToList();

            //looping through each list with the required number of posts, so each value is allocated to a new post and then added to the posts List
            for (int i = 0; i < numberOfPosts; i++)
            {
                Post post = new Post();
                //each property is validated with methods in the utilities class I have created 
                post.Title = Utility.ValidateString(storyTitle[i].InnerText);
                post.Uri = Utility.ValidateUrl(storyUrl[i]);
                post.Author = Utility.ValidateString(storyAuthor[i].InnerText);
                post.Points = int.Parse(storyScore[i].InnerText.Replace(" points", ""));
                post.Comments = Utility.ConvertComments(storyComments[i].InnerText);
                post.Rank = Convert.ToInt32(storyRank[i].InnerText.Replace(".", ""));
                posts.Add(post);
            }

            //converting my posts List into json, with the nice and readable format
            string json = JsonConvert.SerializeObject(posts, Formatting.Indented);

            Console.WriteLine(json);


            return json;

        }
    }
}
