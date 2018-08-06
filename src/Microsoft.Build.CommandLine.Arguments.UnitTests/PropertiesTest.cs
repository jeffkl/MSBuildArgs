using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    public class PropertiesTest : TestBase
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PropertyMultiple(bool useShortSwitchNames)
        {
            IDictionary<string, string> properties = new Dictionary<string, string>
            {
                {"Property1", "Test"},
                {"Property2", "\"This is a test\""},
                {"Property3", "Quote \"\" in the middle"}
            };

            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            foreach (var item in properties)
            {
                commandLineArguments.Properties.Add(item.Key, item.Value);
            }

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe(String.Join(" ", properties.Select(i => String.Format("/{3}:{1}{0}={2}{1}", i.Key, i.Value.Contains("\"") ? "\"" : String.Empty, i.Value.Replace("\"", "\\\""), GetSwitchName(useShortSwitchNames)))));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void PropertySingle(bool useShortSwitchNames)
        {
            const string propertyName = "Property1";
            const string propertyValue = "Test";

            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.Properties.Add(propertyName, propertyValue);

            commandLineArguments.ToString(useShortSwitchNames: useShortSwitchNames).ShouldBe($"/{GetSwitchName(useShortSwitchNames)}:{propertyName}={propertyValue}");
        }

        protected override string GetSwitchName(bool useShortSwitchNames)
        {
            return useShortSwitchNames ? "p" : "Property";
        }
    }
}