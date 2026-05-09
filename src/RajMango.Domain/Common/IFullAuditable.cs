namespace RajMango.Domain.Common
{
    public interface IFullAuditable
    {
        DateTime CreatedAt { get; set; }
        int CreatedBy { get; set; }

        DateTime? UpdatedAt { get; set; }
        int UpdatedBy { get; set; }

        DateTime? DeletedAt { get; set; }
        int DeletedBy { get; set; }

        bool IsDeleted { get; set; }
    }
}
