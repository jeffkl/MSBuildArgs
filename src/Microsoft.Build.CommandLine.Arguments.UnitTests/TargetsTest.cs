using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class TargetsTest : TestBase
    {
        [Test]
        public void TargetMultiple([Values(true, false)] bool useShortSwitchNames)
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

        [Test]
        public void TargetSingle([Values(true, false)] bool useShortSwitchNames)
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