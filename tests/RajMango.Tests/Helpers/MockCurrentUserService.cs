using RajMango.Application.Interfaces;

namespace RajMango.Tests.Helpers
{
    public class MockCurrentUserService : ICurrentUserService
    {
        public int UserId { get; set; } = 1;
        public string UserName { get; set; } = "test-user";
        public bool IsAuthenticated { get; set; } = true;
        public bool IsAdmin { get; set; } = false;
    }
}
