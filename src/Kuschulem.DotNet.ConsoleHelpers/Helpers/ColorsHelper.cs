using Kuschulem.DotNet.ConsoleHelpers.Exceptions;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("Kuchulem.DotNet.ConsoleHelpers.Tests")]
namespace Kuchulem.DotNet.ConsoleHelpers.Helpers
{
    internal class ColorsHelper
    {
        private readonly static ColorsHelper colorsHelper = new ColorsHelper();

        public static ColorsHelper Instance
        {
            get
            {
                return colorsHelper;
            }
        }

        private readonly ConsoleColorset initialColorSet;

        private readonly Dictionary<string, ConsoleColorset> colorsets = new Dictionary<string, ConsoleColorset>();

        private ColorsHelper()
        {
            initialColorSet = new ConsoleColorset
            {
                BackgroundColor = Console.BackgroundColor,
                ForegroundColor = Console.ForegroundColor
            };
        }

        public void RevertColors()
        {
            LoadColorset(initialColorSet);
        }

        public void RegisterColorSet(string setName, ConsoleColorset colorset)
        {
            if (colorsets.ContainsKey(setName))
                throw new ColorSetAlreadyRegisteredException(setName);

            colorsets.Add(setName, colorset);
        }

        public void UnregisterColorset(string setName)
        {
            if (colorsets.ContainsKey(setName))
                colorsets.Remove(setName);
            else
                throw new ColorSetNotFoundException(setName);
        }

        public void LoadColorset(string setName)
        {
            if (!colorsets.ContainsKey(setName))
                throw new ColorSetNotFoundException(setName);

            LoadColorset(colorsets[setName]);
        }

        public void LoadColorset(ConsoleColorset colorset)
        {
            Console.BackgroundColor = colorset.BackgroundColor ?? initialColorSet.BackgroundColor ?? ConsoleColor.Black;
            Console.ForegroundColor = colorset.ForegroundColor ?? initialColorSet.ForegroundColor ?? ConsoleColor.Gray;
        }
    }
}
