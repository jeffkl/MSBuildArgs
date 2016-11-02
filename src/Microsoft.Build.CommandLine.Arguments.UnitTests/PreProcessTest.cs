using NUnit.Framework;
using Shouldly;
using System;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class PreProcessTest
    {
        [Test]
        public void PreProcessCustom()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                PreProcess = "Custom.xml",
            };

            commandLineArguments.ToString().ShouldBe($"/PreProcess:{commandLineArguments.PreProcess}");
        }

        [Test]
        public void PreProcessDefault()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                PreProcess = String.Empty,
            };

            commandLineArguments.ToString().ShouldBe("/PreProcess");
        }
    }
}