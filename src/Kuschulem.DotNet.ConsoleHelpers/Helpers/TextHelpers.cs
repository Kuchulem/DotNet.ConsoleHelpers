using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Kuchulem.DotNet.ConsoleHelpers.Tests")]
namespace Kuchulem.DotNet.ConsoleHelpers
{
    internal static class TextHelpers
    {
        public static int ComputeSpacesBefore(int textWidth, int width, ConsoleTextAlignment alignment)
        {
            return alignment switch
            {
                ConsoleTextAlignment.Right => width - textWidth,
                ConsoleTextAlignment.Center => (int)Math.Ceiling((double)((width - textWidth) / 2)),
                _ => 0
            };
        }

        public static IEnumerable<string> SplitString(string line, int maxSize)
        {
            var words = line.Trim().Split(' ');
            var current = "";
            foreach (var word in words)
            {
                var space = string.IsNullOrEmpty(current) ? "" : " ";
                if (current.Length + word.Length + space.Length > maxSize)
                {
                    if (!string.IsNullOrEmpty(current))
                    {
                        var chunks = StringToShunks(current, maxSize);
                        var count = chunks.Count();
                        if (count > 1)
                        {
                            foreach (var chunk in chunks.Take(count - 1))
                                yield return chunk;

                            current = chunks.Last();
                        }
                        else
                        {
                            yield return current;
                            current = "";
                        }
                    }
                    current += (!string.IsNullOrEmpty(current) ? " " : "") + word;
                }
                else
                {
                    current += space + word;
                }
            }

            if (!string.IsNullOrEmpty(current))
                foreach (var chunk in StringToShunks(current, maxSize))
                    yield return chunk;

        }

        public static IEnumerable<string> StringToShunks(string str, int maxChunkSize)
        {
            for (int i = 0; i < str.Length; i += maxChunkSize)
                yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
        }
    }
}
