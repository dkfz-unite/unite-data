using System.Collections.Generic;
using Unite.Data.Entities.Mutations.Enums;

namespace Unite.Data.Entities.Mutations
{
    public class Gene
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Synonym { get; set; }
        public string Name { get; set; }
        public Chromosome? ChromosomeId { get; set; }
        public int? Start { get; set; }
        public int? End { get; set; }
        public bool? Strand { get; set; }

        public virtual GeneInfo GeneInfo { get; set; }

        public virtual ICollection<Transcript> Transcripts { get; set; }
    }
}
