namespace Unite.Data.Entities.Base;

public abstract record Analysis
{
    public int Id { get; set; }

    public DateOnly? Date { get; set; }
    public int? Day { get; set; }
    public Dictionary<string, string> Parameters { get; set; }   
}

public abstract record Analysis<TType> : Analysis
    where TType : struct, Enum
{
    public TType TypeId { get; set; }
}
