namespace Unite.Data.Entities.Base;

/// <summary>
/// Entity which can appear in a sample during or without the analysis.
/// </summary>
/// <typeparam name="T">Type of the entity's identifier.</typeparam>
public abstract record Entity<T>
{
    public T Id { get; set; }
}
