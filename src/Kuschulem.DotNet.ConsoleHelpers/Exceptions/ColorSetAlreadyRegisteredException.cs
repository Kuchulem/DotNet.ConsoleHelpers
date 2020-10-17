using Kuchulem.DotNet.ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kuschulem.DotNet.ConsoleHelpers.Exceptions
{
    public class ColorSetAlreadyRegisteredException : Exception
    {
        public ColorSetAlreadyRegisteredException(string setName)
            : base($"Color set {setName} already registered")
        {
        }
    }
}
