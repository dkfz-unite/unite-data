using Unite.Data.Entities.Donors;

namespace Unite.Data.Entities
{
    public class WorkPackageDonor
    {
        public int WorkPackageId { get; set; }
        public string DonorId { get; set; }

        public virtual WorkPackage WorkPackage { get; set; }
        public virtual Donor Donor { get; set; }
    }
}
