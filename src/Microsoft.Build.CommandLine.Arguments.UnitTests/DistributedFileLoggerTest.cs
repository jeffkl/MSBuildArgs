using Shouldly;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class DistributedFileLoggerTest : TestBase
    {
        [Fact]
        public void DistributedFileLoggerFalse()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                DistributedFileLogger = false
            };

            commandLineArguments.ToString().ShouldBeEmpty();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void DistributedFileLoggerTrue(bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                DistributedFileLogger = true
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "dfl" : "DistributedFileLogger";
        }
    }
}