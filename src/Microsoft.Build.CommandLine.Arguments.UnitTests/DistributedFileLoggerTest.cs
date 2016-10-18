using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class DistributedFileLoggerTest
    {
        [Test]
        public void DistributedFileLoggerTrue()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                DistributedFileLogger = true,
            };

            commandLineArguments.ToString().ShouldBe("/DistributedFileLogger");
        }

        [Test]
        public void DistributedFileLoggerFalse()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                DistributedFileLogger = false,
            };

            commandLineArguments.ToString().ShouldBeEmpty();
        }
    }
}