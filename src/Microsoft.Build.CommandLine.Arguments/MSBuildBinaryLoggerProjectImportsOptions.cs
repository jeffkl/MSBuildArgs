namespace Microsoft.Build.CommandLine.Arguments
{
    /// <summary>
    /// Specifies how the binary logger should store project imports.
    /// </summary>
    public enum MSBuildBinaryLoggerProjectImportsOptions
    {
        /// <summary>
        /// Do not collect project imports.
        /// </summary>
        None,

        /// <summary>
        /// Embed project imports in the log file.
        /// </summary>
        Embed,

        /// <summary>
        /// Save project files to output.projectimports.zip where output is the same name as the binary log file name.
        /// </summary>
        ZipFile,
    }
}