using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Specimens;

public record TumorClassification
{
    [Column("id")]
    public int Id { get; set; }
    [Column("specimen_id")]
    public int SpecimenId { get; set; }

    [Column("superfamily_id")]
    public int? SuperfamilyId { get; set; }
    [Column("superfamily_score")]
    public double? SuperfamilyScore { get; set; }
    [Column("family_id")]
    public int? FamilyId { get; set; }
    [Column("family_score")]
    public double? FamilyScore { get; set; }
    [Column("class_id")]
    public int? ClassId { get; set; }
    [Column("class_score")]
    public double? ClassScore { get; set; }
    [Column("subclass_id")]
    public int? SubclassId { get; set; }
    [Column("subclass_score")]
    public double? SubclassScore { get; set; }


    public virtual Specimen Specimen { get; set; }

    public virtual TumorSuperfamily Superfamily { get; set; }
    public virtual TumorFamily Family { get; set; }
    public virtual TumorClass Class { get; set; }
    public virtual TumorSubclass Subclass { get; set; }
}
