using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class ToolsVersionTest
    {
        [Test]
        public void ToolsVersion()
        {
            const string toolsVersion = "Test";

            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                ToolsVersion = toolsVersion,
            };

            commandLineArguments.ToString().ShouldBe($"/ToolsVersion:{toolsVersion}");
        }
    }
}