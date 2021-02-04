using Unite.Data.Entities.Epigenetics.Enums;

namespace Unite.Data.Entities.Epigenetics
{
    public class EpigeneticsData
    {
        public string DonorId { get; set; }
        public GeneExpressionSubtype? GeneExpressionSubtypeId { get; set; }
        public IDHStatus? IdhStatusId { get; set; }
        public IDHMutation? IdhMutationId { get; set; }
        public MethylationStatus? MethylationStatusId { get; set; }
        public MethylationSubtype? MethylationSubtypeId { get; set; }
        public bool? GcimpMethylation { get; set; }
    }
}
