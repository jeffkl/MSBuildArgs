# Overview
A class library for generating an MSBuild command-line.  This ensures that your command-line is correct every time with compile time checking and argument escaping.  The generator uses the MSBuild command-line builder so that the arguments are specified correctly.

[![Build status](https://ci.appveyor.com/api/projects/status/eymw1k79uc06k807?svg=true)](https://ci.appveyor.com/project/CBT/msbuildargs)
 [![NuGet Pre Release](https://img.shields.io/nuget/vpre/Microsoft.Build.CommandLine.Arguments.svg)](https://www.nuget.org/packages/Microsoft.Build.CommandLine.Arguments/)
# Examples

## Console Logger (/consoleloggerparameters)

``` C#
var arguments = new MSBuildCommandLineArguments
{
    ConsoleLoggerParameters = new MSBuildConsoleLoggerParameters
    {
        Options = MSBuildLoggerOptions.DisableConsoleColor
                | MSBuildLoggerOptions.ShowTimestamp,
        Verbosity = Microsoft.Build.Framework.LoggerVerbosity.Detailed
    }
};
```

Result:
```
/ConsoleLoggerParameters:"ShowTimestamp;DisableConsoleColor;Verbosity=Detailed"
```
