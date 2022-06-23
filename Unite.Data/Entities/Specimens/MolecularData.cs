using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Entities.Specimens;

public class MolecularData
{
    public int? SpecimenId { get; set; }

    public MgmtStatus? MgmtStatusId { get; set; }
    public IdhStatus? IdhStatusId { get; set; }
    public IdhMutation? IdhMutationId { get; set; }
    public GeneExpressionSubtype? GeneExpressionSubtypeId { get; set; }
    public MethylationSubtype? MethylationSubtypeId { get; set; }
    public bool? GcimpMethylation { get; set; }
}
