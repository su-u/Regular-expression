using System;
using System.ComponentModel.Design;
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

        }

        private static string RegexReplace(string input, string pattern, string replacement, int num = 0)
        {
            return ($"{num}: \"{input}\" => \"{pattern}\" -> \"{replacement}\" = \"{Regex.Replace(input, pattern, replacement)}\"");
        }
        private static string RegexMatch(string input, string pattern, int num = 0)
        {
            return ($"{num}: \"{input}\" -> \"{pattern}\" = \"{Regex.Match(input, pattern)}\"");
        }
        
        private static int GetLine([CallerLineNumber]int line = 0)
        {
            return line;
        }
    }
}