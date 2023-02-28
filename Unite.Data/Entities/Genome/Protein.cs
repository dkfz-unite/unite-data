namespace Unite.Data.Entities.Genome;

public class Protein
{
    public int Id { get; set; }
    public string StableId { get; set; }

    public int? Start { get; set; }
    public int? End { get; set; }
    public int? Length { get; set; }
    public int? IsCanonical { get; set; }
}
