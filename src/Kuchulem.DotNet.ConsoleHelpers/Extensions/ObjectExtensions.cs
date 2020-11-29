using Kuchulem.DotNet.ConsoleHelpers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Kuchulem.DotNet.ConsoleHelpers.Extensions
{
    public static class ObjectExtensions
    {
        private const string InfoPrefix = "INFO";
        private const string DebugPrefix = "DEBUG";
        private const string ErrorPrefix = "ERROR";
        private const string WarningPrefix = "WARN";

        private static string GetLine(object caller, string callerMember, string message)
        {
            var suffix = string.IsNullOrEmpty(message) ? "" : $" : {message}";
            return $"{caller.GetType().Name}.{callerMember}{suffix}";
        }

        /// <summary>
        /// Writes an info line
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="callerMember"></param>
        /// <param name="message"></param>
        public static void WriteInfoLine(this object caller, [CallerMemberName] string callerMember = "", string message = "")
        {
            var line = GetLine(caller, callerMember, message);
            ConsoleExtended.WritePrefixedLine(InfoPrefix, line,
                backgroundColor: ConsoleColor.Black,
                prefixColor: ConsoleColor.Blue,
                textColor: ConsoleColor.Gray);
        }

        /// <summary>
        /// Writes a debug line
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="callerMember"></param>
        /// <param name="message"></param>
        public static void WriteDebugLine(this object caller, [CallerMemberName] string callerMember = "", string message = "")
        {
            var line = GetLine(caller, callerMember, message);
            ConsoleExtended.WritePrefixedLine(DebugPrefix, line,
                backgroundColor: ConsoleColor.Black,
                prefixColor: ConsoleColor.White,
                textColor: ConsoleColor.Gray);
        }

        /// <summary>
        /// Writes an error line
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="callerMember"></param>
        /// <param name="message"></param>
        public static void WriteErrorLine(this object caller, [CallerMemberName] string callerMember = "", string message = "")
        {
            var line = GetLine(caller, callerMember, message);
            ConsoleExtended.WritePrefixedLine(ErrorPrefix, line,
                backgroundColor: ConsoleColor.Black,
                prefixColor: ConsoleColor.DarkRed,
                textColor: ConsoleColor.Gray);
        }

        /// <summary>
        /// Writes a warning line
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="callerMember"></param>
        /// <param name="message"></param>
        public static void WriteWarningLine(this object caller, [CallerMemberName] string callerMember = "", string message = "")
        {
            var line = GetLine(caller, callerMember, message);
            ConsoleExtended.WritePrefixedLine(WarningPrefix, line,
                backgroundColor: ConsoleColor.Black,
                prefixColor: ConsoleColor.DarkYellow,
                textColor: ConsoleColor.Gray);
        }
    }
}
