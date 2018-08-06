using Shouldly;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class MaxCpuTest : TestBase
    {
        [Theory]
        [InlineData(true, 1)]
        [InlineData(true, 10)]
        [InlineData(true, 50)]
        [InlineData(false, 1)]
        [InlineData(false, 10)]
        [InlineData(false, 50)]
        public void MaxCpuCountPositiveNumber(bool useShortSwitchNames, int maxCpuCount)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                MaxCpuCount = maxCpuCount
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{maxCpuCount}");
        }

        [Theory]
        [InlineData(true, 0)]
        [InlineData(true, -1)]
        [InlineData(true, -50)]
        [InlineData(false, 0)]
        [InlineData(false, -1)]
        [InlineData(false, -50)]
        public void MaxCpuCountZeroAndNegative(bool useShortSwitchNames, int maxCpuCount)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                MaxCpuCount = maxCpuCount
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "m" : "MaxCpuCount";
        }
    }
}