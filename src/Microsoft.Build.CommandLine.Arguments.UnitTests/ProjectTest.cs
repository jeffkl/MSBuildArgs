using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class ProjectTest
    {
        [Test]
        public void ProjectNull()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                Project = null,
            };

            commandLineArguments.ToString().ShouldBeEmpty();
        }

        [Test]
        public void ProjectSpecified()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                Project = @"C:\path\to\a\project\file\foo.csproj",
            };

            commandLineArguments.ToString().ShouldBe($"{commandLineArguments.Project}");
        }

        [Test]
        public void ProjectSpecifiedWithSpaces()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                Project = @"C:\path to\a\project file\foo.csproj",
            };

            commandLineArguments.ToString().ShouldBe($"\"{commandLineArguments.Project}\"");
        }
    }
}