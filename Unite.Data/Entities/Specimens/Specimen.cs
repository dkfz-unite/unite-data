using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Specimens.Analysis;
using Unite.Data.Entities.Specimens.Cells;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Entities.Specimens.Organoids;
using Unite.Data.Entities.Specimens.Tissues;
using Unite.Data.Entities.Specimens.Xenografts;

namespace Unite.Data.Entities.Specimens;

/// <summary>
/// Specimen. Specimen is a sample and can be analysed.
/// Each specimen can have a parent specimen.
/// Each specimen belongs to a donor. 
/// Specimen is an entity of specific specimen type: Tissue, CellLine, Organoid or Xenograft.
/// </summary> 
public record Specimen : Base.Sample<SpecimenType>
{
    public int? ParentId { get; set; }
    public int DonorId { get; set; }
    
    public virtual Donor Donor { get; set; }
    public virtual Tissue Tissue { get; set; }
    public virtual CellLine CellLine { get; set; }
    public virtual Organoid Organoid { get; set; }
    public virtual Xenograft Xenograft { get; set; }
    public virtual MolecularData MolecularData { get; set; }

    public virtual Specimen Parent { get; set; }
    public virtual ICollection<Specimen> Children { get; set; }

    public virtual ICollection<DrugScreening> DrugScreenings { get; set; }
    public virtual ICollection<AnalysedSample> SampleAnalyses { get; set; }
}
