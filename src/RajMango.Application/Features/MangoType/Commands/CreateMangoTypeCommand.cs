using MediatR;
using RajMango.Shared;

namespace RajMango.Application.Features.Commands
{
    public record CreateMangoTypeCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PricePerKg { get; set; }
        public string ImagePath { get; set; }
        public bool IsAvailable { get; set; }
        public int Sequence { get; set; } = 0;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
