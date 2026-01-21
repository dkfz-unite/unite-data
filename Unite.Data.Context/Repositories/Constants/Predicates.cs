using System.Linq.Expressions;
using Unite.Data.Entities.Specimens;
using Unite.Data.Entities.Specimens.Enums;

using Cnv = Unite.Data.Entities.Omics.Analysis.Dna.Cnv;

namespace Unite.Data.Context.Repositories.Constants;

public static class Predicates
{
    public readonly static Expression<Func<Specimen, bool>> IsImageRelatedSpecimen = specimen =>
    (
        specimen.ParentId == null &&
        specimen.TypeId == SpecimenType.Material &&
        specimen.ConditionId == Condition.Tumor
    );

    public readonly static Expression<Func<Cnv.Variant, bool>> IsInfluentCnv = variant =>
    !(
        variant.TypeId == Cnv.Enums.CnvType.Neutral &&
        variant.Loh == false
    );
}
