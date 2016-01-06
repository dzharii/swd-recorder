using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using FluentAssertions;
using SwdPageRecorder.ConfigurationManagement.ConfigurationFramework.Internals;
using SwdPageRecorder.ConfigurationManagement.Profiles;

namespace SwdPageRecorder.Tests.SwdPageRecorder.ConfigurationManagement.Internals
{
    [TestFixture]
    public class ProfileDiscovery_Tests
    {
        [Test]
        public void ProfileDiscovery_Discover__Finds_new_and_user_defined_profiles()
        {
            var profileDiscovery = new ProfileDiscovery();

            Profile[] profiles = profileDiscovery.Discover();
        }
    }
}
