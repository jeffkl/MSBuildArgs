using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class ToolsVersionTest : TestBase
    {
        [Test]
        public void ToolsVersion([Values(true, false)] bool useShortSwitchNames)
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