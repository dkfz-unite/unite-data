namespace Unite.Data.Entities.Base;

public abstract record Analysis<TType>
    where TType : struct, Enum
{
    public int Id { get; set; }
    public string ReferenceId { get; set; }

    public TType? TypeId { get; set; }
    public DateOnly? Date { get; set; }
    public int? Day { get; set; }
    public Dictionary<string, string> Parameters { get; set; }
}
