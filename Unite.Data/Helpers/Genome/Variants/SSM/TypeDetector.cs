using Unite.Data.Entities.Genome.Analysis.Dna.Ssm.Enums;

namespace Unite.Data.Helpers.Genome.Variants.Ssm;

public static class TypeDetector
{
    /// <summary>
    /// Indentifies mutation type based on reference and alternate base.
    /// </summary>
    /// <param name="referenceBase">Reference base</param>
    /// <param name="alternateBase">Alternate base</param>
    /// <returns>Mutation type (SNV, INS, DEL or MNV).</returns>
    public static SsmType Detect(string referenceBase, string alternateBase)
    {
        if (!string.IsNullOrWhiteSpace(referenceBase) && !string.IsNullOrWhiteSpace(alternateBase))
        {
            if (referenceBase.Length == 1 && alternateBase.Length == 1)
            {
                return SsmType.SNV;
            }
            else if (referenceBase.Length == 1 && alternateBase.Length > 1)
            {
                return SsmType.INS;
            }
            else if (referenceBase.Length > 1 && alternateBase.Length == 1)
            {
                return SsmType.DEL;
            }
            else if (referenceBase.Length > 1 && alternateBase.Length > 1)
            {
                return SsmType.MNV;
            }
        }
        else if (string.IsNullOrWhiteSpace(referenceBase) && !string.IsNullOrWhiteSpace(alternateBase))
        {
            return SsmType.INS;
        }
        else if (!string.IsNullOrWhiteSpace(referenceBase) && string.IsNullOrWhiteSpace(alternateBase))
        {
            return SsmType.DEL;
        }

        throw new NotImplementedException($"Can't detect mutation type: REF - '{referenceBase}', ALT - '{alternateBase}'");
    }
}
