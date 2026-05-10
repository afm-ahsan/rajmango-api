using RajMango.Shared.Enums;

namespace RajMango.Application.DTOs
{
    public class MangoTypeDto : FullAuditedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string Region { get; set; }
        public string AverageWeight { get; set; }
        public MangoGrade MangoGrade { get; set; }
        public SweetnessLevel SweetnessLevel { get; set; }
        public int Sequence { get; set; } = 0;
    }
}
