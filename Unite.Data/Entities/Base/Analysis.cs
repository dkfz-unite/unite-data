namespace Unite.Data.Entities.Base;

/// <summary>
/// Analysis and it's parameters.
/// </summary>
public abstract record Analysis
{
    public int Id { get; set; }
    public string ReferenceId { get; set; }

    public virtual DateOnly? Date { get; set; }
    public virtual int? Day { get; set; }
    public virtual Dictionary<string, string> Parameters { get; set; }
}

/// <summary>
/// Typed analysis and it's parameters.
/// </summary>
/// <typeparam name="TType">Analysis type.</typeparam>
public record Analysis<TType> : Analysis where TType : struct, Enum
{
    public TType? TypeId { get; set; }
}
