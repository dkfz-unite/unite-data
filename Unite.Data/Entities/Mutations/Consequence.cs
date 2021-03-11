using Unite.Data.Entities.Mutations.Enums;

namespace Unite.Data.Entities.Mutations
{
    public class Consequence
    {
        public ConsequenceType TypeId { get; set; }
        public ConsequenceImpact ImpactId { get; set; }
        public int Severity { get; set; }
    }
}
