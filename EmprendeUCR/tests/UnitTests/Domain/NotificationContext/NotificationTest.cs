using EmprendeUCR_WebApplication.Domain.NotificationContext;
using FluentAssertions;
using Xunit;
namespace EmprendeUCR.UnitTests.Domain.NotificationContext
{
    public class NotificationTest
    {

        [Fact]
        public void NotificationStandardMessage()
        {
            // arrange
            var notification = new Notification();
            // act
            var player = notification.ToString();
            // assert
            player.Should().Be("Ha recibido una nueva notificación");
        }
    }
}
