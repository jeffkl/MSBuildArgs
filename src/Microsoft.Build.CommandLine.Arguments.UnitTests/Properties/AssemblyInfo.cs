using System.Reflection;
using System.Runtime.InteropServices;

#if DEBUG

[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Microsoft.Build.CommandLine.Arguments")]
[assembly: ComVisible(false)]