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
    }
}
