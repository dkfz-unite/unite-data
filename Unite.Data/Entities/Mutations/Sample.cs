using System;
using System.Collections.Generic;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Mutations.Enums;

namespace Unite.Data.Entities.Mutations
{
    public class Sample
    {
        public int Id { get; set; }
        public string DonorId { get; set; }
        //public int? CellLineId { get; set; }
        //public int? XenograftId { get; set; }
        public string Name { get; set; }
        public SampleType? TypeId { get; set; }
        public SampleSubtype? SubtypeId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Donor Donor { get; set; }
        //public virtual CellLine CellLine { get; set; }
        //public virtual Xenograft Xenograft { get; set; }

        public virtual ICollection<AnalysedSample> SampleAnalises { get; set; }
    }
}