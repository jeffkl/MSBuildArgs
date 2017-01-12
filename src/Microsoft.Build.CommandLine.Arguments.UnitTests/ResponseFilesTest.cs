using NUnit.Framework;
using Shouldly;
using System;
using System.IO;
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

        [Test]
        public void ResponseFileEntireCommandLine([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NoLogo = true,
                ResponseFiles =
                {
                    Path.GetTempFileName()
                },
            };

            string responseFilePath = Path.GetTempFileName();

            try
            {
                commandLineArguments.ToString(responseFilePath, useShortSwitchNames).ShouldBe($"@\"{responseFilePath}\"");

                string responseFileContents = File.ReadAllText(responseFilePath);

                responseFileContents.ShouldBe($"/NoLogo @\"{commandLineArguments.ResponseFiles.First()}\"");
            }
            finally
            {
                foreach (string file in commandLineArguments.ResponseFiles.Concat(new[] { responseFilePath }))
                {
                    File.Delete(file);
                }
            }
        }
    }
}