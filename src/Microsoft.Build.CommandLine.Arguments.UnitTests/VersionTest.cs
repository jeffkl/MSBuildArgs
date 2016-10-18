using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class VersionTest
    {

        [Test]
        public void VersionTrue()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                Version = true,
            };

            commandLineArguments.ToString().ShouldBe("/Version");
        }

        [Test]
        public void VersionFalse()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                Version = false,
            };

            commandLineArguments.ToString().ShouldBeEmpty();
        }
    }
}