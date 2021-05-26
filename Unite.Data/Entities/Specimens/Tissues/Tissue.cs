using System;
using Unite.Data.Entities.Specimens.Tissues.Enums;

namespace Unite.Data.Entities.Specimens.Tissues
{
    public class Tissue
    {
        public int SpecimenId { get; set; }
        public string ReferenceId { get; set; }

        public int? SourceId { get; set; }
        public TissueType? TypeId { get; set; }
        public TumourType? TumourTypeId { get; set; }
        public DateTime? ExtractionDate { get; set; }

        public virtual TissueSource Source { get; set; }
    }
}
