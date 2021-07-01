using Unite.Data.Entities.Mutations.Enums;
using Unite.Data.Extensions;

namespace Unite.Data.Utilities.Mutations
{
    public static class HGVsCodeGenerator
    {
        /// <summary>
        /// Generates HGVs mutation code.
        /// </summary>
        /// <param name="chr">Chromosome</param>
        /// <param name="seq">Sequence type</param>
        /// <param name="pos">Position</param>
        /// <param name="refBase">Reference base</param>
        /// <param name="altBase">Alternate base</param>
        /// <returns>HGVs mutation code.</returns>
        public static string Generate(Chromosome chr, SequenceType seq, string pos, string refBase, string altBase)
        {
            var chromosome = $"chr{chr.ToDefinitionString()}";
            var sequenceType = seq.ToDefinitionString();
            var position = pos;
            var referenceBase = refBase ?? "-";
            var alternateBase = altBase ?? "-";

            return $"{chromosome}:{sequenceType}.{position}{referenceBase}>{alternateBase}";
        }

        /// <summary>
        /// Generates HGVs mutation code.
        /// </summary>
        /// <param name="chr">Chromosome</param>
        /// <param name="seq">Sequence type</param>
        /// <param name="start">Mutation start</param>
        /// <param name="refBase">Reference base</param>
        /// <param name="altBase">Alternate base</param>
        /// <returns>HGVs mutation code.</returns>
        public static string Generate(Chromosome chr, SequenceType seq, int start, string refBase, string altBase)
        {
            var chromosome = $"chr{chr.ToDefinitionString()}";
            var sequenceType = seq.ToDefinitionString();
            var position = $"{start}";
            var referenceBase = refBase ?? "-";
            var alternateBase = altBase ?? "-";

            return $"{chromosome}:{sequenceType}.{position}{referenceBase}>{alternateBase}";
        }
    }
}
