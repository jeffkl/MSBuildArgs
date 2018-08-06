using Shouldly;
using System;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class IgnoreProjectExtensionsTest : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IgnoreProjectExtensionsMultiple(bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.IgnoreProjectExtensions.Add(".sln");
            commandLineArguments.IgnoreProjectExtensions.Add(".proj");
            commandLineArguments.IgnoreProjectExtensions.Add(".asdf");

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{String.Join(";", commandLineArguments.IgnoreProjectExtensions)}");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IgnoreProjectExtensionsSingle(bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.IgnoreProjectExtensions.Add(".sln");

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{String.Join(";", commandLineArguments.IgnoreProjectExtensions)}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "ignore" : "IgnoreProjectExtensions";
        }
    }
}