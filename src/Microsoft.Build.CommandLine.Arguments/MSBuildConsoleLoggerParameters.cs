using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return ToString(useShortSwitchNames: false);
        }

        /// <summary>
        /// Gets this object as a command-line string.
        /// </summary>
        /// <param name="useShortSwitchNames"><code>true</code> to use short switch names, otherwise <code>false</code>.</param>
        /// <returns></returns>
        public string ToString(bool useShortSwitchNames)
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            return GetArguments(useShortSwitchNames).Any() ? String.Join(";", GetArguments(useShortSwitchNames)) : null;
        }

        /// <summary>
        /// Returns a list of arguments for this object.
        /// </summary>
        protected virtual IEnumerable<string> GetArguments(bool useShortSwitchNames)
        {
            if (Options.HasValue)
            {
                yield return Options.ToString().Replace(", ", ";");
            }

            if (Verbosity.HasValue)
            {
                yield return $"{(useShortSwitchNames ? "v" : "Verbosity")}={Verbosity.ToString(useShortSwitchNames)}";
            }
        }
    }
}