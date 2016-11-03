using Microsoft.Build.Framework;
using NUnit.Framework;
using Shouldly;
using System;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class ConsoleLoggerParametersTest : TestBase
    {
        [Test]
        public void ConsoleLoggerParametersMultipleOptions([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                ConsoleLoggerParameters = new MSBuildConsoleLoggerParameters
                {
                    Options = MSBuildLoggerOptions.ErrorsOnly
                              | MSBuildLoggerOptions.DisableMPLogging
                              | MSBuildLoggerOptions.ShowCommandLine
                }
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:\"ErrorsOnly;ShowCommandLine;DisableMPLogging\"");
        }

        [Test]
        public void ConsoleLoggerParametersNotNullButEmpty()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                ConsoleLoggerParameters = new MSBuildConsoleLoggerParameters(),
            };

            commandLineArguments.ToString().ShouldBe("");
        }

        [Test]
        public void ConsoleLoggerParametersOptionsAndVerbosity([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                ConsoleLoggerParameters = new MSBuildConsoleLoggerParameters
                {
                    Options = MSBuildLoggerOptions.ForceConsoleColor
                              | MSBuildLoggerOptions.ForceNoAlign
                              | MSBuildLoggerOptions.ShowEventId,
                    Verbosity = LoggerVerbosity.Diagnostic
                }
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:\"ShowEventId;ForceNoAlign;ForceConsoleColor;Verbosity={commandLineArguments.ConsoleLoggerParameters.Verbosity}\"");
        }

        [Test]
        public void ConsoleLoggerParametersSingleOption([Values(true, false)] bool useShortSwitchNames)
        {
            const MSBuildLoggerOptions options = MSBuildLoggerOptions.ErrorsOnly;

            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                ConsoleLoggerParameters = new MSBuildConsoleLoggerParameters
                {
                    Options = options
                }
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{options}");
        }

        [Test]
        public void ConsoleLoggerParametersVerbosity([Values(true, false)] bool useShortSwitchNames)
        {
            foreach (var @enum in Enum.GetValues(typeof(LoggerVerbosity)))
            {
                MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
                {
                    ConsoleLoggerParameters = new MSBuildConsoleLoggerParameters
                    {
                        Verbosity = (LoggerVerbosity) @enum
                    }
                };

                commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:Verbosity={Enum.GetName(typeof(LoggerVerbosity), @enum)}");
            }
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "clp" : "ConsoleLoggerParameters";
        }
    }
}