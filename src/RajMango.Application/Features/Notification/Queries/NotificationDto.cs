using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Notifications.Queries
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string OrderNumber { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public NotificationType NotificationType { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
