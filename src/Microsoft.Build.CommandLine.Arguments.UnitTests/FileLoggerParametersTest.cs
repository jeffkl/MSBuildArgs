using Microsoft.Build.Framework;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class FileLoggerParametersTest : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void FileLoggerMultiple(bool useShortSwitchNames)
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

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void FileLoggerSingleAppend(bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.FileLoggers.Add(new MSBuildFileLoggerParameters
            {
                Append = true
            });

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)} /{GetSecondarySwitchName(useShortSwitchNames)}:Append");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void FileLoggerSingleEncoding(bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.FileLoggers.Add(new MSBuildFileLoggerParameters
            {
                Encoding = "Unicode"
            });

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)} /{GetSecondarySwitchName(useShortSwitchNames)}:Encoding={commandLineArguments.FileLoggers.First().Encoding}");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void FileLoggerSingleLogFile(bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.FileLoggers.Add(new MSBuildFileLoggerParameters
            {
                LogFile = "my log.log"
            });

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)} /{GetSecondarySwitchName(useShortSwitchNames)}:\"LogFile={commandLineArguments.FileLoggers.First().LogFile}\"");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void FileLoggerSingleVerbosity(bool useShortSwitchNames)
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