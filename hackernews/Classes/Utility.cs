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
            //if no comments have been made yet return 0 
            int index = comment.IndexOf("c");

            if (comment.Contains("discuss"))
            {
                return 0;
            }
            //comments are extracted as e.g 26comments, remove everything at index of 'c'
            if (index > 0)
            {
                comment = comment.Substring(0, index);
            }

            int number = Int32.Parse(comment);

            return number;

        }

        public static string ValidateString(string param)
        {
            //ensures string is not null / empty
            if (string.IsNullOrWhiteSpace(param))
            {
                return "Empty";
            }

            //shortens string if it is longer than 256 characters
            if (param.Length > 256)
            {
                string halved = param.Substring(0, param.Length / 2);
                return halved + "...";
            }

            return param;
        }


        public static string ValidateUrl(string url)
        {
            //if url doesnt contain http or https it is not valid and will not be included
            if (!url.Contains("http"))
            {
                return "invalid URL";
            }

            return url;
        }

    }
}
