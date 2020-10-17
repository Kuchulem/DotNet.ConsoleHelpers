using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kuchulem.DotNet.ConsoleHelpers
{
    public class ConsoleDrawer
    {
        public static void DrawPattern(string pattern, Func<char, ConsoleColor?> charMapper, ConsoleTextAlignment alignment = ConsoleTextAlignment.Left)
        {
            var defaultColor = Console.BackgroundColor;
            var lines = pattern.Split(Environment.NewLine.ToCharArray()).Where(l => !string.IsNullOrEmpty(l)).ToList();

            var spaces = TextHelpers.ComputeSpacesBefore(lines.Select(l => l.Length).Max(), Console.WindowWidth, alignment);

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

        public static void DrawPattern(string pattern, ConsoleColor color, ConsoleTextAlignment alignment = ConsoleTextAlignment.Left)
        {
            DrawPattern(pattern, (c) =>
            {
                if (c != ' ')
                    return color;

                return null;
            }, alignment);
        }

        public static void DrawPattern(string pattern, Dictionary<char, ConsoleColor?> mappings, ConsoleTextAlignment alignment = ConsoleTextAlignment.Left)
        {
            DrawPattern(pattern, (c) =>
            {
                if (mappings.TryGetValue(c, out ConsoleColor? color))
                    return color;

                return null;
            }, alignment);
        }
    }
}
