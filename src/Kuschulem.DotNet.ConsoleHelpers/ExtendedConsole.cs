using System;
using System.Collections.Generic;
using System.Linq;

namespace Kuchulem.DotNet.ConsoleHelpers
{
    public static class ExtendedConsole
    {
        public static void WriteLine(string line, ConsoleTextAlignment alignment, ConsoleColor? backgroundColor = null, ConsoleColor? foregroundColor = null, bool fill = false)
        {
            if (Environment.NewLine.ToCharArray().Where(c => line.Contains(c)).Any())
                throw new Exception("Multiline texts are not allowed.");

            var baseBackgroundColor = Console.BackgroundColor;
            var baseForegroundColor = Console.ForegroundColor;
            var width = Console.WindowWidth;
            var spaces = TextHelpers.ComputeSpacesBefore(line.Length, width, alignment);

            var textBackgroundColor = backgroundColor ?? baseBackgroundColor;
            var textForegroundColor = foregroundColor ?? baseForegroundColor;
            var spacesColor = fill ? textBackgroundColor : baseBackgroundColor;

            if (spaces >= 0)
            {
                Console.BackgroundColor = spacesColor;
                Console.Write(new String(' ', spaces));
                Console.BackgroundColor = textBackgroundColor;
                Console.ForegroundColor = textForegroundColor;
                Console.Write(line);
                Console.BackgroundColor = spacesColor;
                Console.WriteLine(new String(' ', spaces));
                Console.BackgroundColor = baseBackgroundColor;
                Console.ForegroundColor = baseForegroundColor;
            }
            else
            {
                foreach (var chunk in TextHelpers.SplitString(line, width))
                    DoWriteString(chunk, width, alignment, backgroundColor, foregroundColor, fill);
            }
        }

        public static void WritePrefixedLine(string prefix, string text, ConsoleColor? backgroundColor = null, ConsoleColor? prefixColor = null, ConsoleColor? textColor = null)
        {
            var baseBackgroundColor = Console.BackgroundColor;
            var baseForegroundColor = Console.ForegroundColor;

            var spaces = prefix.Length + 1;
            var availableLength = Console.WindowWidth - spaces;

            var textForegroundColor = textColor ?? baseForegroundColor;
            var prefixForegroundColor = prefixColor ?? baseForegroundColor;

            Console.BackgroundColor = backgroundColor ?? baseBackgroundColor;
            Console.ForegroundColor = textForegroundColor;
            bool first = true;

            foreach (var line in text.Split(Environment.NewLine))
                foreach (var chunk in TextHelpers.SplitString(line, availableLength))
                {
                    if (!first)
                    {
                        Console.Write(new String(' ', spaces));
                    }
                    else
                    {
                        Console.ForegroundColor = prefixForegroundColor;
                        Console.Write(prefix + ' ');
                        Console.ForegroundColor = textForegroundColor;
                        first = false;
                    }

                    Console.Write(chunk);
                    Console.WriteLine(new String(' ', availableLength - chunk.Length));
                }

            Console.BackgroundColor = baseBackgroundColor;
            Console.ForegroundColor = baseForegroundColor;
        }

        private static void DoWriteString(string text, int width, ConsoleTextAlignment alignment, ConsoleColor? backgroundColor = null, ConsoleColor? foregroundColor = null, bool fill = false)
        {
            var chunks = TextHelpers.StringToShunks(text, width);
            foreach (var chunk in chunks)
                ExtendedConsole.WriteLine(chunk, alignment, backgroundColor, foregroundColor, fill);
        }
    }
}
