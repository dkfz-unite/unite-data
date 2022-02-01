using System.Collections.Generic;

namespace Unite.Data.Entities.Images
{
    public class AnalysisParameter
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public virtual ICollection<AnalysisParameterOccurrence> ParameterOccurrences { get; set; }
    }
}
