using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class NoAutoResponseTest
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
        public void NoAutoResponseTrue()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NoAutoResponse = true,
            };

            commandLineArguments.ToString().ShouldBe("/NoAutoResponse");
        }

        [Test]
        public void NoAutoResponseTrueShort()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments(useShortSwitchNames: true)
            {
                NoAutoResponse = true,
            };

            commandLineArguments.ToString().ShouldBe("/noautorsp");
        }
    }
}