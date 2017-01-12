# Overview
A class library for generating an MSBuild command-line.  This ensures that your command-line is correct every time with compile time checking and argument escaping.  The generator uses the MSBuild command-line builder so that the arguments are specified correctly.

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
