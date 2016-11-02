using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class DetailedSummaryTest
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
        public void DetailedSummaryTrue()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                DetailedSummary = true,
            };

            commandLineArguments.ToString().ShouldBe("/DetailedSummary");
        }
    }
}