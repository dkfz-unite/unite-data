using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Images.Analysis.Radiomics;

public record FeatureEntry : Base.SampleEntry<Sample, Feature>
{
    [Column("value")]
    public string Value { get; set; }
}
