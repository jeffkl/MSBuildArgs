using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class NodeReuseTest
    {
        [Test]
        public void NodeReuse([Values(true, false)] bool nodeResuse)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NodeReuse = nodeResuse,
            };

            commandLineArguments.ToString().ShouldBe($"/NodeReuse:{nodeResuse}");
        }
    }
}