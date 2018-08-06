using Shouldly;
using System;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class ValidateTest : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ValidateCustom(bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                Validate = "Custom.xsd",
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{commandLineArguments.Validate}");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ValidateDefault(bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                Validate = String.Empty,
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "val" : "Validate";
        }
    }
}