using System.Collections.Generic;
using Unite.Data.Entities.Clinical;
using Unite.Data.Entities.Molecular;
using Unite.Data.Entities.Mutations;
using Unite.Data.Entities.Samples;

namespace Unite.Data.Entities.Donors
{
    public class Donor
    {
        public int Id { get; set; }

        public bool? MtaProtected { get; set; }

        public virtual ICollection<Pseudonym> Pseudonyms { get; set; }

        public virtual ClinicalData ClinicalData { get; set; }
        public virtual MolecularData MolecularData { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }

        public virtual ICollection<WorkPackageDonor> DonorWorkPackages { get; set; }
        public virtual ICollection<StudyDonor> DonorStudies { get; set; }

        public virtual ICollection<Sample> Samples { get; set; }

        public virtual ICollection<Analysis> Analyses { get; set; }
    }
}
