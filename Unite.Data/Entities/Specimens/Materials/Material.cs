using Unite.Data.Entities.Specimens.Materials.Enums;

namespace Unite.Data.Entities.Specimens.Materials;

public record Material
{
    public int SpecimenId { get; set; }

    public int? SourceId { get; set; }
    public MaterialType? TypeId { get; set; }
    public FixationType? FixationTypeId { get; set; }
    public TumorType? TumorTypeId { get; set; }
    public byte? TumorGrade { get; set; }


    public virtual Specimen Specimen { get; set; }
    public virtual MaterialSource Source { get; set; }
}
