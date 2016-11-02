using Microsoft.Build.Framework;
using NUnit.Framework;
using Shouldly;
using System;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class VerbosityTest
    {
        [Test]
        public void Verbosity()
        {
            foreach (var @enum in Enum.GetValues(typeof(LoggerVerbosity)))
            {
                MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
                {
                    Verbosity = (LoggerVerbosity) @enum,
                };

                commandLineArguments.ToString().ShouldBe($"/Verbosity:{Enum.GetName(typeof(LoggerVerbosity), @enum)}");
            }
        }
    }
}