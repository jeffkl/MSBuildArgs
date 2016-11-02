using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class NodeReuseTest
    {
        [Test]
        public void NodeReuseTrueAndFalse()
        {
            foreach (bool val in new[] {true, false})
            {
                MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
                {
                    NodeReuse = val,
                };

                commandLineArguments.ToString().ShouldBe($"/NodeReuse:{val}");
            }
        }
    }
}