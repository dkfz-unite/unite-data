using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Mutations.Enums
{
    internal static class MutationTypeModelBuilder
    {
        internal static void BuildMutationTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<MutationType>[]
            {
                MutationType.SNV.ToEnumValue(name: "Single Nucleotide Variant"),
                MutationType.INS.ToEnumValue(name: "Insertion"),
                MutationType.DEL.ToEnumValue(name: "Deletion"),
                MutationType.MNV.ToEnumValue(name: "Multiple Nucleotide Variant")
            };

            modelBuilder.BuildEnumValueModel("MutationTypes", data);
        }
    }
}
