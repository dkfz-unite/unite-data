using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Samples;

namespace Unite.Data.Services.Extensions.Model.Samples
{
    public static class VcfDataModelBuilder
    {
        public static void BuildVcfDataModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VcfData>(entity =>
            {
                entity.ToTable("VcfData");

                entity.HasKey(vcfData => new { vcfData.SampleId, vcfData.MutationId });

                entity.Property(vcfData => vcfData.SampleId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(vcfData => vcfData.MutationId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(vcfData => vcfData.Quality)
                      .HasMaxLength(50);

                entity.Property(vcfData => vcfData.Filter)
                      .HasMaxLength(50);

                entity.Property(vcfData => vcfData.Info)
                      .HasMaxLength(500);

                entity.Property(vcfData => vcfData.SampleInfoFormat)
                      .HasMaxLength(500);

                entity.Property(vcfData => vcfData.SampleInfo)
                      .HasMaxLength(500);


                entity.HasOne<SampleMutation>()
                      .WithOne(sampleMutation => sampleMutation.VcfData)
                      .HasForeignKey<VcfData>(vcfData => new { vcfData.SampleId, vcfData.MutationId });
            });
        }
    }
}
