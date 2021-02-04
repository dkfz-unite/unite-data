using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Epigenetics;
using Unite.Data.Entities.Epigenetics.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Epigenetics
{
    public static class EpigeneticsDataModelBuilder
    {
        public static void BuildEpigeneticsDataModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EpigeneticsData>(entity =>
            {
                entity.ToTable("EpigeneticsData");

                entity.HasKey(epigeneticsData => epigeneticsData.DonorId);

                entity.Property(epigeneticsData => epigeneticsData.DonorId)
                      .IsRequired();

                entity.Property(epigeneticsData => epigeneticsData.DonorId)
                      .IsRequired();

                entity.Property(epigeneticsData => epigeneticsData.GeneExpressionSubtypeId)
                      .HasConversion<int>();

                entity.Property(epigeneticsData => epigeneticsData.IdhStatusId)
                      .HasConversion<int>();

                entity.Property(epigeneticsData => epigeneticsData.IdhMutationId)
                      .HasConversion<int>();

                entity.Property(epigeneticsData => epigeneticsData.MethylationStatusId)
                      .HasConversion<int>();

                entity.Property(epigeneticsData => epigeneticsData.MethylationSubtypeId)
                      .HasConversion<int>();


                entity.HasOne<EnumValue<GeneExpressionSubtype>>()
                      .WithMany()
                      .HasForeignKey(epigeneticsData => epigeneticsData.GeneExpressionSubtypeId);

                entity.HasOne<EnumValue<IDHStatus>>()
                      .WithMany()
                      .HasForeignKey(epigeneticsData => epigeneticsData.IdhStatusId);

                entity.HasOne<EnumValue<IDHMutation>>()
                      .WithMany()
                      .HasForeignKey(epigeneticsData => epigeneticsData.IdhMutationId);

                entity.HasOne<EnumValue<MethylationStatus>>()
                      .WithMany()
                      .HasForeignKey(epigeneticsData => epigeneticsData.MethylationStatusId);

                entity.HasOne<EnumValue<MethylationSubtype>>()
                      .WithMany()
                      .HasForeignKey(epigeneticsData => epigeneticsData.MethylationSubtypeId);


                entity.HasOne<Donor>()
                      .WithOne(donor => donor.EpigeneticsData)
                      .HasForeignKey<EpigeneticsData>(epigeneticsData => epigeneticsData.DonorId)
                      .IsRequired();
            });
        }
    }
}
