namespace RajMango.Domain.Common
{
    public interface IHasId<out TId>
    {
        TId Id { get; }
    }
}
