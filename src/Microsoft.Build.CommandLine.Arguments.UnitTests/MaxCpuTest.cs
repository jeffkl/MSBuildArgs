using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class MaxCpuTest
    {
        [Test]
        public void MaxCpuCountPositiveNumber([Values(1, 10, 50)] int maxCpuCount)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                MaxCpuCount = maxCpuCount
            };

            commandLineArguments.ToString().ShouldBe($"/MaxCpuCount:{maxCpuCount}");
        }

        [Test]
        public void MaxCpuCountZeroAndNegative([Values(0, -1, -50)] int maxCpuCount)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                MaxCpuCount = maxCpuCount
            };

            commandLineArguments.ToString().ShouldBe("/MaxCpuCount");
        }
    }
}