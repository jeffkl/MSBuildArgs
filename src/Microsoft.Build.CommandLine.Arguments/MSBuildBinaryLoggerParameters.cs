using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Build.CommandLine.Arguments

{
    /// <summary>
    /// Represents the parameters to the binary logger.
    /// </summary>
    public sealed class MSBuildBinaryLoggerParameters
    {
        /// <summary>
        /// Gets or sets the path to the log file into which the build log is written.
        /// </summary>
        public string LogFile { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="MSBuildBinaryLoggerProjectImportsOptions"/> value indicating how to store the imported projects.
        /// </summary>
        public MSBuildBinaryLoggerProjectImportsOptions? ProjectImports { get; set; }

        /// <inheritdoc cref="ToString"/>
        public override string ToString()
        {
            return GetArguments().Any() ? $":\"{String.Join(";", GetArguments())}\"" : String.Empty;
        }

        private IEnumerable<string> GetArguments()
        {
            if (!String.IsNullOrEmpty(LogFile))
            {
                yield return $"LogFile={LogFile}";
            }

            if (ProjectImports.HasValue)
            {
                yield return $"ProjectImports={ProjectImports}";
            }
        }
    }
}