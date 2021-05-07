using Unite.Data.Entities.Mutations.Enums;

namespace Unite.Data.Entities.Mutations
{
    public class Transcript
    {
        public int Id { get; set; }

        public int? BiotypeId { get; set; }
        public string Symbol { get; set; }
        public Chromosome? ChromosomeId { get; set; }
        public int? Start { get; set; }
        public int? End { get; set; }
        public bool? Strand { get; set; }

        public virtual Biotype Biotype { get; set; }

        public virtual TranscriptInfo Info { get; set; }
    }
}
