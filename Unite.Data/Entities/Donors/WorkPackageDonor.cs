namespace Unite.Data.Entities.Donors
{
    public class WorkPackageDonor
    {
        public int WorkPackageId { get; set; }
        public int DonorId { get; set; }

        public virtual WorkPackage WorkPackage { get; set; }
        public virtual Donor Donor { get; set; }
    }
}
