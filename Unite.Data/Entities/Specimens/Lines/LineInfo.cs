using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Specimens.Lines;

public record LineInfo
{
    [Column("specimen_id")]
    public int SpecimenId { get; set; }

    [Column("name")]
    public string Name { get; set; }
    [Column("depositor_name")]
    public string DepositorName { get; set; }
    [Column("depositor_establishment")]
    public string DepositorEstablishment { get; set; }
    [Column("establishment_date")]
    public DateOnly? EstablishmentDate { get; set; }

    [Column("pubmed_link")]
    public string PubmedLink { get; set; }
    [Column("atcc_link")]
    public string AtccLink { get; set; }
    [Column("expasy_link")]
    public string ExpasyLink { get; set; }
}
