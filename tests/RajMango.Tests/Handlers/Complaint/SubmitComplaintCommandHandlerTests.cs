using FluentAssertions;
using Moq;
using RajMango.Application.Features.Complaint.Commands;
using RajMango.Application.Interfaces;
using RajMango.Domain.Entities;
using RajMango.Shared.Enums;
using RajMango.Tests.Helpers;
using Xunit;

namespace RajMango.Tests.Handlers.Complaint
{
    public class SubmitComplaintCommandHandlerTests
    {
        private readonly MockCurrentUserService _userService;
        private readonly Mock<IRealtimeService> _realtime;

        public SubmitComplaintCommandHandlerTests()
        {
            _userService = new MockCurrentUserService { UserId = 1 };

            _realtime = new Mock<IRealtimeService>();
            _realtime.Setup(x => x.SendToAdminsAsync(It.IsAny<string>(), It.IsAny<object>(), It.IsAny<CancellationToken>()))
                     .Returns(Task.CompletedTask);
        }

        [Fact]
        public async Task Handle_OrderNotFound_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var handler = new SubmitComplaintCommandHandler(db, _userService, _realtime.Object);
            var command = new SubmitComplaintCommand { OrderId = 999, Category = ComplaintCategory.LateDelivery, Description = "Late." };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeFalse();
            result.Messages.Should().Contain(m => m.Contains("not found"));
        }

        [Fact]
        public async Task Handle_ValidOrder_CreatesComplaintAndNotifiesAdmins()
        {
            using var db = TestDbContextFactory.Create();
            var order = SeedOrder(db, userId: 1);
            var handler = new SubmitComplaintCommandHandler(db, _userService, _realtime.Object);
            var command = new SubmitComplaintCommand
            {
                OrderId = order.Id,
                Category = ComplaintCategory.DamagedItem,
                Description = "Box was crushed.",
            };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeTrue();
            db.Get<RajMango.Domain.Entities.Complaint>().Count().Should().Be(1);
            _realtime.Verify(x => x.SendToAdminsAsync(
                It.IsAny<string>(), It.IsAny<object>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Handle_OrderBelongsToOtherUser_ReturnsFailure()
        {
            using var db = TestDbContextFactory.Create();
            var order = SeedOrder(db, userId: 99); // different user
            var handler = new SubmitComplaintCommandHandler(db, _userService, _realtime.Object);
            var command = new SubmitComplaintCommand { OrderId = order.Id, Category = ComplaintCategory.Other, Description = "Test." };

            var result = await handler.Handle(command, CancellationToken.None);

            result.Succeeded.Should().BeFalse();
        }

        private static RajMango.Domain.Entities.Order SeedOrder(RajMango.DataAccess.Contexts.AppDbContext db, int userId)
        {
            var order = new RajMango.Domain.Entities.Order
            {
                UserId = userId,
                OrderNumber = "TEST001",
                TotalAmount = 500,
                DueAmount = 0,
                PaidAmount = 500,
                CreatedBy = userId,
            };
            db.Get<RajMango.Domain.Entities.Order>().Add(order);
            db.SaveChanges();
            return order;
        }
    }
}
