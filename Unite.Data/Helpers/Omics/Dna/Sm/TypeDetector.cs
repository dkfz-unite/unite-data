using Unite.Data.Entities.Omics.Analysis.Dna.Sm.Enums;

namespace Unite.Data.Helpers.Omics.Dna.Sm;

public static class TypeDetector
{
    /// <summary>
    /// Indentifies mutation type based on reference and alternate base.
    /// </summary>
    /// <param name="referenceBase">Reference base</param>
    /// <param name="alternateBase">Alternate base</param>
    /// <returns>Mutation type (SNV, INS, DEL or MNV).</returns>
    public static SmType Detect(string referenceBase, string alternateBase)
    {
        if (!string.IsNullOrWhiteSpace(referenceBase) && !string.IsNullOrWhiteSpace(alternateBase))
        {
            if (referenceBase.Length == 1 && alternateBase.Length == 1)
            {
                return SmType.SNV;
            }
            else if (referenceBase.Length == 1 && alternateBase.Length > 1)
            {
                return SmType.INS;
            }
            else if (referenceBase.Length > 1 && alternateBase.Length == 1)
            {
                return SmType.DEL;
            }
            else if (referenceBase.Length > 1 && alternateBase.Length > 1)
            {
                return SmType.MNV;
            }
        }
        else if (string.IsNullOrWhiteSpace(referenceBase) && !string.IsNullOrWhiteSpace(alternateBase))
        {
            return SmType.INS;
        }
        else if (!string.IsNullOrWhiteSpace(referenceBase) && string.IsNullOrWhiteSpace(alternateBase))
        {
            return SmType.DEL;
        }

        throw new NotImplementedException($"Can't detect mutation type: REF - '{referenceBase}', ALT - '{alternateBase}'");
    }
}
