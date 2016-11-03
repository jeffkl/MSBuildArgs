using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class DistributedFileLoggerTest : TestBase
    {
        [Test]
        public void DistributedFileLoggerFalse()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                DistributedFileLogger = false
            };

            commandLineArguments.ToString().ShouldBeEmpty();
        }

        [Test]
        public void DistributedFileLoggerTrue([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                DistributedFileLogger = true
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "dfl" : "DistributedFileLogger";
        }
    }
}