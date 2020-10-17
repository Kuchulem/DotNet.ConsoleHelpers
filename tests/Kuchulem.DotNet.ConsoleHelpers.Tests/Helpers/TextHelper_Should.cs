using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kuchulem.DotNet.ConsoleHelpers.Tests.Helpers
{
    class TextHelper_Should
    {
        [Test]
        public void ReturnZeroSpaceBeforeLeftAlignedText()
        {
            var computed = TextHelpers.ComputeSpacesBefore(10, 100, ConsoleTextAlignment.Left);

            Assert.AreEqual(0, computed);
        }

        [Test]
        public void ReturnRightSpaceBeforeRightAlignedText()
        {
            var computed = TextHelpers.ComputeSpacesBefore(10, 100, ConsoleTextAlignment.Right);

            Assert.AreEqual(90, computed);
        }

        [Test]
        public void ReturnRightSpaceBeforeCenterAlignedText()
        {
            var computed = TextHelpers.ComputeSpacesBefore(10, 100, ConsoleTextAlignment.Center);

            Assert.AreEqual(45, computed);
        }

        [Test]
        public void ReturnRightSpaceBeforeCenterAlignedTextOdd()
        {
            var computed = TextHelpers.ComputeSpacesBefore(11, 100, ConsoleTextAlignment.Center);

            Assert.AreEqual(44, computed);
        }

        [Test]
        public void SplitStringOnSpaces()
        {
            var input = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam vel magna non turpis ornare sagittis eget nec risus. In fermentum mi dui, vitae porta lorem pharetra ac";
            var expected = new[]
            {
                "Lorem ipsum dolor",
                "sit amet,",
                "consectetur",
                "adipiscing elit.",
                "Nullam vel magna non",
                "turpis ornare",
                "sagittis eget nec",
                "risus. In fermentum",
                "mi dui, vitae porta",
                "lorem pharetra ac"
            };

            Assert.AreEqual(expected, TextHelpers.SplitString(input, 20));
        }

        [Test]
        public void SplitStringOnSpacesTooLongWord()
        {
            var input = "Lorem ipsum dolor sit amet, consecteturadipiscing elit. Nullam vel magna non turpis ornare sagittis eget nec risus. In fermentum mi dui, vitae porta lorem pharetra ac";
            var expected = new[]
            {
                "Lorem ipsum dolor",
                "sit amet,",
                "consecteturadipiscin",
                "g elit. Nullam vel",
                "magna non turpis",
                "ornare sagittis eget",
                "nec risus. In",
                "fermentum mi dui,",
                "vitae porta lorem",
                "pharetra ac"
            };

            Assert.AreEqual(expected, TextHelpers.SplitString(input, 20));
        }

        [Test]
        public void MakeChunksFromString()
        {
            var input = "Lorem ipsum dolor sit amet, consecteturadipiscing elit.";
            var expected = new[]
            {
                "Lorem ipsum dolor si",
                "t amet, consectetura",
                "dipiscing elit."
            };

            Assert.AreEqual(expected, TextHelpers.StringToShunks(input, 20));
        }
    }
}
