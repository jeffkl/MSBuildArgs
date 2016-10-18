using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Build.Framework;

namespace Microsoft.Build.CommandLine.Arguments
{
    /// <summary>
    /// Represents the parameters to the console logger.
    /// </summary>
    public class MSBuildConsoleLoggerParameters
    {
        /// <summary>
        /// Gets or sets the <see cref="MSBuildLoggerOptions"/>.
        /// </summary>
        public MSBuildLoggerOptions? Options { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="LoggerVerbosity"/>.
        /// </summary>
        public LoggerVerbosity? Verbosity { get; set; }

        /// <summary>
        /// Gets this object as a command-line string.
        /// </summary>
        public override string ToString()
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            return GetArguments().Any() ? String.Join(";", GetArguments()) : null;
        }

        /// <summary>
        /// Returns a list of arguments for this object.
        /// </summary>
        protected virtual IEnumerable<string> GetArguments()
        {
            if (Options.HasValue)
            {
                yield return Options.ToString().Replace(", ", ";");
            }

            if (Verbosity.HasValue)
            {
                yield return $"Verbosity={Verbosity}";
            }
        }
    }
}