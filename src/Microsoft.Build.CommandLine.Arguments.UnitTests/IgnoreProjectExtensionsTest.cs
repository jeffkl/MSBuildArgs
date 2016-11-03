using NUnit.Framework;
using Shouldly;
using System;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class IgnoreProjectExtensionsTest : TestBase
    {
        [Test]
        public void IgnoreProjectExtensionsMultiple([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.IgnoreProjectExtensions.Add(".sln");
            commandLineArguments.IgnoreProjectExtensions.Add(".proj");
            commandLineArguments.IgnoreProjectExtensions.Add(".asdf");

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{String.Join(";", commandLineArguments.IgnoreProjectExtensions)}");
        }

        [Test]
        public void IgnoreProjectExtensionsSingle([Values(true, false)] bool useShortSwitchNames)
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