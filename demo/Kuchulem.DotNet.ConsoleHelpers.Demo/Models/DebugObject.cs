using Kuchulem.DotNet.ConsoleHelpers.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kuchulem.DotNet.ConsoleHelpers.Demo.Models
{
    internal class DebugObject
    {
        public void DoSomething(string message) 
        {
            this.WriteDebugLine();
        }
    }
}
