using System;
using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class IgnoreProjectExtensionsTest
    {
        [Test]
        public void IgnoreProjectExtensionsSingle()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.IgnoreProjectExtensions.Add(".sln");

            commandLineArguments.ToString().ShouldBe($"/IgnoreProjectExtensions:{String.Join(";", commandLineArguments.IgnoreProjectExtensions)}");
        }

        [Test]
        public void IgnoreProjectExtensionsMultiple()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.IgnoreProjectExtensions.Add(".sln");
            commandLineArguments.IgnoreProjectExtensions.Add(".proj");
            commandLineArguments.IgnoreProjectExtensions.Add(".asdf");

            commandLineArguments.ToString().ShouldBe($"/IgnoreProjectExtensions:{String.Join(";", commandLineArguments.IgnoreProjectExtensions)}");
        }
    }
}