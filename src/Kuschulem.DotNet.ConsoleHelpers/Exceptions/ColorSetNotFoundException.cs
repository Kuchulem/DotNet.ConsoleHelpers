using System;
using System.Collections.Generic;
using System.Text;

namespace Kuschulem.DotNet.ConsoleHelpers.Exceptions
{
    public class ColorSetNotFoundException : Exception
    {
        public ColorSetNotFoundException(string setName)
            : base($"Color set {setName} not registered")
        {
        }
    }
}
