using Microsoft.Build.Framework;
using NUnit.Framework;
using Shouldly;
using System;
using System.Linq;

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