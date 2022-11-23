# DotNet.ConsoleHelpers

[![NuGet Version](https://img.shields.io/nuget/v/Kuchulem.DotNet.ConsoleHelpers?label=Nuget%20version&logo=nuget)](https://www.nuget.org/packages/Kuchulem.DotNet.ConsoleHelpers/)
[![NuGet Preversion](https://img.shields.io/nuget/vpre/Kuchulem.DotNet.ConsoleHelpers?label=Nuget%20prerelease&logo=nuget)](https://www.nuget.org/packages/Kuchulem.DotNet.ConsoleHelpers/)

[![CodeQL](https://github.com/Kuchulem/DotNet.ConsoleHelpers/actions/workflows/codeql.yml/badge.svg?branch=main)](https://github.com/Kuchulem/DotNet.ConsoleHelpers/actions/workflows/codeql.yml)

Provides the static class `ConsoleExtended` witch helps to write easily in the console and extension methods to write clear debug.

# How to install

Choose the method you prefere.

## Package Manager

```sh
Install-Package Kuchulem.DotNet.ConsoleHelpers -Version 2.0.0-beta.1
```

## .Net CLI

```sh
dotnet add package Kuchulem.DotNet.ConsoleHelpers --version 2.0.0-beta.1
```

## Package reference

```xml
<PackageReference Include="Kuchulem.DotNet.ConsoleHelpers" Version="2.0.0-beta.1" />
```

## Paket CLI

```sh
paket add Kuchulem.DotNet.ConsoleHelpers --version 2.0.0-beta.1
```

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
        public void DoSomething()
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

# Run the demo

The solution includes a demo project : `Kuchulem.DotNet.ConsoleHelpers.Demo`.

Run this project from your IDE to see the capabilities of the `Kuchulem.DotNet.ConsoleHelpers` library.