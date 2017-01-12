namespace Microsoft.Build.CommandLine.Arguments
{
    /// <summary>
    /// Represents the parameters for a distributed logger.
    /// </summary>
    public class MSBuildDistributedLoggerParameters
    {
        /// <summary>
        /// The <see cref="MSBuildLoggerParameters"/> for the central logger.
        /// </summary>
        public MSBuildLoggerParameters CentralLogger { get; set; }

        /// <summary>
        /// The <see cref="MSBuildLoggerParameters"/> for the forwarding logger.
        /// </summary>
        public MSBuildLoggerParameters ForwardingLogger { get; set; }

        /// <summary>
        /// Gets this object as a command-line string.
        /// </summary>
        public override string ToString()
        {
            return $"{CentralLogger}*{ForwardingLogger}";
        }
    }
}