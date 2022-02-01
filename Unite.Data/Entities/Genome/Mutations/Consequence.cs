using Unite.Data.Entities.Genome.Mutations.Enums;

namespace Unite.Data.Entities.Genome.Mutations
{
    public class Consequence
    {
        public ConsequenceType TypeId { get; set; }
        public ConsequenceImpact ImpactId { get; set; }
        public int Severity { get; set; }
    }
}
