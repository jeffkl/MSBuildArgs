using NUnit.Framework;
using Shouldly;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class NoLogoTest
    {
        [Fact]
        public void NoLogoFalse()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NoLogo = false,
            };

            commandLineArguments.ToString().ShouldBeEmpty();
        }

        [Fact]
        public void NoLogoTrue()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NoLogo = true,
            };

            commandLineArguments.ToString().ShouldBe("/NoLogo");
        }
    }
}