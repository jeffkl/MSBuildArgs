using Microsoft.Build.Framework;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public abstract class TestBase
    {
        protected abstract string GetSwitchName(bool useShortSwitchNames);

        protected string GetVerbositySwitch(LoggerVerbosity verbosity, bool useShortSwitchNames)
        {
            return $"{(useShortSwitchNames ? "v" : "Verbosity")}={(useShortSwitchNames ? verbosity == LoggerVerbosity.Diagnostic ? "diag" : verbosity.ToString().ToLowerInvariant().Substring(0, 1) : verbosity.ToString())}";
        }
    }
}