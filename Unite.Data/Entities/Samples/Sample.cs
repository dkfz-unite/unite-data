using System.Collections.Generic;
using Unite.Data.Entities.Clinical;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Molecular;
using Unite.Data.Entities.Samples.Cells;
using Unite.Data.Entities.Samples.Tissues;

namespace Unite.Data.Entities.Samples
{
    public class Sample
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }

        public int? DonorId { get; set; }
        public int? TissueId { get; set; }
        public int? CellLineId { get; set; }

        public virtual Sample Parent { get; set; }
        public virtual ICollection<Sample> Children { get; set; }

        public virtual Donor Donor { get; set; }
        public virtual Tissue Tissue { get; set; }
        public virtual CellLine CellLine { get; set; }

        public virtual ClinicalData ClinicalData { get; set; }
        public virtual MolecularData MolecularData { get; set; }
        public virtual ICollection<Treatment> Treatments { get; set; }
    }
}
