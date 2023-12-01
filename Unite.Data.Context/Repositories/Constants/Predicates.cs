using System.Linq.Expressions;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Entities.Specimens.Tissues.Enums;

using CNV = Unite.Data.Entities.Genome.Variants.CNV;

namespace Unite.Data.Context.Repositories.Constants;

public static class Predicates
{
    public readonly static Expression<Func<Specimen, bool>> IsImageRelatedSpecimen = specimen =>
    (
        specimen.ParentId == null &&
        specimen.TypeId == SpecimenType.Tissue &&
        specimen.Tissue.TypeId == TissueType.Tumor
    );

    public readonly static Expression<Func<CNV.Variant, bool>> IsInfluentCnv = variant =>
    !(
        variant.TypeId == CNV.Enums.CnvType.Neutral &&
        variant.Loh == false
    );
}
