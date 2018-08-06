using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class TargetsTest : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TargetMultiple(bool useShortSwitchNames)
        {
            var targets = new List<string>
            {
                "Test1",
                "test2",
                "Test3"
            };

            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            foreach (var target in targets)
            {
                commandLineArguments.Targets.Add(target);
            }

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{String.Join(";", targets)}");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TargetSingle(bool useShortSwitchNames)
        {
            const string target = "Test";

            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.Targets.Add(target);

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{target}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "t" : "Target";
        }
    }
}