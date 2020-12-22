using System.Collections.Generic;
using Unite.Data.Entities.Extensions;
using Unite.Data.Entities.Mutations.Enums;
using Unite.Data.Entities.Samples;

namespace Unite.Data.Entities.Mutations
{
    public class Mutation
    {
        public int Id { get; set; }
        public string ReferenceId { get; set; }
        public int? GeneId { get; set; }
        public Chromosome? ChromosomeId { get; set; }
        public int? ContigId { get; set; }
        public SequenceType SequenceTypeId { get; set; }
        public int Position { get; set; }
        public MutationType TypeId { get; set; }
        public string ReferenceAllele { get; set; }
        public string AlternateAllele { get; set; }

        public string Code => GetCode();

        public virtual Gene Gene { get; set; }
        public virtual Contig Contig { get; set; }

        public virtual ICollection<SampleMutation> MutationSamples { get; set; }


        private string GetCode()
        {
            var chr = ChromosomeId != null
                    ? ChromosomeId.ToDefinitionString()
                    : Contig.Value;

            var seq = SequenceTypeId.ToDefinitionString();

            var pos = Position.ToString();

            var refA = !string.IsNullOrEmpty(ReferenceAllele)
                     ? ReferenceAllele
                     : "-";

            var altA = !string.IsNullOrEmpty(AlternateAllele)
                     ? AlternateAllele
                     : "-";

            return $"chr{chr}:{seq}.{pos}{refA}>{altA}";
        }
    }
}
