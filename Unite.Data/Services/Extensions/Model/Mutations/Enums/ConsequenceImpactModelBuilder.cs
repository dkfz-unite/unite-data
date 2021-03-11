using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Mutations.Enums
{
    public static class ConsequenceImpactModelBuilder
    {
        public static void BuildConsequenceImpactModel(this ModelBuilder modelBuilder)
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
