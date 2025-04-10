using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Specimens.Materials.Enums;

namespace Unite.Data.Entities.Specimens.Materials;

public record Material
{
    [Column("specimen_id")]
    public int SpecimenId { get; set; }

    [Column("source_id")]
    public int? SourceId { get; set; }
    [Column("type_id")]
    public MaterialType? TypeId { get; set; }
    [Column("fixation_type_id")]
    public FixationType? FixationTypeId { get; set; }
    [Column("tumor_type_id")]
    public TumorType? TumorTypeId { get; set; }
    [Column("tumor_grade")]
    public byte? TumorGrade { get; set; }


    public virtual Specimen Specimen { get; set; }
    public virtual MaterialSource Source { get; set; }
}
