﻿using Kuchulem.DotNet.Extensions.IEnumerables;
using Kuchulem.DotNet.Extensions.Strings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kuchulem.DotNet.ConsoleHelpers
{
    /// <summary>
    /// Static class providing advanced console actions
    /// </summary>
    public static class ConsoleExtended
    {
        /// <summary>
        /// Writes a line of text or multilined text with colouring and alignment.<br/>
        /// Important : for multiline text use the constant : <code>Environment.NewLine</code>
        /// </summary>
        /// <example>
        /// <code>
        /// ConsoleExtended("First line" + Environment.NewLine + "Second line", ConsoleTextAlignment.Center);
        /// </code>
        /// </example>
        /// <param name="line">The line of text to write</param>
        /// <param name="alignment">The text alignment expected</param>
        /// <param name="backgroundColor">The color of the console background for the text</param>
        /// <param name="foregroundColor">The color of the foreground for the text</param>
        /// <param name="fill">True to fill the whole line with the background color</param>
        public static void WriteLine(string line, ConsoleTextAlignment alignment = ConsoleTextAlignment.Left, ConsoleColor? backgroundColor = null, ConsoleColor? foregroundColor = null, bool fill = false)
        {
            if (line.Contains(Environment.NewLine))
            {
                foreach (var chunk in line.Split(Environment.NewLine))
                    WriteLine(chunk, alignment, backgroundColor, foregroundColor, fill);

                return;
            }

            var baseBackgroundColor = Console.BackgroundColor;
            var baseForegroundColor = Console.ForegroundColor;
            var width = Console.WindowWidth;
            var spaces = ComputeSpacesBefore(line.Length, width, alignment);

            var textBackgroundColor = backgroundColor ?? baseBackgroundColor;
            var textForegroundColor = foregroundColor ?? baseForegroundColor;
            var spacesColor = fill ? textBackgroundColor : baseBackgroundColor;

            if (spaces >= 0)
            {
                Console.BackgroundColor = spacesColor;
                Console.Write(new string(' ', spaces));
                Console.BackgroundColor = textBackgroundColor;
                Console.ForegroundColor = textForegroundColor;
                Console.Write(line);
                Console.BackgroundColor = spacesColor;
                Console.WriteLine(new string(' ', spaces));
                Console.BackgroundColor = baseBackgroundColor;
                Console.ForegroundColor = baseForegroundColor;
            }
            else
            {
                foreach (var chunk in line.ToChunks(width, true))
                    DoWriteString(chunk, width, alignment, backgroundColor, foregroundColor, fill);
            }
        }

        /// <summary>
        /// Writes a ligne with a prefix
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="text"></param>
        /// <param name="backgroundColor"></param>
        /// <param name="prefixColor"></param>
        /// <param name="textColor"></param>
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
                foreach (var chunk in line.ToChunks(availableLength, true))
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

        /// <summary>
        /// Draws a pattern on the console. The pattern is composed of chars corresponding to different colors
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="charMapper">Maps each char to a color</param>
        /// <param name="alignment"></param>
        public static void DrawPattern(string pattern, Func<char, ConsoleColor?> charMapper, ConsoleTextAlignment alignment = ConsoleTextAlignment.Left)
        {
            var defaultColor = Console.BackgroundColor;
            var lines = pattern.Split(Environment.NewLine.ToCharArray()).Where(l => !string.IsNullOrEmpty(l)).ToList();

            var spaces = ComputeSpacesBefore(lines.Select(l => l.Length).Max(), Console.WindowWidth, alignment);

            foreach (var line in lines)
            {
                Console.BackgroundColor = defaultColor;
                Console.Write(new String(' ', spaces));
                foreach (var c in line)
                {
                    var color = charMapper(c);
                    Console.BackgroundColor = color ?? defaultColor;
                    Console.Write(" ");
                    Console.BackgroundColor = defaultColor;
                }
                Console.WriteLine("");
            }

            Console.BackgroundColor = defaultColor;
        }

        /// <summary>
        /// Draws a pattern on the console, each non-space caracter being replaced by the color provided
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="color"></param>
        /// <param name="alignment"></param>
        public static void DrawPattern(string pattern, ConsoleColor color, ConsoleTextAlignment alignment = ConsoleTextAlignment.Left)
        {
            DrawPattern(pattern, (c) =>
            {
                if (c != ' ')
                    return color;

                return null;
            }, alignment);
        }

        /// <summary>
        /// Draw a pattern in the console, with a dictionnary providing the different colors for each caracter in the pattern
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="mappings"></param>
        /// <param name="alignment"></param>
        public static void DrawPattern(string pattern, Dictionary<char, ConsoleColor?> mappings, ConsoleTextAlignment alignment = ConsoleTextAlignment.Left)
        {
            DrawPattern(pattern, (c) =>
            {
                if (mappings.TryGetValue(c, out ConsoleColor? color))
                    return color;

                return null;
            }, alignment);
        }

        /// <summary>
        /// Writes an empty line
        /// </summary>
        public static void NewLine()
        {
            Console.WriteLine("");
        }

        private static int ComputeSpacesBefore(int textWidth, int width, ConsoleTextAlignment alignment)
        {
            return alignment switch
            {
                ConsoleTextAlignment.Right => width - textWidth,
                ConsoleTextAlignment.Center => (int)Math.Ceiling((double)((width - textWidth) / 2)),
                _ => 0

            };
        }

        private static void DoWriteString(string text, int width, ConsoleTextAlignment alignment, ConsoleColor? backgroundColor = null, ConsoleColor? foregroundColor = null, bool fill = false)
        {
            text.ToChunks(width)
                .ForEach(chunk => WriteLine(chunk, alignment, backgroundColor, foregroundColor, fill));
        }
    }
}
