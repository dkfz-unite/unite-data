using System;

namespace Unite.Data.Entities.Clinical
{
    public class Treatment
    {
        public int TherapyId { get; set; }
        public int? DonorId { get; set; }
        public int? SampleId { get; set; }

        public string Details { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Progression { get; set; }
        public DateTime? ProgressionDate { get; set; }
        public string Results { get; set; }

        public virtual Therapy Therapy { get; set; }
    }
}
