using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Omics;

public record Protein
{
    [Column("id")]
    public int Id { get; set; }
    [Column("stable_id")]
    public string StableId { get; set; }

    [Column("transcript_id")]
    public int? TranscriptId { get; set; }

    [Column("start")]
    public int? Start { get; set; }
    [Column("end")]
    public int? End { get; set; }
    [Column("length")]
    public int? Length { get; set; }
    [Column("is_canonical")]
    public bool? IsCanonical { get; set; }

    public virtual Transcript Transcript { get; set; }
}
