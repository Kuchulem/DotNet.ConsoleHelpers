﻿using System;
using System.Collections.Generic;

namespace Kuchulem.DotNet.ConsoleHelpers.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleExtended.WriteLine("Welcome on the demo for Kuchulem's console helpers", ConsoleTextAlignment.Left);
            ConsoleExtended.WritePrefixedLine("Info", "This is a prefixed line (with [info] keyword here). You will " +
                "see them when important information is displayed", prefixColor: ConsoleColor.Yellow);
            
            ConsoleExtended.NewLine();
            ConsoleExtended.WriteLine("Let's starts by drawing a patter (The Kuchulem logo)", ConsoleTextAlignment.Left);
            ConsoleExtended.DrawPattern(
                // first argument is the pattern
                "                       " + Environment.NewLine +
                "  **** **        ****  " + Environment.NewLine +
                "  **   **          **  " + Environment.NewLine +
                "  **   **     **   **  " + Environment.NewLine +
                "  **   **   **     **  " + Environment.NewLine +
                "  **   ** **       **  " + Environment.NewLine +
                "  **   **   **     **  " + Environment.NewLine +
                "  **   **     **   **  " + Environment.NewLine +
                "  **   **          **  " + Environment.NewLine +
                "  **** **        ****  " + Environment.NewLine +
                "                       ",
                // second argument is a dictrionnary that makes
                // a correspondance between a character and a color
                new Dictionary<char, ConsoleColor?>
                {
                    { ' ', ConsoleColor.DarkBlue },
                    { '*', ConsoleColor.Yellow }
                },
                // Third parameter to align the pattern (here centered)
                ConsoleTextAlignment.Center
            );

            ConsoleExtended.WritePrefixedLine("Info", "Once the pattern is drawn, the console colors return back to normal", prefixColor: ConsoleColor.Yellow);

            ConsoleExtended.NewLine();
            ConsoleExtended.WriteLine("Now let's play with alignment !", ConsoleTextAlignment.Left);
            ConsoleExtended.WriteLine("Actually you saw text aligned to left", ConsoleTextAlignment.Left);
            ConsoleExtended.WriteLine("But you can center your text", ConsoleTextAlignment.Center);
            ConsoleExtended.WriteLine("And align it to right", ConsoleTextAlignment.Right);
            ConsoleExtended.WritePrefixedLine("Info", "Note that the alignment is only for a single Console.WriteLine call.", prefixColor: ConsoleColor.Yellow);
            ConsoleExtended.WriteLine(
                "The alignment" + Environment.NewLine +
                "Can be kept on a multiline" + Environment.NewLine +
                "text",
                ConsoleTextAlignment.Center);

            ConsoleExtended.NewLine();
            ConsoleExtended.WriteLine("Time to play with colors !", ConsoleTextAlignment.Left);
            ConsoleExtended.WriteLine("You can change foreground and background color for a single call of Console.WriteLine.", ConsoleTextAlignment.Left, ConsoleColor.Cyan, ConsoleColor.Magenta);
            ConsoleExtended.WriteLine("The following line will be back to the original color", ConsoleTextAlignment.Left);

            ConsoleExtended.NewLine();
            ConsoleExtended.WriteLine("That's all :) enjoy your console.", ConsoleTextAlignment.Left);
        }
    }
}
