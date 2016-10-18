using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Build.CommandLine.Arguments
{
    /// <summary>
    /// Represents the parameters to a custom logger.
    /// </summary>
    public class MSBuildLoggerParameters
    {
        /// <summary>
        /// Gets or sets the assembly that contains the logger.  The value can be either a path to the assembly for an assembly name.
        /// </summary>
        public string Assembly { get; set; }

        /// <summary>
        /// Gets or sets the name of the class that contains the logger.  The value can be a partial or fully-qualified class name.
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// Gets or sets parameters to pass to the logger.
        /// </summary>
        public string Parameters { get; set; }

        /// <summary>
        /// Gets this object as a command-line string.
        /// </summary>
        public override string ToString()
        {
            return GetArguments().Any() ? String.Join(";", GetArguments()) : null;
        }

        private IEnumerable<string> GetArguments()
        {
            if (!String.IsNullOrWhiteSpace(Assembly) || !String.IsNullOrWhiteSpace(ClassName))
            {
                yield return $"{ClassName},{Assembly}";
            }

            if (!String.IsNullOrWhiteSpace(Parameters))
            {
                yield return Parameters;
            }
        }
    }
}