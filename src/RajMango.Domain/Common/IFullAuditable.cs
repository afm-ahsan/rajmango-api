namespace RajMango.Domain.Common
{
    public interface IFullAuditable : ISoftDelete
    {
        DateTime CreatedAt { get; set; }
        int CreatedBy { get; set; }

        DateTime? UpdatedAt { get; set; }
        int UpdatedBy { get; set; }

        DateTime? DeletedAt { get; set; }
        int DeletedBy { get; set; }
    }
}
