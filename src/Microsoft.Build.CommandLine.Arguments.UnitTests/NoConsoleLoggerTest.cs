using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class NoConsoleLoggerTest : TestBase
    {
        [Test]
        public void NoConsoleLoggerFalse()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NoConsoleLogger = false,
            };

            commandLineArguments.ToString().ShouldBeEmpty();
        }

        [Test]
        public void NoConsoleLoggerTrue([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NoConsoleLogger = true,
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "noconlog" : "NoConsoleLogger";
        }
    }
}