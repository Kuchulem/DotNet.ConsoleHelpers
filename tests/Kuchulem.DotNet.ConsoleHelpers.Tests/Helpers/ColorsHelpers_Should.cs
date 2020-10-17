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

        [Test]
        public void ProvideInstance()
        {
            Assert.IsInstanceOf<ColorsHelper>(helper);
        }

        [Test]
        public void ChangeConsoleColorsFromColorSet()
        {
            helper.LoadColorset(new ConsoleColorset { BackgroundColor = ConsoleColor.Red, ForegroundColor = ConsoleColor.Green });
            Assert.AreEqual(Console.BackgroundColor, ConsoleColor.Red);
            Assert.AreEqual(Console.ForegroundColor, ConsoleColor.Green);
        }

        [Test]
        public void ChangeConsoleColorsFromColorSetName()
        {
            helper.LoadColorset("inverted");

            Assert.AreEqual(Console.BackgroundColor, ConsoleColor.White);
            Assert.AreEqual(Console.ForegroundColor, ConsoleColor.Black);
        }

        [Test]
        public void RevertToOriginalColors()
        {
            helper.LoadColorset("inverted");
            helper.RevertColors();

            Assert.AreEqual(Console.BackgroundColor, initialBgColor);
            Assert.AreEqual(Console.ForegroundColor, initialFgColor);
        }

        [Test]
        public void ThrowExceptionWhenRegisteringSameColorSetName()
        {
            Assert.Throws<ColorSetAlreadyRegisteredException>(delegate () {
                helper.RegisterColorSet("inverted", new ConsoleColorset());
            });
        }

        [Test]
        public void ThrowExceptionWhenLoadingMissingColorSet()
        {
            Assert.Throws<ColorSetNotFoundException>(delegate ()
            {
                helper.LoadColorset("notacolorset");
            });
        }

        [Test]
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

        [Test]
        public void UnregisterColorSet()
        {
            helper.RegisterColorSet("testunregister", new ConsoleColorset());

            helper.UnregisterColorset("testunregister");

            Assert.Throws<ColorSetNotFoundException>(delegate
            {
                helper.LoadColorset("testunregister");
            });
        }

        [Test]
        public void ThrowExceptionOnUnregisterInvalidColorSet()
        {
            Assert.Throws<ColorSetNotFoundException>(delegate
            {
                helper.UnregisterColorset("notacolorset");
            });
        }
    }
}
