using Shouldly;
using System.Linq;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class DistributedLoggerParametersTest : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LoggerParametersMultipleTest(bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.DistributedLoggers.Add(new MSBuildDistributedLoggerParameters
            {
                CentralLogger = new MSBuildLoggerParameters
                {
                    Assembly = "MyLogger,Version=1.0.2,Culture=neutral",
                    ClassName = "XMLLogger",
                    Parameters = "1 2 3",
                },
                ForwardingLogger = new MSBuildLoggerParameters
                {
                    Assembly = "ForwardingLogger,Version=1.0,Culture=neutral",
                    ClassName = "XMLLogger",
                }
            });

            commandLineArguments.DistributedLoggers.Add(new MSBuildDistributedLoggerParameters
            {
                CentralLogger = new MSBuildLoggerParameters
                {
                    Assembly = "MyLogger2,Version=1.0.3,Culture=neutral",
                    ClassName = "XMLLogger3",
                },
                ForwardingLogger = new MSBuildLoggerParameters
                {
                    Assembly = "ForwardingLogger2,Version=1.0.0,Culture=neutral",
                    ClassName = "XMLLogger2",
                }
            });

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"\"/{GetSwitchName(useShortSwitchNames)}:{commandLineArguments.DistributedLoggers.First().CentralLogger.ClassName},{commandLineArguments.DistributedLoggers.First().CentralLogger.Assembly};{commandLineArguments.DistributedLoggers.First().CentralLogger.Parameters}*{commandLineArguments.DistributedLoggers.First().ForwardingLogger.ClassName},{commandLineArguments.DistributedLoggers.First().ForwardingLogger.Assembly}\" \"/{GetSwitchName(useShortSwitchNames)}:{commandLineArguments.DistributedLoggers.Last().CentralLogger.ClassName},{commandLineArguments.DistributedLoggers.Last().CentralLogger.Assembly}*{commandLineArguments.DistributedLoggers.Last().ForwardingLogger.ClassName},{commandLineArguments.DistributedLoggers.Last().ForwardingLogger.Assembly}\"");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void LoggerParametersSingleTest(bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.DistributedLoggers.Add(new MSBuildDistributedLoggerParameters
            {
                CentralLogger = new MSBuildLoggerParameters
                {
                    Assembly = "MyLogger,Version=1.0.2,Culture=neutral",
                    ClassName = "XMLLogger",
                    Parameters = "1 2 3",
                },
                ForwardingLogger = new MSBuildLoggerParameters
                {
                    Assembly = "ForwardingLogger,Version=1.0,Culture=neutral",
                    ClassName = "XMLLogger",
                }
            });

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"\"/{GetSwitchName(useShortSwitchNames)}:{commandLineArguments.DistributedLoggers.First().CentralLogger.ClassName},{commandLineArguments.DistributedLoggers.First().CentralLogger.Assembly};{commandLineArguments.DistributedLoggers.First().CentralLogger.Parameters}*{commandLineArguments.DistributedLoggers.First().ForwardingLogger.ClassName},{commandLineArguments.DistributedLoggers.First().ForwardingLogger.Assembly}\"");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "dl" : "DistributedLogger";
        }
    }
}