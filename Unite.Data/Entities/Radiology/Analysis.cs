using System.Collections.Generic;
using Unite.Data.Entities.Radiology.Enums;

namespace Unite.Data.Entities.Radiology
{
    public class Analysis
    {
        public int Id { get; set; }
        public string ReferenceId { get; set; }

        public AnalysisType? TypeId { get; set; }
        public int? ProcessingDay { get; set; }


        public virtual AnalysedImage AnalysedImage { get; set; }

        public virtual ICollection<AnalysisParameterOccurrence> ParameterOccurrences { get; set; }
    }
}
