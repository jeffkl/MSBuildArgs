using Shouldly;
using System.Linq;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class LoggerParametersTest : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LoggerParametersMultipleTest(bool useShortSwitchNames)
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

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LoggerParametersSingleTest(bool useShortSwitchNames)
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