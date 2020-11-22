# DotNet.ConsoleHelpers

[![nuget](https://img.shields.io/nuget/v/Kuschulem.DotNet.ConsoleHelpers.svg)](https://www.nuget.org/packages/Kuschulem.DotNet.ConsoleHelpers/)

Provides the static class `ConsoleExtended` witch helps to write easily in the console and extension methods to write clear debug.

# How to install

Choose the method you prefere.

## Package Manager

```sh
Install-Package Kuschulem.DotNet.ConsoleHelpers -Version 1.0.0
```

## .Net CLI

```sh
dotnet add package Kuschulem.DotNet.ConsoleHelpers --version 1.0.0
```

## Package reference

```xml
<PackageReference Include="Kuschulem.DotNet.ConsoleHelpers" Version="1.0.0" />
```

## Paket CLI

```sh
paket add Kuschulem.DotNet.ConsoleHelpers --version 1.0.0
```

# Documentation

coming soon

# Usage

## ConsoleExtended

```csharp
// Write text align to left
ConsoleExtended.WriteLine("Welcome on the demo", ConsoleTextAlignment.Left);
// write a prefixed line with a yellow "Info" prefix :
ConsoleExtended.WritePrefixedLine("Info", "This is a prefixed", prefixColor: ConsoleColor.Yellow);
// Write a new empty line
ConsoleExtended.NewLine();
// Draw a pattern on the console
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
// Other alignments
ConsoleExtended.WriteLine("Centered text", ConsoleTextAlignment.Center);
ConsoleExtended.WriteLine("Right aligned text", ConsoleTextAlignment.Right);
ConsoleExtended.WriteLine(
    "The alignment" + Environment.NewLine +
    "Can be kept on a multiline" + Environment.NewLine +
    "text",
    ConsoleTextAlignment.Center
); // Use Environment.NewLine for multiline text
// Change background and foregound color of the written line :
ConsoleExtended.WriteLine(
    "Line with cyan backgrounf and magenta foreground", 
    ConsoleTextAlignment.Left,
    ConsoleColor.Cyan, // background color
    ConsoleColor.Magenta // foreground color
); // Note : the folowing line will be back to previous colors
```

## Extension methods

A bunch of extension methodes for the `object` type have been added

```csharp
using Kuchulem.DotNet.ConsoleHelpers.Extensions;

namespace ExtensionsDemo
{
    class MyDemoClass
    {
        public void DoSomthing()
        {
            // Write a line of debug with info prefix
            this.WriteInfoLine("Some info");
            // Write a simple debug line
            this.WriteDebugLine("Some debug");
            // Write an error line
            this.WriteErrorLine("Some error");
            // Write a warning line
            this.WriteWarningLine("Some warning");
        }
    }
}
```

In the console you will get :

```
Info MyDemoClass.DoSomething : Some info
Debug MyDemoClass.DoSomething : Some debug
Error MyDemoClass.DoSomething : Some error
Warn MyDemoClass.DoSomething : Some warning
```

> Note that each prefix will have its own color : info -> grey, debug -> white, error -> red, warning -> yellow
