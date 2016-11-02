using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class TargetsTest
    {
        [Test]
        public void TargetMultiple()
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

            commandLineArguments.ToString().ShouldBe($"/Target:{String.Join(";", targets)}");
        }

        [Test]
        public void TargetSingle()
        {
            const string target = "Test";

            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.Targets.Add(target);

            commandLineArguments.ToString().ShouldBe($"/Target:{target}");
        }
    }
}