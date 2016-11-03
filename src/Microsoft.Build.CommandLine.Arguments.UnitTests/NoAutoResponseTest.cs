using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class NoAutoResponseTest : TestBase
    {
        [Test]
        public void NoAutoResponseFalse()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NoAutoResponse = false,
            };

            commandLineArguments.ToString().ShouldBeEmpty();
        }

        [Test]
        public void NoAutoResponseTrue([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NoAutoResponse = true,
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "noautorsp" : "NoAutoResponse";
        }
    }
}