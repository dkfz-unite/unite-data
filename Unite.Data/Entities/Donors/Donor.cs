using System.Collections.Generic;
using Unite.Data.Entities.Donors.Clinical;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Entities.Donors
{
    public class Donor
    {
        public int Id { get; set; }
        public string ReferenceId { get; set; }

        public bool? MtaProtected { get; set; }

        public virtual ClinicalData ClinicalData { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
        public virtual ICollection<Specimen> Specimens { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<WorkPackageDonor> DonorWorkPackages { get; set; }
        public virtual ICollection<StudyDonor> DonorStudies { get; set; }
    }
}
