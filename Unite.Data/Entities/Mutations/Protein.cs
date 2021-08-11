using System.Collections.Generic;

namespace Unite.Data.Entities.Mutations
{
    public class Protein
    {
        public int Id { get; set; }

        public string Symbol { get; set; }
        public int? Start { get; set; }
        public int? End { get; set; }
        public int? Length { get; set; }

        public ProteinInfo Info { get; set; }

        public virtual ICollection<ProteinDomain> ProteinDomains { get; set; }
    }
}
