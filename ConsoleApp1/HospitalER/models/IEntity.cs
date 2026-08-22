namespace HospitalER;

public interface IEntity<TKey>
{
    TKey Id { get; }
}
