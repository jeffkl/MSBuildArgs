using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class NodeReuseTest : TestBase
    {
        [Test]
        public void NodeReuse([Values(true, false)] bool useShortSwitchNames, [Values(true, false)] bool nodeResuse)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                NodeReuse = nodeResuse,
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{nodeResuse}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "nr" : "NodeReuse";
        }
    }
}