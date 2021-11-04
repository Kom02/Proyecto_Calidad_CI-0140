using EmprendeUCR_WebApplication.Domain.NotificationContext;
using FluentAssertions;
using FluentAssertions.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

/*
	Juan Valverde - B47200, Silvia Aguilar - B80129, Herson Mena - B84808
	Rotation time: 30 minutes
	User Story: F12L-2405- NRS -01 Order's notifications, 
                F12L-2405- NRS -04 Acceptance / Reject Request Notification, 
                F12L-2405- NRS -08 Order's notifications update listener
	Tasks: PIIB12021-413 Unit testing, PIIB12021-414 Integration Testing
*/

namespace EmprendeUCR.UnitTests.Domain.NotificationContext
{
    public class UserNotificationTest
    {
        public int num = 2;
        public async Task quantityEvent2(object sender, NotificationChangeEventArgs e)
        {
            num = 3;
        }

        [Fact]
        public async Task ListenChangedQuantity()
        {
            // arrange
            var subject = new UserNotification("juan@test.com", 1);
            subject.OnNotificationChangeds += quantityEvent2;
            subject.notificationQuantity = 0;
            using (var monitoredSubject = subject.Monitor())
            {
                
                this.num.Should().Be(2);
                subject.QuantityEvent(this, new NotificationChangeEventArgs(true));
                this.num.Should().Be(3);
                subject.notificationQuantity.Should().Be(1);
                this.num.Should().Be(3);
            }
            
        }

        [Fact]
        public void NotificationListOrderByDate()
        {
            // arrange
            var subject = new UserNotification("juan@test.com", 1);
            var notification2 = new Notification();
            notification2.date = DateTime.Now;
            var notification1 = new Notification();
            notification1.date = DateTime.Now;
            List<Notification> notifications = new List<Notification>();
            notifications.Add(notification2);
            notifications.Add(notification1);
            subject.setNewNotifications(notifications);
            subject.Notifications[0].date.Should().Be(notification2.date);
            subject.Notifications[1].date.Should().Be(notification1.date);
            // act
            subject.orderNotifications();
            // assert
            subject.Notifications[0].date.Should().Be(notification1.date);
            subject.Notifications[1].date.Should().Be(notification2.date);

        }



    }
}