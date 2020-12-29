using System.Collections.Generic;
using Unite.Data.Entities.Extensions;
using Unite.Data.Entities.Mutations.Enums;
using Unite.Data.Entities.Samples;

namespace Unite.Data.Entities.Mutations
{
    public class Mutation
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? GeneId { get; set; }
        public Chromosome? ChromosomeId { get; set; }
        public int? ContigId { get; set; }
        public SequenceType SequenceTypeId { get; set; }
        public int Position { get; set; }
        public MutationType TypeId { get; set; }
        public string ReferenceAllele { get; set; }
        public string AlternateAllele { get; set; }


        public virtual Gene Gene { get; set; }
        public virtual Contig Contig { get; set; }

        public virtual ICollection<SampleMutation> MutationSamples { get; set; }


        public string GetCode()
        {
            var strand = ChromosomeId != null
                       ? $"chr{ChromosomeId.ToDefinitionString()}"
                       : Contig.Value;

            var sequenceType = SequenceTypeId.ToDefinitionString();

            var position = Position.ToString();

            var referenceAllele = !string.IsNullOrEmpty(ReferenceAllele)
                                ? ReferenceAllele
                                : "-";

            var alternateAllele = !string.IsNullOrEmpty(AlternateAllele)
                                ? AlternateAllele
                                : "-";

            return $"{strand}:{sequenceType}.{position}{referenceAllele}>{alternateAllele}";
        }
    }
}
