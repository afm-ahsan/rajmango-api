namespace RajMango.Domain.Common
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
