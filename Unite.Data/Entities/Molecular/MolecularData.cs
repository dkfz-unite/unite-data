using Unite.Data.Entities.Molecular.Enums;

namespace Unite.Data.Entities.Molecular
{
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
}
