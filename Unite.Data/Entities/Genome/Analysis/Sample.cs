using Unite.Data.Entities.Specimens;

namespace Unite.Data.Entities.Genome.Analysis;

public record Sample
{
    public int Id { get; set; }
    public string ReferenceId { get; set; }
    public int SpecimenId { get; set; }

    public virtual Specimen Specimen { get; set; }
}
