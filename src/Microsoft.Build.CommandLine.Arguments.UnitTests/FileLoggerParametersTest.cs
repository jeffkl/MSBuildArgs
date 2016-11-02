using Microsoft.Build.Framework;
using NUnit.Framework;
using Shouldly;
using System.Linq;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class FileLoggerParametersTest
    {
        [Test]
        public void FileLoggerMultiple()
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

            commandLineArguments.ToString().ShouldBe($"/FileLogger0 /FileLoggerParameters0:\"LogFile={commandLineArguments.FileLoggers[0].LogFile};{commandLineArguments.FileLoggers[0].Options}\" /FileLogger1 /FileLoggerParameters1:\"LogFile={commandLineArguments.FileLoggers[1].LogFile};{commandLineArguments.FileLoggers[1].Options}\"");
        }

        [Test]
        public void FileLoggerSingleAppend()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.FileLoggers.Add(new MSBuildFileLoggerParameters
            {
                Append = true
            });

            commandLineArguments.ToString().ShouldBe("/FileLogger /FileLoggerParameters:Append");
        }

        [Test]
        public void FileLoggerSingleEncoding()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.FileLoggers.Add(new MSBuildFileLoggerParameters
            {
                Encoding = "Unicode"
            });

            commandLineArguments.ToString().ShouldBe($"/FileLogger /FileLoggerParameters:Encoding={commandLineArguments.FileLoggers.First().Encoding}");
        }

        [Test]
        public void FileLoggerSingleLogFile()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.FileLoggers.Add(new MSBuildFileLoggerParameters
            {
                LogFile = "my log.log"
            });

            commandLineArguments.ToString().ShouldBe($"/FileLogger /FileLoggerParameters:\"LogFile={commandLineArguments.FileLoggers.First().LogFile}\"");
        }

        [Test]
        public void FileLoggerSingleVerbosity()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.FileLoggers.Add(new MSBuildFileLoggerParameters
            {
                Verbosity = LoggerVerbosity.Minimal
            });

            commandLineArguments.ToString().ShouldBe($"/FileLogger /FileLoggerParameters:Verbosity={commandLineArguments.FileLoggers.First().Verbosity}");
        }
    }
}