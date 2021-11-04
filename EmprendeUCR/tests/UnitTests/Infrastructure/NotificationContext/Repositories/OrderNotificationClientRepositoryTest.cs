using EmprendeUCR_WebApplication.Domain.NotificationContext;
using EmprendeUCR_WebApplication.Infrastructure.NotificationContext.Repositories.ClientRepositories;
using FluentAssertions;
using System.Threading.Tasks;
using TableDependency.SqlClient.Base.EventArgs;
using Xunit;

namespace EmprendeUCR.UnitTests.Infrastructure.NotificationContext.Repositories
{
    public class OrderNotificationClientRepositoryTest
    {
        public int num = 2;
        public async Task quantityEvent2(object sender, NotificationChangeEventArgs e)
        {
            num += 1;
        }

        [Fact]
        public void Unsubscription()
        {
            // arrange
            var subject = new UserNotification("juan@test.com", 1);
            var repository = new OrderNotificationClientRepository();
            repository.EventsSubscriptions(subject);
            subject.OnNotificationChangeds += quantityEvent2;

            // act
            repository.InvokeEvent(false);
            repository.Unsubscription(subject);
            repository.InvokeEvent(false);

            // assert
            this.num.Should().Be(3);
        }
    }
}
