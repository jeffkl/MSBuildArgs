using Shouldly;
using System;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class PreProcessTest : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PreProcessCustom(bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                PreProcess = "Custom.xml",
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{commandLineArguments.PreProcess}");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PreProcessDefault(bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                PreProcess = String.Empty,
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "pp" : "PreProcess";
        }
    }
}