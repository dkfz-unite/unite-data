using Unite.Data.Entities.Genome.Abstractions;

namespace Unite.Data.Entities.Genome;

public record Protein : IStableEntry
{
    public int Id { get; set; }
    public string StableId { get; set; }

    public int? TranscriptId { get; set; }

    public int? Start { get; set; }
    public int? End { get; set; }
    public int? Length { get; set; }
    public bool? IsCanonical { get; set; }


    public virtual Transcript Transcript { get; set; }
}
