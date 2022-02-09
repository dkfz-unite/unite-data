using System.Collections.Generic;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Entities.Genome.Mutations
{
    public class Sample
    {
        public int Id { get; set; }
        public string ReferenceId { get; set; }
        public int SpecimenId { get; set; }
        

        public virtual Specimen Specimen { get; set; }
        public virtual ICollection<AnalysedSample> SampleAnalises { get; set; }
    }
}
