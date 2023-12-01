namespace Unite.Data.Context.Mappers.Entities;

internal record EnumEntity<T> where T : Enum
{
    public T Id { get; set; }
    public string Value { get; set; }
    public string Name { get; set; }
}
