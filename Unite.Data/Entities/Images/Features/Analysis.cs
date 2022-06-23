using System;
using System.Collections.Generic;
using Unite.Data.Entities.Images.Features.Enums;

namespace Unite.Data.Entities.Images.Features;

public class Analysis
{
    public int Id { get; set; }
    public string ReferenceId { get; set; }

    public AnalysisType? TypeId { get; set; }
    public DateTime? Date { get; set; }


    public virtual AnalysedImage Sample { get; set; }
    public virtual ICollection<AnalysisParameterOccurrence> ParameterOccurrences { get; set; }
}
