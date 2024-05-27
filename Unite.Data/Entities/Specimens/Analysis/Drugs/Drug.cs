namespace Unite.Data.Entities.Specimens.Analysis.Drugs;

public record Drug : Base.Entity
{
    public string Name { get; set; }
    public string Description { get; set; }
}
