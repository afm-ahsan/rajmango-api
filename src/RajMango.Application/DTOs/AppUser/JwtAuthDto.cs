namespace RajMango.Application.DTOs
{
    public class JwtAuthDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string AuthToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime IssuedAt { get; set; }

        public DateTime ExpiresIn { get; set; }

        public bool IsRevoked { get; set; }

        public DateTime? RevokedAt { get; set; }

        public int RevokedBy { get; set; }

        public string IpAddress { get; set; }

        public string DeviceInfo { get; set; }
    }
}
