using System;

namespace Unite.Data.Entities.Donors
{
    public class Treatment
    {
        public string DonorId { get; set; }
        public int TherapyId { get; set; }
        public string Details { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Results { get; set; }

        public virtual Donor Donor { get; set; }
        public virtual Therapy Therapy { get; set; }
    }
}
