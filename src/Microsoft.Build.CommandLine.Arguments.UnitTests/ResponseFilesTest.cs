using NUnit.Framework;
using Shouldly;
using System;
using System.Linq;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class ResponseFilesTest
    {
        [Test]
        public void ResponseFileMultipleTest()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.ResponseFiles.Add(@"C:\foo bar\bar1.txt");
            commandLineArguments.ResponseFiles.Add(@"C:\foo bar\bar2.txt");
            commandLineArguments.ResponseFiles.Add(@"C:\foo bar\bar3.txt");

            commandLineArguments.ToString().ShouldBe($"@\"{String.Join("\" @\"", commandLineArguments.ResponseFiles)}\"");
        }

        [Test]
        public void ResponseFileSingleTest()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.ResponseFiles.Add(@"C:\foo bar\bar.txt");

            commandLineArguments.ToString().ShouldBe($"@\"{commandLineArguments.ResponseFiles.First()}\"");
        }
    }
}