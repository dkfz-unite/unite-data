using System;
using System.Collections.Generic;
using Unite.Data.Entities.Cells;
using Unite.Data.Entities.Samples;

namespace Unite.Data.Entities.Donors
{
    public class Donor
    {
        public string Id { get; set; }
        public string Diagnosis { get; set; }
        public DateTime? DiagnosisDate { get; set; }
        public int? PrimarySiteId { get; set; }
        public string Origin { get; set; }
        public bool? MtaProtected { get; set; }

        public virtual PrimarySite PrimarySite { get; set; }
        public virtual ClinicalData ClinicalData { get; set; }

        public virtual ICollection<Treatment> Treatments { get; set; }
        public virtual ICollection<CellLine> CellLines { get; set; }
        public virtual ICollection<Sample> Samples { get; set; }
        public virtual ICollection<WorkPackageDonor> DonorWorkPackages { get; set; }
        public virtual ICollection<StudyDonor> DonorStudies { get; set; }
    }
}
