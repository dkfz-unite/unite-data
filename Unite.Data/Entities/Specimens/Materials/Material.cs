using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Specimens.Materials.Enums;

namespace Unite.Data.Entities.Specimens.Materials;

public record Material
{
    [Column("specimen_id")]
    public int SpecimenId { get; set; }

    [Column("source_id")]
    public int? SourceId { get; set; }
    [Column("fixation_type_id")]
    public FixationType? FixationTypeId { get; set; }


    public virtual Specimen Specimen { get; set; }
    public virtual MaterialSource Source { get; set; }
}
