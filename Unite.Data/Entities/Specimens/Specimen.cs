using Unite.Data.Entities.Genome.Analysis;
using Unite.Data.Entities.Specimens.Cells;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Entities.Specimens.Organoids;
using Unite.Data.Entities.Specimens.Tissues;
using Unite.Data.Entities.Specimens.Xenografts;

namespace Unite.Data.Entities.Specimens;

public record Specimen : Base.Sample<SpecimenType>
{
    public int? ParentId { get; set; }

    public virtual Specimen Parent { get; set; }
    public virtual ICollection<Specimen> Children { get; set; }

    public virtual Tissue Tissue { get; set; }
    public virtual CellLine CellLine { get; set; }
    public virtual Organoid Organoid { get; set; }
    public virtual Xenograft Xenograft { get; set; }
    public virtual MolecularData MolecularData { get; set; }

    public virtual ICollection<DrugScreening> DrugScreenings { get; set; }
    public virtual ICollection<AnalysedSample> AnalysedSamples { get; set; }
    public virtual ICollection<AnalysedSample> MatchedSamples { get; set; }
}
