using Unite.Data.Entities.Molecular.Enums;

namespace Unite.Data.Entities.Molecular
{
    public class MolecularData
    {
        public int? SpecimenId { get; set; }

        public GeneExpressionSubtype? GeneExpressionSubtypeId { get; set; }
        public IDHStatus? IdhStatusId { get; set; }
        public IDHMutation? IdhMutationId { get; set; }
        public MethylationStatus? MethylationStatusId { get; set; }
        public MethylationType? MethylationTypeId { get; set; }
        public bool? GcimpMethylation { get; set; }
    }
}
