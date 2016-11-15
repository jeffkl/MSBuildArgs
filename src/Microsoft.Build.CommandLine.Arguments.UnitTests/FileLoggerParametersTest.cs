using Microsoft.Build.Framework;
using NUnit.Framework;
using Shouldly;
using System;
using System.Linq;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class FileLoggerParametersTest : TestBase
    {
        [Test]
        public void FileLoggerMultiple([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.FileLoggers.Add(new MSBuildFileLoggerParameters
            {
                LogFile = "warnings.log",
                Options = MSBuildLoggerOptions.WarningsOnly,
            });

            commandLineArguments.FileLoggers.Add(new MSBuildFileLoggerParameters
            {
                LogFile = "errors.log",
                Options = MSBuildLoggerOptions.ErrorsOnly,
            });

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}0 /{GetSecondarySwitchName(useShortSwitchNames)}0:\"LogFile={commandLineArguments.FileLoggers[0].LogFile};{commandLineArguments.FileLoggers[0].Options}\" /{GetSwitchName(useShortSwitchNames)}1 /{GetSecondarySwitchName(useShortSwitchNames)}1:\"LogFile={commandLineArguments.FileLoggers[1].LogFile};{commandLineArguments.FileLoggers[1].Options}\"");
        }

        [Test]
        public void FileLoggerSingleAppend([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.FileLoggers.Add(new MSBuildFileLoggerParameters
            {
                Append = true
            });

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)} /{GetSecondarySwitchName(useShortSwitchNames)}:Append");
        }

        [Test]
        public void FileLoggerSingleEncoding([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.FileLoggers.Add(new MSBuildFileLoggerParameters
            {
                Encoding = "Unicode"
            });

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)} /{GetSecondarySwitchName(useShortSwitchNames)}:Encoding={commandLineArguments.FileLoggers.First().Encoding}");
        }

        [Test]
        public void FileLoggerSingleLogFile([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.FileLoggers.Add(new MSBuildFileLoggerParameters
            {
                LogFile = "my log.log"
            });

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)} /{GetSecondarySwitchName(useShortSwitchNames)}:\"LogFile={commandLineArguments.FileLoggers.First().LogFile}\"");
        }

        [Test]
        public void FileLoggerSingleVerbosity([Values(true, false)] bool useShortSwitchNames)
        {
            foreach (LoggerVerbosity expectedVerbosity in Enum.GetValues(typeof(LoggerVerbosity)).Cast<LoggerVerbosity>())
            {
                MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

                commandLineArguments.FileLoggers.Add(new MSBuildFileLoggerParameters
                {
                    Verbosity = expectedVerbosity
                });

                commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)} /{GetSecondarySwitchName(useShortSwitchNames)}:{GetVerbositySwitch(expectedVerbosity, useShortSwitchNames)}");
            }
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "fl" : "FileLogger";
        }

        private string GetSecondarySwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "flp" : "FileLoggerParameters";
        }
    }
}