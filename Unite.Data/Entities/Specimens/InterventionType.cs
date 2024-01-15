namespace Unite.Data.Entities.Specimens;

public record InterventionType
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
}
