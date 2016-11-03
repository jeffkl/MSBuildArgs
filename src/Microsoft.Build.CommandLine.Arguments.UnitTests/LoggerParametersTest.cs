using NUnit.Framework;
using Shouldly;
using System.Linq;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class LoggerParametersTest : TestBase
    {
        [Test]
        public void LoggerParametersMultipleTest([Values(true, false)] bool useShortSwitchNames)
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

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"\"/{GetSwitchName(useShortSwitchNames)}:{commandLineArguments.Loggers.First().ClassName},{commandLineArguments.Loggers.First().Assembly};{commandLineArguments.Loggers.First().Parameters}\" \"/{GetSwitchName(useShortSwitchNames)}:{commandLineArguments.Loggers.Last().ClassName},{commandLineArguments.Loggers.Last().Assembly}\"");
        }

        [Test]
        public void LoggerParametersSingleTest([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.Loggers.Add(new MSBuildLoggerParameters
            {
                Assembly = "MyLogger,Version=1.0.2,Culture=neutral",
                ClassName = "XMLLogger",
                Parameters = "1 2 3",
            });

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"\"/{GetSwitchName(useShortSwitchNames)}:{commandLineArguments.Loggers.First().ClassName},{commandLineArguments.Loggers.First().Assembly};{commandLineArguments.Loggers.First().Parameters}\"");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "l" : "Logger";
        }
    }
}