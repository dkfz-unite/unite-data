using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Entities.Specimens;

public record MolecularData
{
    [Column("specimen_id")]
    public int? SpecimenId { get; set; }

    [Column("mgmt_status_id")]
    public MgmtStatus? MgmtStatusId { get; set; }
    [Column("idh_status_id")]
    public IdhStatus? IdhStatusId { get; set; }
    [Column("idh_mutation_id")]
    public IdhMutation? IdhMutationId { get; set; }
    [Column("gene_expression_subtype_id")]
    public GeneExpressionSubtype? GeneExpressionSubtypeId { get; set; }
    [Column("methylation_subtype_id")]
    public MethylationSubtype? MethylationSubtypeId { get; set; }
    [Column("gcimp_methylation")]
    public bool? GcimpMethylation { get; set; }
    [Column("gene_knockouts")]
    public string[] GeneKnockouts { get; set; }


    public virtual Specimen Specimen { get; set; }
}
