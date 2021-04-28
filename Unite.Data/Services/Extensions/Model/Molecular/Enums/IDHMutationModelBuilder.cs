using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Molecular.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Molecular.Enums
{
    public static class IDHMutationModelBuilder
    {
        public static void BuildIDHMutationModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<IDHMutation>[]
            {
                IDHMutation.IDH1_R132H.ToEnumValue(),
                IDHMutation.IDH1_R132C.ToEnumValue(),
                IDHMutation.IDH1_R132G.ToEnumValue(),
                IDHMutation.IDH1_R132L.ToEnumValue(),
                IDHMutation.IDH1_R132S.ToEnumValue(),
                IDHMutation.IDH2_R172G.ToEnumValue(),
                IDHMutation.IDH2_R172W.ToEnumValue(),
                IDHMutation.IDH2_R172K.ToEnumValue(),
                IDHMutation.IDH2_R172T.ToEnumValue(),
                IDHMutation.IDH2_R172M.ToEnumValue(),
                IDHMutation.IDH2_R172S.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("IDHMutations", data);
        }
    }
}
