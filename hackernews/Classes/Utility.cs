using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using HtmlAgilityPack;

namespace hackernews.Classes
{
    public static class Utility
    {
        public  static int ConvertComments(string comment)
        {

            int index = comment.IndexOf("c");

            if (comment.Contains("discuss"))
            {
                return 0;
            }

            if (index > 0)
            {
                comment = comment.Substring(0, index);
            }

            int number = Int32.Parse(comment);

            return number;

        }

        public static string ValidateString(string param)
        {
            if (string.IsNullOrWhiteSpace(param))
            {
                return "Empty";
            }

            if (param.Length > 256)
            {
                string halved = param.Substring(0, param.Length / 2);
                return halved + "...";
            }

            return param;
        }

        public static string ValidateUrl(string url)
        {
            if (!url.Contains("http"))
            {
                return "invalid URL";
            }

            return url;
        }

    }
}
