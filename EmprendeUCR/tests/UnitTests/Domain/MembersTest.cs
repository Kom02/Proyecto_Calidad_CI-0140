/*
 * Diego Barquero Quesada
 * B80961
 * Pruebas de Unidad e Integración.
 * Members Test
 * */
using EmprendeUCR.Domain.Core.CoreEntities;
using Xunit;

namespace EmprendeUCR.UnitTests.Domain
{
    public class MembersTest
    {
        [Fact]
        public void TryCreateMembers()
        {
            string email = "Juan@.com";
            int score = 10;
            double lat = 3;
            double LongMember = 4;
            string direction = "cartgo";

            Members member = new Members
            {
                User_Email=email,
                Score=score,
                Lat=lat,
                Long=LongMember,
                Direction= direction
            };
            Assert.True(email == member.User_Email, "The member email is not the same");
            Assert.True(score == member.Score, "The member score is not the same");
            Assert.True(lat == member.Lat, "The member lat is not the same");
            Assert.True(LongMember == member.Long, "The member long is not the same");
            Assert.True(LongMember == member.Long, "The member long is not the same");
            Assert.True(direction == member.Direction, "The member direction is not the same");
        }
    }
}
