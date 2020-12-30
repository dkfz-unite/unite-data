using System;
using System.Collections.Generic;
using Unite.Data.Entities.Cells;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Samples.Enums;

namespace Unite.Data.Entities.Samples
{
    public class Sample
    {
        public int Id { get; set; }
        public string DonorId { get; set; }
        public int? CellLineId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public SampleType? TypeId { get; set; }
        public SampleSubtype? SubtypeId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Donor Donor { get; set; }
        public virtual CellLine CellLine { get; set; }
        public virtual ICollection<SampleMutation> SampleMutations { get; set; }
    }
}