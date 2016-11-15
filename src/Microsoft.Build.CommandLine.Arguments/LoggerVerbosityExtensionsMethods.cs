using Microsoft.Build.Framework;
using System;

namespace Microsoft.Build.CommandLine.Arguments
{
    internal static class LoggerVerbosityExtensionsMethods
    {
        public static string ToString(this LoggerVerbosity? verbosity, bool useShortSwitchNames)
        {
            if (!verbosity.HasValue)
            {
                return null;
            }
            return ToString(verbosity.Value, useShortSwitchNames);
        }

        public static string ToString(this LoggerVerbosity verbosity, bool useShortSwitchNames)
        {
            if (!useShortSwitchNames)
            {
                return verbosity.ToString();
            }

            switch (verbosity)
            {
                case LoggerVerbosity.Detailed:
                    return "d";

                case LoggerVerbosity.Diagnostic:
                    return "diag";

                case LoggerVerbosity.Minimal:
                    return "m";

                case LoggerVerbosity.Normal:
                    return "n";

                case LoggerVerbosity.Quiet:
                    return "q";
            }

            throw new InvalidOperationException($"Unknown LoggerVerbosity value '{verbosity}'");
        }
    }
}