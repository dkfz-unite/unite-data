using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Mutations.Enums
{
    internal static class ConsequenceImpactModelBuilder
    {
        internal static void BuildConsequenceImpactModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<ConsequenceImpact>[]
            {
                ConsequenceImpact.High.ToEnumValue(),
                ConsequenceImpact.Moderate.ToEnumValue(),
                ConsequenceImpact.Low.ToEnumValue(),
                ConsequenceImpact.Unknown.ToEnumValue(),
            };

            modelBuilder.BuildEnumValueModel("ConsequenceImpacts", data);
        }
    }
}
