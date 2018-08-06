using Shouldly;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class ToolsVersionTest : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ToolsVersion(bool useShortSwitchNames)
        {
            const string toolsVersion = "Test";

            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                ToolsVersion = toolsVersion,
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{toolsVersion}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "tv" : "ToolsVersion";
        }
    }
}