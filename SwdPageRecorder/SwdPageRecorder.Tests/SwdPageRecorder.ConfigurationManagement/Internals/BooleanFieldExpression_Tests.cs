using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using FluentAssertions;
using SwdPageRecorder.ConfigurationManagement.ConfigurationFramework.Internals;

namespace SwdPageRecorder.Tests.SwdPageRecorder.ConfigurationManagement.Internals
{
    [TestFixture]
    public class BooleanFieldExpression_Tests
    {
        [Test]
        // Case insensitive trim spaces 
        public void BooleanFieldExpression_HasMatches__Case_insensitive_trim_spaces()
        {
            var sample = new
            {
                browserName = "Firefox",

            };

            var jobject = JObject.FromObject(sample);

            BooleanFieldExpression.HasMatches("browserName:firefox", jobject).Should().BeTrue();
            BooleanFieldExpression.HasMatches("browserName: Firefox", jobject).Should().BeTrue();
            BooleanFieldExpression.HasMatches("browserName: FIREFOX", jobject).Should().BeTrue();
            BooleanFieldExpression.HasMatches("browserName: FIREFOx ", jobject).Should().BeTrue();

        }
    }
}
