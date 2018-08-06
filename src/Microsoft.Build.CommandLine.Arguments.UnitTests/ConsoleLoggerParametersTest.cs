using Microsoft.Build.Framework;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class ConsoleLoggerParametersTest : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ConsoleLoggerParametersMultipleOptions(bool useShortSwitchNames)
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

        [Fact]
        public void ConsoleLoggerParametersNotNullButEmpty()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                ConsoleLoggerParameters = new MSBuildConsoleLoggerParameters(),
            };

            commandLineArguments.ToString().ShouldBe("");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ConsoleLoggerParametersOptionsAndVerbosity(bool useShortSwitchNames)
        {
            const LoggerVerbosity expectedVerbosity = LoggerVerbosity.Diagnostic;

            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                ConsoleLoggerParameters = new MSBuildConsoleLoggerParameters
                {
                    Options = MSBuildLoggerOptions.ForceConsoleColor
                              | MSBuildLoggerOptions.ForceNoAlign
                              | MSBuildLoggerOptions.ShowEventId,
                    Verbosity = expectedVerbosity
                }
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:\"ShowEventId;ForceNoAlign;ForceConsoleColor;{GetVerbositySwitch(expectedVerbosity, useShortSwitchNames)}\"");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ConsoleLoggerParametersSingleOption(bool useShortSwitchNames)
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

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ConsoleLoggerParametersVerbosity(bool useShortSwitchNames)
        {
            foreach (LoggerVerbosity verbosity in Enum.GetValues(typeof(LoggerVerbosity)).Cast<LoggerVerbosity>())
            {
                MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
                {
                    ConsoleLoggerParameters = new MSBuildConsoleLoggerParameters
                    {
                        Verbosity = verbosity
                    }
                };

                commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{GetVerbositySwitch(verbosity, useShortSwitchNames)}");
            }
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "clp" : "ConsoleLoggerParameters";
        }
    }
}