using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class NoConsoleLoggerTest
    {
        [Test]
        public void NoConsoleLoggerTrue()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NoConsoleLogger = true,
            };

            commandLineArguments.ToString().ShouldBe("/NoConsoleLogger");
        }

        [Test]
        public void NoConsoleLoggerFalse()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NoConsoleLogger = false,
            };

            commandLineArguments.ToString().ShouldBeEmpty();
        }
    }
}