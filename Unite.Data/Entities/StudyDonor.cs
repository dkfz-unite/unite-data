using Unite.Data.Entities.Donors;

namespace Unite.Data.Entities
{
    public class StudyDonor
    {
        public int StudyId { get; set; }
        public string DonorId { get; set; }

        public virtual Study Study { get; set; }
        public virtual Donor Donor { get; set; }
    }
}
