namespace RajMango.Application.DTOs
{
    public class MangoTypeDto : FullAuditedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePerKg { get; set; }
        public string ImagePath { get; set; }
        public bool IsAvailable { get; set; }
        public int Sequence { get; set; } = 0;
    }
}
