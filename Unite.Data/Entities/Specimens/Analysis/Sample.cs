using Unite.Data.Entities.Specimens.Analysis.Drugs;

namespace Unite.Data.Entities.Specimens.Analysis;

public record Sample : Base.Sample<Specimen, Analysis>
{
    public virtual ICollection<DrugScreening> DrugScreenings { get; set; }
}
