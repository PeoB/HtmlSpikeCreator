using System.Collections.Generic;

namespace HtmlSpikeCreator.Extensions
{
    public static class StringExtensions
    {
        public static string Concat(this IEnumerable<string> strings)
        {
            return string.Concat(strings);
        }

    }
}