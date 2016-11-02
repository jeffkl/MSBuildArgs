using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Build.CommandLine.Arguments
{
    internal static class CommandLineBuilderExtensions
    {
        public static void AppendSwitchIfNotNull(this CommandLineBuilder commandLineBuilder, string switchName, IEnumerable<string> list, string delimiter = ";")
        {
            var enumerable = list as string[] ?? list.ToArray();

            if (enumerable.Any())
            {
                commandLineBuilder.AppendSwitchIfNotNull(switchName, enumerable, delimiter);
            }
        }

        public static void AppendSwitchIfNotNull(this CommandLineBuilder commandLineBuilder, string switchName, IDictionary<string, string> list, string delimiter = "=")
        {
            foreach (KeyValuePair<string, string> item in list)
            {
                commandLineBuilder.AppendSwitchIfNotNull(switchName, $"{item.Key}{delimiter}{item.Value}");
            }
        }

        public static void AppendSwitchIfNotNull(this CommandLineBuilder commandLineBuilder, string switchName, int? value, int minValue)
        {
            if (value.HasValue)
            {
                if (value >= minValue)
                {
                    commandLineBuilder.AppendSwitchIfNotNull(switchName, value.ToString());
                }
                else
                {
                    commandLineBuilder.AppendSwitch(switchName.TrimEnd(':'));
                }
            }
        }

        public static void AppendSwitchIfNotNull<T>(this CommandLineBuilder commandLineBuilder, string switchName, T? value)
            where T : struct
        {
            if (value.HasValue)
            {
                commandLineBuilder.AppendSwitchIfNotNull(switchName, value.Value.ToString());
            }
        }

        public static void AppendSwitchIfNotNullOrEmpty(this CommandLineBuilder commandLineBuilder, string switchName, string value)
        {
            if (value != null)
            {
                if (String.Empty.Equals(value))
                {
                    commandLineBuilder.AppendSwitch(switchName.TrimEnd(':'));
                }
                else
                {
                    commandLineBuilder.AppendSwitchIfNotNull(switchName, value);
                }
            }
        }

        public static void AppendSwitchIfTrue(this CommandLineBuilder commandLineBuilder, string switchName, bool? value)
        {
            if (value.HasValue)
            {
                AppendSwitchIfTrue(commandLineBuilder, switchName, value.Value);
            }
        }

        public static void AppendSwitchIfTrue(this CommandLineBuilder commandLineBuilder, string switchName, bool value)
        {
            if (value)
            {
                commandLineBuilder.AppendSwitch(switchName);
            }
        }
    }
}