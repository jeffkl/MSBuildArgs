using System;
using System.Collections.Generic;

namespace Microsoft.Build.CommandLine.Arguments
{
    /// <summary>
    /// Represents parameters to a file logger.
    /// </summary>
    public sealed class MSBuildFileLoggerParameters : MSBuildConsoleLoggerParameters
    {
        /// <summary>
        /// Gets or sets a value indicating if the log file should be appended to.  The default behavior is to overwrite the file.
        /// </summary>
        public bool? Append { get; set; }

        /// <summary>
        /// Gets or set a value indicating what encoding to use when writing the log file.
        /// </summary>
        public string Encoding { get; set; }

        /// <summary>
        /// Gets or sets the path to the log file into which the build log is written.
        /// </summary>
        public string LogFile { get; set; }

        /// <summary>
        /// Returns a list of arguments for this object.
        /// </summary>
        protected override IEnumerable<string> GetArguments(bool useShortSwitchNames)
        {
            if (!String.IsNullOrWhiteSpace(LogFile))
            {
                yield return $"LogFile={LogFile}";
            }

            if (Append.HasValue && Append.Value)
            {
                yield return "Append";
            }

            if (!String.IsNullOrWhiteSpace(Encoding))
            {
                yield return $"Encoding={Encoding}";
            }

            foreach (string argument in base.GetArguments(useShortSwitchNames))
            {
                yield return argument;
            }
        }
    }
}