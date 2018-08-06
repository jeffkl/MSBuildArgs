using Shouldly;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class BinaryLoggerParametersTest : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void BinaryLoggerParametersLogFile(bool useShortSwitchNames)
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

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void BinaryLoggerParametersMultipleOptions(bool useShortSwitchNames)
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

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void BinaryLoggerParametersNotNullButEmpty(bool useShortSwitchNames)
        {
            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments
            {
                BinaryLogger = new MSBuildBinaryLoggerParameters(),
            };

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}");
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void BinaryLoggerParametersProjectImports(bool useShortSwitchNames)
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