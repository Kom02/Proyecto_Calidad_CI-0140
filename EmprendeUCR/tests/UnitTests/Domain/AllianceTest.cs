using Xunit;
using System;
using EmprendeUCR_WebApplication.Data.Entities;
using System.Collections.Generic;

namespace EmprendeUCR.UnitTests.Domain
{
    public class AllianceTest
    {
        [Fact]
        public void tryCreateEmpty()
        {
            var newAlliance = new Alliance();
            Assert.True(newAlliance != null);
            Assert.True(newAlliance.User_Email == null);
            Assert.True(newAlliance.Alliance_Status == 0);
            Assert.True(newAlliance.Ally_User_Email == null);
            Assert.False(newAlliance.Alliance_Id != 0);
        }
        [Fact]
        public void trySetUserEmail()
        {
            var newAlliance = new Alliance();
            newAlliance.User_Email = "asdada@gmail.com";
            Assert.True(newAlliance.User_Email != null);
        }
        [Fact]
        public void trySetAllyEmail()
        {
            var newAlliance = new Alliance();
            newAlliance.Ally_User_Email = "asdada@gmail.com";
            Assert.True(newAlliance.Ally_User_Email != null);
        }
        [Fact]
        public void trySetAllianceStatus()
        {
            var newAlliance = new Alliance();
            Assert.True(newAlliance.Alliance_Status == 0);
            newAlliance.Alliance_Status = 1;
            Assert.True(newAlliance.Alliance_Status > 0);
        }

        
    }
}
