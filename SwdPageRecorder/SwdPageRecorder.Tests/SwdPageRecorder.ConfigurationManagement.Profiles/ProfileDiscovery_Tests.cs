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
using System.IO;
using Newtonsoft.Json;

namespace SwdPageRecorder.Tests.SwdPageRecorder.ConfigurationManagement.Profiles
{
    [TestFixture]
    public class ProfileDiscovery_Tests
    {
        [Test]
        public void ProfileDiscovery_Discover__Finds_new_and_user_defined_profiles()
        {
            var profileDiscovery = new ProfileDiscovery();
            using (var newProfile = new TemporaryTestProfile())
            {
                newProfile.ProfileMapping.profile.displayName = "New Profile";
                newProfile.Create("NewProfile.json");

                Profile[] listWithExpectedProfile = profileDiscovery.Discover();

                var discoveredProfile = listWithExpectedProfile.FirstOrDefault(p => p.FileName == "NewProfile.json");
                discoveredProfile.Should().NotBeNull("Discover must find new profile");
                discoveredProfile.HasErrors.Should().BeFalse("must not have errors");
            }
        }
        [Test]
        public void ProfileDiscovery_Discover__Should_report_errors_inside_profile()
        {
            var profileDiscovery = new ProfileDiscovery();
            using (var newProfile = new TemporaryTestProfile())
            {
                newProfile.ProfileMapping.profile.displayName = "New Profile with Errors";
                newProfile.Create("NewErrorsProfile.json");
                // Corrupt JSON by appending text lines

                File.AppendAllText(newProfile.ProfileFilePath, "CORRUPTED }}}{{{");

                Profile[] listWithExpectedProfile = profileDiscovery.Discover();

                var discoveredProfile = listWithExpectedProfile.FirstOrDefault(p => p.FileName == "NewErrorsProfile.json");
                discoveredProfile.Should().NotBeNull("Discover must find new profile");
                discoveredProfile.HasErrors.Should().BeTrue("profile must have errors");
            }
        }
    }
}

