using NUnit.Framework;
using Shouldly;
using System.Collections.Generic;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class MaxCpuTest
    {
        [Test]
        public void MaxCpuCountPositiveNumber()
        {
            IEnumerable<int> values = new List<int>
            {
                1,
                10,
                50,
            };

            foreach (var item in values)
            {
                MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
                {
                    MaxCpuCount = item
                };

                commandLineArguments.ToString().ShouldBe($"/MaxCpuCount:{item}");
            }
        }

        [Test]
        public void MaxCpuCountZeroAndNegative()
        {
            IEnumerable<int> values = new List<int>
            {
                0,
                -1,
                -50,
            };

            foreach (var item in values)
            {
                MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
                {
                    MaxCpuCount = item
                };

                commandLineArguments.ToString().ShouldBe($"/MaxCpuCount");
            }
        }
    }
}