using Shouldly;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class ProjectTest
    {
        [Fact]
        public void ProjectNull()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                Project = null,
            };

            commandLineArguments.ToString().ShouldBeEmpty();
        }

        [Fact]
        public void ProjectSpecified()
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                Project = @"C:\path\to\a\project\file\foo.csproj",
            };

            commandLineArguments.ToString().ShouldBe($"{commandLineArguments.Project}");
        }

        [Fact]
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