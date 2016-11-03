using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class MaxCpuTest : TestBase
    {
        [Test]
        public void MaxCpuCountPositiveNumber([Values(true, false)] bool useShortSwitchNames, [Values(1, 10, 50)] int maxCpuCount)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                MaxCpuCount = maxCpuCount
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{maxCpuCount}");
        }

        [Test]
        public void MaxCpuCountZeroAndNegative([Values(true, false)] bool useShortSwitchNames, [Values(0, -1, -50)] int maxCpuCount)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                MaxCpuCount = maxCpuCount
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "m" : "MaxCpuCount";
        }
    }
}