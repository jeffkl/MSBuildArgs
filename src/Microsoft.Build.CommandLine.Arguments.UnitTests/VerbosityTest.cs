using Microsoft.Build.Framework;
using NUnit.Framework;
using Shouldly;
using System;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class VerbosityTest : TestBase
    {
        [Test]
        public void Verbosity([Values(true, false)] bool useShortSwitchNames)
        {
            foreach (var @enum in Enum.GetValues(typeof(LoggerVerbosity)))
            {
                MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
                {
                    Verbosity = (LoggerVerbosity) @enum,
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