using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Microsoft.Build.CommandLine.Arguments.UnitTests
{
    [TestFixture]
    public class PropertiesTest
    {

        [Test]
        public void PropertySingle()
        {
            const string propertyName = "Property1";
            const string propertyValue = "Test";

            MSBuildCommandLineArguments commandLineArguments = new MSBuildCommandLineArguments();

            commandLineArguments.Properties.Add(propertyName, propertyValue);

            commandLineArguments.ToString().ShouldBe($"/Property:{propertyName}={propertyValue}");
        }

        [Test]
        public void PropertyMultiple()
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

            commandLineArguments.ToString().ShouldBe(String.Join(" ", properties.Select(i => String.Format("/Property:{1}{0}={2}{1}", i.Key, i.Value.Contains("\"") ? "\"" : String.Empty, i.Value.Replace("\"", "\\\"")))));
        }
    }
}