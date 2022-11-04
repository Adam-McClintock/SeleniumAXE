using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumAXE.Utilities
{
    public static class Strings
    {
        public static int GetMatchCountFromString(String text, String expr)
        {
            return new Regex(expr).Matches(text).Count;
        }

        public static String GetMatchFromString(String text, String expr)
        {
            String matchedText = "";
            var regex = new Regex(expr);
            if (regex.IsMatch(text))
            {
                matchedText = regex.Match(text).Groups[1].Value;
            }
            return matchedText;
        }

        public static String[] GetMatchesFromString(String text, String expr)
        {
            var regex = new Regex(expr);
            String[] matches = new String[Regex.Matches(text, expr).Count];
            {
                matches = Regex.Matches(text, expr)
                    .OfType<Match>()
                    .Select(m => m.Groups[0].Value)
                    .ToArray();
            }
            return matches;
        }

        public static String[] GetMultipleMatchesFromString(String text, String expr, int group)
        {
            var regex = new Regex(expr);
            String[] matches = new String[Regex.Match(text, expr).Groups[group].Captures.Count];
            {
                matches = Regex.Matches(text, expr)
                        .OfType<Match>()
                        .Select(m => m.Groups[group].Value)
                        .ToArray();
            }
            return matches;
        }

        public static string Last(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
            {
                return source;
            }
            return source.Substring(source.Length - tail_length);
        }

        public static string First(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
            {
                return source;
            }
            return source.Substring(0, tail_length);
        }
    }
}
