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
        public int? DurationDays { get; set; }

        public string Results { get; set; }


        public virtual Therapy Therapy { get; set; }
    }
}
