﻿using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Console;

namespace c03
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //基本
            WriteLine(RegexReplace( "That is a parasol", "a", "A", GetLine()));
            

            WriteLine(RegexReplace("Bob White", "Bob", "Rebert", GetLine()));
            WriteLine(RegexReplace("Bobby White", "Bob", "Rebert", GetLine()));

            WriteLine(RegexMatch("a..", "a..", GetLine()));
            WriteLine(RegexMatch("a..", @"a\.\.", GetLine()));
            WriteLine(RegexMatch("a..", "a\\.\\.", GetLine()));
            WriteLine(RegexMatch("aaa", "a\\.\\.", GetLine()));
            WriteLine(RegexMatch("aaa", "a..",GetLine()));
            WriteLine(RegexMatch("aaa", @"a..",GetLine()));
                        
            //任意の1文字
            WriteLine(RegexMatch( "aaa", @".", GetLine()));
            WriteLine(RegexMatch( "abc", @"..", GetLine()));
            WriteLine(RegexMatch( "   ", @"..", GetLine()));
            WriteLine(RegexMatch( "  ", @".", GetLine()));
            
            //いずれかにマッチ
            WriteLine(RegexMatch( "aaa", @"[a]", GetLine()));
            WriteLine(RegexMatch( "xyz", @"[xyz]", GetLine()));
            WriteLine(RegexMatch( "aaa", @"[a-z]", GetLine()));
            WriteLine(RegexMatch( "1234569764", @"[2-8]", GetLine()));
            WriteLine(RegexMatch( "46462", @"[a-z6]", GetLine()));
            WriteLine(RegexMatch( "^ddd", @"[h^y]", GetLine()));
            WriteLine(RegexMatch( "11034", @"[^1-9]", GetLine()));
            WriteLine(RegexMatch( "Library", @"[Ll]ibrary", GetLine()));
            WriteLine(RegexMatch( "library", @"[Ll]ibrary", GetLine()));
            
            //グルーピング
            WriteLine(RegexMatch( "long long ago Long", @"[Ll]ong", GetLine()));
            WriteLine(RegexMatch( "long long ago Long", @"[l]ong", GetLine()));
            WriteLine(RegexMatch( "long long ago Long", @"(long )", GetLine()));
            WriteLine(RegexMatch( "long long ago Long", @"([Ll]ong*)+", GetLine()));
            

        }

        private static string RegexReplace(string input, string pattern, string replacement, int num = 0)
        {
            return ($"{num}: \"{input}\" => \"{pattern}\" -> \"{replacement}\" = \"{Regex.Replace(input, pattern, replacement)}\"");
        }
        private static string RegexMatch(string input, string pattern, int num = 0)
        {
            var s = Regex.Matches(input, pattern).MatchesFlatting();
            return ($"{num}: \"{input}\" -> \"{pattern}\" = \"{s}\"");
        }

       
        private static int GetLine([CallerLineNumber]int line = 0)
        {
            return line;
        }
    }

    public static class MyEx
    {
        public static string MatchesFlatting(this MatchCollection matchCollection)
        {
            var result = string.Empty;
            var selectMany = matchCollection.Cast<Match>().SelectMany(x => x.Value);
            return selectMany.Aggregate(result, (current, i) => current + i);
        }
    }
}