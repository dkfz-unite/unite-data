using System;
using System.Collections.Generic;
using Unite.Data.Entities.Images.Enums;

namespace Unite.Data.Entities.Images
{
    public class Analysis
    {
        public int Id { get; set; }
        public string ReferenceId { get; set; }

        public AnalysisType? TypeId { get; set; }
        public DateTime? ProcessingDate { get; set; }
        public int? ProcessingDay { get; set; }


        public virtual AnalysedImage AnalysedImage { get; set; }

        public virtual ICollection<AnalysisParameterOccurrence> ParameterOccurrences { get; set; }
    }
}
