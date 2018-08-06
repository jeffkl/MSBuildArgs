using Microsoft.Build.Framework;
using Shouldly;
using System;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class VerbosityTest : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Verbosity(bool useShortSwitchNames)
        {
            foreach (var @enum in Enum.GetValues(typeof(LoggerVerbosity)))
            {
                MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
                {
                    Verbosity = (LoggerVerbosity)@enum,
                };

                commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{Enum.GetName(typeof(LoggerVerbosity), @enum)}");
            }
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "v" : "Verbosity";
        }
    }
}