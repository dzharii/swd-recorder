using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SwdPageRecorder.ConfigurationManagement.Internals;
using Newtonsoft.Json.Linq;
using FluentAssertions;

namespace SwdPageRecorder.Tests.SwdPageRecorder.ConfigurationManagement.Internals
{
    [TestFixture]
    public class FieldExpression_Tests
    {
        [Test]
        public void JPathExpressions()
        {
            var sample = new
            {
                browserName = "Firefox",

            };

            var jobject = JObject.FromObject(sample);

            FieldExpression.HasMatches("browserName:firefox", jobject).Should().BeTrue();
            
        }
    }
}
