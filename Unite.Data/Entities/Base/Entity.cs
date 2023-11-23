namespace Unite.Data.Entities.Base;

public abstract record Entity<T>
    where T : struct
{
    public T Id { get; set; }
}
