using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class VersionTest : TestBase
    {
        [Test]
        public void VersionFalse()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                Version = false,
            };

            commandLineArguments.ToString().ShouldBeEmpty();
        }

        [Test]
        public void VersionTrue([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                Version = true,
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "ver" : "Version";
        }
    }
}