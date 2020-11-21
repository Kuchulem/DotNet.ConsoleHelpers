using Kuchulem.DotNet.ConsoleHelpers.Helpers;
using Kuschulem.DotNet.ConsoleHelpers.Exceptions;
using NuGet.Frameworks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kuchulem.DotNet.ConsoleHelpers.Tests.Helpers
{
    class ColorsHelpers_Should
    {
        private readonly ConsoleColor initialBgColor;
        private readonly ConsoleColor initialFgColor;
        private readonly ColorsHelper helper;

        public ColorsHelpers_Should()
        {
            initialBgColor = ConsoleColor.Black;
            initialFgColor = ConsoleColor.Gray;
            helper = ColorsHelper.Instance;
            helper.RegisterColorSet("inverted", new ConsoleColorset
            {
                BackgroundColor = ConsoleColor.White,
                ForegroundColor = ConsoleColor.Black
            });
        }

        [SetUp]
        public void Setup()
        {
            Console.BackgroundColor = initialBgColor;
            Console.ForegroundColor = initialFgColor;
        }

        [Test, Order(0)]
        public void ProvideInstance()
        {
            Assert.IsInstanceOf<ColorsHelper>(helper);
        }

        [Test, Order(1)]
        public void ChangeConsoleColorsFromColorSet()
        {
            helper.LoadColorset(new ConsoleColorset { BackgroundColor = ConsoleColor.Red, ForegroundColor = ConsoleColor.Green });
            Assert.AreEqual(ConsoleColor.Red, Console.BackgroundColor);
            Assert.AreEqual(ConsoleColor.Green, Console.ForegroundColor);
        }

        [Test, Order(2)]
        public void ChangeConsoleColorsFromColorSetName()
        {
            helper.LoadColorset("inverted");

            Assert.AreEqual(ConsoleColor.White, Console.BackgroundColor);
            Assert.AreEqual(ConsoleColor.Black, Console.ForegroundColor);
        }

        [Test, Order(3)]
        public void RevertToOriginalColors()
        {
            helper.LoadColorset("inverted");
            helper.RevertColors();

            Assert.AreEqual(initialBgColor, Console.BackgroundColor);
            Assert.AreEqual(initialFgColor, Console.ForegroundColor);
        }

        [Test, Order(4)]
        public void ThrowExceptionWhenRegisteringSameColorSetName()
        {
            Assert.Throws<ColorSetAlreadyRegisteredException>(delegate () {
                helper.RegisterColorSet("inverted", new ConsoleColorset());
            });
        }

        [Test, Order(5)]
        public void ThrowExceptionWhenLoadingMissingColorSet()
        {
            Assert.Throws<ColorSetNotFoundException>(delegate ()
            {
                helper.LoadColorset("notacolorset");
            });
        }

        [Test, Order(6)]
        public void RegisterNewColorSet()
        {
            var colorSet = new ConsoleColorset
            {
                BackgroundColor = ConsoleColor.Green,
                ForegroundColor = ConsoleColor.Red
            };

            helper.RegisterColorSet("new", colorSet);

            Assert.DoesNotThrow(delegate ()
            {
                helper.LoadColorset("new");
            });
        }

        [Test, Order(7)]
        public void UnregisterColorSet()
        {
            helper.RegisterColorSet("testunregister", new ConsoleColorset());

            helper.UnregisterColorset("testunregister");

            Assert.Throws<ColorSetNotFoundException>(delegate
            {
                helper.LoadColorset("testunregister");
            });
        }

        [Test, Order(8)]
        public void ThrowExceptionOnUnregisterInvalidColorSet()
        {
            Assert.Throws<ColorSetNotFoundException>(delegate
            {
                helper.UnregisterColorset("notacolorset");
            });
        }
    }
}
