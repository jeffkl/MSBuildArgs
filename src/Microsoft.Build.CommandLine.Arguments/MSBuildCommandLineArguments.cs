using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Build.CommandLine.Arguments
{
    /// <summary>
    /// Represents the MSBuild command-line arguments.
    /// </summary>
    public class MSBuildCommandLineArguments
    {
        /// <summary>
        /// Gets or sets the <see cref="MSBuildConsoleLoggerParameters"/>.
        /// </summary>
        public MSBuildConsoleLoggerParameters ConsoleLoggerParameters { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not detailed information should be displayed at the end of the build about the configurations built and how they were scheduled to nodes.
        /// </summary>
        public bool? DetailedSummary { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the build output of each MSBuild node should be logged to its own file. The initial location for these files is the current directory. By default, the files are named "MSBuildNodeId.log". You can use the <see cref="FileLoggers"/> property to specify the location of the files and other parameters for the fileLogger.
        /// </summary>
        public bool? DistributedFileLogger { get; set; }

        /// <summary>
        /// Gets a list of <see cref="MSBuildFileLoggerParameters"/>.
        /// </summary>
        public IList<MSBuildFileLoggerParameters> FileLoggers { get; set; } = new List<MSBuildFileLoggerParameters>();

        /// <summary>
        /// Gets a list of extensions to ignore when determining which project file to build.
        /// </summary>
        public IList<string> IgnoreProjectExtensions { get; } = new List<string>();

        /// <summary>
        /// Gets a list of custom loggers to use.
        /// </summary>
        public IList<MSBuildLoggerParameters> Loggers { get; set; } = new List<MSBuildLoggerParameters>();

        /// <summary>
        /// Gets or sets the maximum the maximum number of concurrent processes to build with.  If the switch is not used, the default value used is 1. If the switch is used without a value MSBuild will use up to the number of processors on the computer.
        /// </summary>
        public int? MaxCpuCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not to auto-include any MSBuild.rsp files.
        /// </summary>
        public bool? NoAutoResponse { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the default console logger should be disabled and to not log events to the console.
        /// </summary>
        public bool? NoConsoleLogger { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not to reuse MSBuild nodes.
        /// </summary>
        public bool? NodeReuse { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the startup banner or the copyright message should not be shown.
        /// </summary>
        public bool? NoLogo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating that a single, aggregated project file by should be created inlining all the files that would be imported during a build, with their boundaries marked.
        /// This can be useful for figuring out what files are being imported and from where, and what they will contribute to the build. By default the output is written to the console window.
        /// If the path to an output file is provided that will be used instead.
        /// </summary>
        public string PreProcess { get; set; }

        /// <summary>
        /// Gets or sets the path to the project to build.
        /// </summary>
        public string Project { get; set; }

        /// <summary>
        /// Gets a list of project-level properties.
        /// </summary>
        public IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Gets a list of text files to use that contain command-line settings.
        /// </summary>
        /// <remarks>
        /// Any response files named &quot;MSBuild.rsp&quot; are automatically consumed from the following locations:
        /// <list type="number">
        ///   <item>
        ///     <description>The directory of MSBuild.exe.</description>
        ///   </item>
        ///   <item>
        ///     <description>The directory of the first project or solution built.</description>
        ///   </item>
        /// </list>
        /// </remarks>
        public IList<string> ResponseFiles { get; } = new List<string>();

        /// <summary>
        /// Gets the list of targets to build.
        /// </summary>
        public IList<string> Targets { get; } = new List<string>();

        /// <summary>
        /// Gets or sets the version of the MSBuild Toolset (tasks, targets, etc.) to use during build.This version will override the versions specified by individual projects.
        /// </summary>
        public string ToolsVersion { get; set; }

        /// <summary>
        /// Gets or sets a schema to Validate the project against.  Specify <see cref="String.Empty"/> to validate against the default schema.
        /// </summary>
        public string Validate { get; set; }

        /// <summary>
        /// Gets or sets the verbosity of information to display in the event log.
        /// </summary>
        public LoggerVerbosity? Verbosity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if the version information only should be displayed.  If the value is <code>true</code>, the project is not built.
        /// </summary>
        public bool? Version { get; set; }

        /// <summary>
        /// Gets the MSBuild command-line based on the current properties of this object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(useShortSwitchNames: false);
        }

        /// <summary>
        /// Gets the MSBuild command-line based on the current properties of this object.
        /// </summary>
        /// <param name="useShortSwitchNames"><code>true</code> to use short command-line argument switches like '/nr' instead of '/NodeReuse', otherwise <code>false</code>.</param>
        /// <returns></returns>
        public string ToString(bool useShortSwitchNames)
        {
            CommandLineBuilder commandLineBuilder = new CommandLineBuilder();

            commandLineBuilder.AppendSwitchIfNotNull($"/{(useShortSwitchNames ? "t" : "Target")}:", Targets);

            commandLineBuilder.AppendSwitchIfNotNull($"/{(useShortSwitchNames ? "p" : "Property")}:", Properties);

            commandLineBuilder.AppendSwitchIfNotNull($"/{(useShortSwitchNames ? "m" : "MaxCpuCount")}:", MaxCpuCount, minValue: 1);

            commandLineBuilder.AppendSwitchIfNotNull($"/{(useShortSwitchNames ? "tv" : "ToolsVersion")}:", ToolsVersion);

            commandLineBuilder.AppendSwitchIfNotNull($"/{(useShortSwitchNames ? "v" : "Verbosity")}:", Verbosity);

            commandLineBuilder.AppendSwitchIfNotNullOrEmpty($"/{(useShortSwitchNames ? "val" : "Validate")}:", Validate);

            commandLineBuilder.AppendSwitchIfNotNull($"/{(useShortSwitchNames ? "ignore" : "IgnoreProjectExtensions")}:", IgnoreProjectExtensions);

            if (ConsoleLoggerParameters != null)
            {
                commandLineBuilder.AppendSwitchIfNotNull($"/{(useShortSwitchNames ? "clp" : "ConsoleLoggerParameters")}:", ConsoleLoggerParameters.ToString());
            }

            commandLineBuilder.AppendSwitchIfTrue($"/{(useShortSwitchNames ? "dfl" : "DistributedFileLogger")}", DistributedFileLogger);

            foreach (MSBuildLoggerParameters logger in Loggers)
            {
                commandLineBuilder.AppendSwitch($"\"/{(useShortSwitchNames ? "l" : "Logger")}:{logger}\"");
            }

            commandLineBuilder.AppendSwitchIfNotNull($"/{(useShortSwitchNames ? "nr" : "NodeReuse")}:", NodeReuse);

            commandLineBuilder.AppendSwitchIfTrue($"/{(useShortSwitchNames ? "noconlog" : "NoConsoleLogger")}", NoConsoleLogger);

            for (int i = 0; i < FileLoggers.Count; i++)
            {
                string index = FileLoggers.Count > 1 ? i.ToString() : String.Empty;

                commandLineBuilder.AppendSwitch($"/{(useShortSwitchNames ? "fl" : "FileLogger")}{index}");

                commandLineBuilder.AppendSwitchIfNotNull($"/{(useShortSwitchNames ? "flp" : "FileLoggerParameters")}{index}:", FileLoggers[i].ToString());
            }

            commandLineBuilder.AppendSwitchIfNotNullOrEmpty($"/{(useShortSwitchNames ? "pp" : "PreProcess")}:", PreProcess);

            commandLineBuilder.AppendSwitchIfTrue($"/{(useShortSwitchNames ? "ds" : "DetailedSummary")}", DetailedSummary);

            commandLineBuilder.AppendSwitchIfTrue($"/{(useShortSwitchNames ? "noautorsp" : "NoAutoResponse")}", NoAutoResponse);

            commandLineBuilder.AppendSwitchIfTrue("/NoLogo", NoLogo);

            commandLineBuilder.AppendSwitchIfTrue($"/{(useShortSwitchNames ? "ver" : "Version")}", Version);

            foreach (string responseFile in ResponseFiles.Where(i => !String.IsNullOrWhiteSpace(i)))
            {
                commandLineBuilder.AppendSwitch("@");
                commandLineBuilder.AppendTextUnquoted($"\"{responseFile}\"");
            }

            commandLineBuilder.AppendFileNameIfNotNull(Project);

            return commandLineBuilder.ToString();
        }
    }
}