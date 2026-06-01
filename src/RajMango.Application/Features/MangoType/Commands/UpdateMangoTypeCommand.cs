using MediatR;
using RajMango.Shared;
using RajMango.Shared.Enums;

namespace RajMango.Application.Features.Commands
{
    public record UpdateMangoTypeCommand : IRequest<Result<int>>
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
        public int? CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
