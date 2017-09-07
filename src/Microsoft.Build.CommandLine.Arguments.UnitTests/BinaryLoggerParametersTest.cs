using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class BinaryLoggerParametersTest : TestBase
    {
        [Test]
        public void BinaryLoggerParametersLogFile([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                BinaryLogger = new MSBuildBinaryLoggerParameters
                {
                    LogFile = "foo.binlog",
                }
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:\"LogFile={commandLineArguments.BinaryLogger.LogFile}\"");
        }

        [Test]
        public void BinaryLoggerParametersMultipleOptions([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                BinaryLogger = new MSBuildBinaryLoggerParameters
                {
                    LogFile = "foo.binlog",
                    ProjectImports = MSBuildBinaryLoggerProjectImportsOptions.Embed,
                }
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:\"LogFile=foo.binlog;ProjectImports=Embed\"");
        }

        [Test]
        public void BinaryLoggerParametersNotNullButEmpty([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                BinaryLogger = new MSBuildBinaryLoggerParameters(),
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}");
        }

        [Test]
        public void BinaryLoggerParametersProjectImports([Values(true, false)] bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                BinaryLogger = new MSBuildBinaryLoggerParameters
                {
                    ProjectImports = MSBuildBinaryLoggerProjectImportsOptions.ZipFile
                }
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:\"ProjectImports={commandLineArguments.BinaryLogger.ProjectImports}\"");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "bl" : "BinaryLogger";
        }
    }
}