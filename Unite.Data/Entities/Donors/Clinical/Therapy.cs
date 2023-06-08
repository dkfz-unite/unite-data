namespace Unite.Data.Entities.Donors.Clinical;

public record Therapy
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
}
