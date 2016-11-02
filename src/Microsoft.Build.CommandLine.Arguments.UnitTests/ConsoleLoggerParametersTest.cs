using Microsoft.Build.Framework;
using NUnit.Framework;
using Shouldly;
using System;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class ConsoleLoggerParametersTest
    {
        [Test]
        public void ConsoleLoggerParametersMultipleOptions()
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

            commandLineArguments.ToString().ShouldBe($"/ConsoleLoggerParameters:\"ErrorsOnly;ShowCommandLine;DisableMPLogging\"");
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
        public void ConsoleLoggerParametersOptionsAndVerbosity()
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

            commandLineArguments.ToString().ShouldBe($"/ConsoleLoggerParameters:\"ShowEventId;ForceNoAlign;ForceConsoleColor;Verbosity={commandLineArguments.ConsoleLoggerParameters.Verbosity}\"");
        }

        [Test]
        public void ConsoleLoggerParametersSingleOption()
        {
            const MSBuildLoggerOptions options = MSBuildLoggerOptions.ErrorsOnly;

            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                ConsoleLoggerParameters = new MSBuildConsoleLoggerParameters
                {
                    Options = options
                }
            };

            commandLineArguments.ToString().ShouldBe($"/ConsoleLoggerParameters:{options}");
        }

        [Test]
        public void ConsoleLoggerParametersVerbosity()
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

                commandLineArguments.ToString().ShouldBe($"/ConsoleLoggerParameters:Verbosity={Enum.GetName(typeof(LoggerVerbosity), @enum)}");
            }
        }
    }
}