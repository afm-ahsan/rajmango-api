namespace RajMango.Domain.Common
{
    public interface ICreationAuditable
    {
        DateTime CreatedAt { get; set; }
        int CreatedBy { get; set; }
    }
}
