using System.Collections.Generic;
using Unite.Data.Entities.Images.Features.Enums;

namespace Unite.Data.Entities.Images.Features
{
    public class Analysis
    {
        public int Id { get; set; }
        public string ReferenceId { get; set; }

        public AnalysisType? TypeId { get; set; }
        public int? FileId { get; set; }


        public virtual File File { get; set; }
        public virtual AnalysedImage Sample { get; set; }
        public virtual ICollection<AnalysisParameterOccurrence> ParameterOccurrences { get; set; }
    }
}
