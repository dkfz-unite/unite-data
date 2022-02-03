using System;

namespace Unite.Data.Entities.Donors.Clinical
{
    public class Treatment
    {
        public int Id { get; set; }

        public int DonorId { get; set; }
        public int TherapyId { get; set; }

        public string Details { get; set; }

        public DateTime? StartDate { get; set; }
        public int? StartDay { get; set; }

        public DateTime? EndDate { get; set; }
        public int? EndDay { get; set; }

        public bool? ProgressionStatus { get; set; }
        public DateTime? ProgressionStatusChangeDate { get; set; }
        public int? ProgressionStatusChangeDay { get; set; }

        public string Results { get; set; }


        public virtual Therapy Therapy { get; set; }
    }
}
