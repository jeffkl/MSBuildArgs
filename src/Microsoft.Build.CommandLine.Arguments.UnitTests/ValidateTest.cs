using System;
using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class ValidateTest
    {
        [Test]
        public void ValidateDefault()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                Validate = String.Empty,
            };

            commandLineArguments.ToString().ShouldBe("/Validate");
        }

        [Test]
        public void ValidateCustom()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                Validate = "Custom.xsd",
            };

            commandLineArguments.ToString().ShouldBe($"/Validate:{commandLineArguments.Validate}");
        }
    }
}