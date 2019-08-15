using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MyRegex
{
    public static class MyRegexClass
    {
        
        public static string RegexReplace(string input, string pattern, string replacement, int num = 0)
        {
            return ($"{num}: \"{input}\" => \"{pattern}\" -> \"{replacement}\" = \"{Regex.Replace(input, pattern, replacement)}\"");
        }
        
        public static string RegexMatch(string input, string pattern, int num = 0)
        {
            var s = Regex.Matches(input, pattern).MatchesFlatting();
            return ($"{num}: \"{input}\" -> \"{pattern}\" = \"{s}\"");
        }

       
        public static int GetLine([CallerLineNumber]int line = 0)
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