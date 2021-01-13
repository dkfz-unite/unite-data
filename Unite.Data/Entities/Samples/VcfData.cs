namespace Unite.Data.Entities.Samples
{
    public class VcfData
    {
        public int SampleId { get; set; }
        public int MutationId { get; set; }

        public string Quality { get; set; }
        public string Filter { get; set; }
        public string Info { get; set; }
        public string SampleInfoFormat { get; set; }
        public string SampleInfo { get; set; }
    }
}
