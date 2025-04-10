using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Images.Analysis.Radiomics;

public record Feature : Base.Entity
{
    [Column("name")]
    public string Name { get; set; }

    public ICollection<FeatureEntry> Entries { get; set; }
}
