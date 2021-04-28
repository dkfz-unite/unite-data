using System;
using Unite.Data.Entities.Samples.Tissues.Enums;

namespace Unite.Data.Entities.Samples.Tissues
{
    public class Tissue
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public TissueType? TypeId { get; set; }
        public DateTime? ExtractionDate { get; set; }

        public virtual Sample Sample { get; set; }
    }
}
