using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class LoggerParametersTest
    {
        [Test]
        public void LoggerParametersMultipleTest()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.Loggers.Add(new MSBuildLoggerParameters
            {
                Assembly = "MyLogger,Version=1.0.2,Culture=neutral",
                ClassName = "XMLLogger",
                Parameters = "1 2 3",
            });

            commandLineArguments.Loggers.Add(new MSBuildLoggerParameters
            {
                Assembly = "CustomLogger",
                ClassName = "LoggerA",
            });

            commandLineArguments.ToString().ShouldBe($"/Logger:\"{commandLineArguments.Loggers.First().ClassName},{commandLineArguments.Loggers.First().Assembly};{commandLineArguments.Loggers.First().Parameters}\" /Logger:\"{commandLineArguments.Loggers.Last().ClassName},{commandLineArguments.Loggers.Last().Assembly}\"");
        }

        [Test]
        public void LoggerParametersSingleTest()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.Loggers.Add(new MSBuildLoggerParameters
            {
                Assembly = "MyLogger,Version=1.0.2,Culture=neutral",
                ClassName = "XMLLogger",
                Parameters = "1 2 3",
            });

            commandLineArguments.ToString().ShouldBe($"/Logger:\"{commandLineArguments.Loggers.First().ClassName},{commandLineArguments.Loggers.First().Assembly};{commandLineArguments.Loggers.First().Parameters}\"");
        }
    }
}
