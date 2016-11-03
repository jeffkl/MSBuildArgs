using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class DetailedSummaryTest : TestBase
    {
        [Test]
        public void DetailedSummaryFalse()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                DetailedSummary = false,
            };

            commandLineArguments.ToString().ShouldBeEmpty();
        }

        [Test]
        public void DetailedSummaryTrue([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                DetailedSummary = true,
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "ds" : "DetailedSummary";
        }
    }
}