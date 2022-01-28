using System.Collections.Generic;

namespace Unite.Data.Entities.Radiology
{
    public class AnalysisParameter
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public virtual ICollection<AnalysisParameterOccurrence> ParameterOccurrences { get; set; }
    }
}
