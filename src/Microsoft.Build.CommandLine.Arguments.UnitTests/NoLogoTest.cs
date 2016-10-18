using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class NoLogoTest
    {

        [Test]
        public void NoLogoTrue()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NoLogo = true,
            };

            commandLineArguments.ToString().ShouldBe("/NoLogo");
        }

        [Test]
        public void NoLogoFalse()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NoLogo = false,
            };

            commandLineArguments.ToString().ShouldBeEmpty();
        }
    }
}