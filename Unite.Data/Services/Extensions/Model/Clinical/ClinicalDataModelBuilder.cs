using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Clinical.Enums;
using Unite.Data.Services.Entities;
using Unite.Data.Entities.Clinical;
using Unite.Data.Entities.Samples;

namespace Unite.Data.Services.Extensions.Model.Donors
{
    public static class ClinicalDataModelBuilder
    {
        public static void BuildClinicalDataModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicalData>(entity =>
            {
                entity.ToTable("ClinicalData");

                entity.HasKey(clinicalData => new
                {
                    clinicalData.DonorId,
                    clinicalData.SampleId
                });

                entity.Property(clinicalData => clinicalData.DonorId)
                      .ValueGeneratedNever();

                entity.Property(clinicalData => clinicalData.SampleId)
                      .ValueGeneratedNever();

                entity.Property(clinicalData => clinicalData.GenderId)
                      .HasConversion<int>();

                entity.Property(clinicalData => clinicalData.Diagnosis)
                      .HasMaxLength(100);


                entity.HasOne<EnumValue<Gender>>()
                      .WithMany()
                      .HasForeignKey(clinicalData => clinicalData.GenderId);

                entity.HasOne(clinicalData => clinicalData.PrimarySite)
                      .WithMany()
                      .HasForeignKey(clinicalData => clinicalData.PrimarySiteId);

                entity.HasOne(clinicalData => clinicalData.Localization)
                      .WithMany()
                      .HasForeignKey(clinicalData => clinicalData.LocalizationId);

                entity.HasOne<Donor>()
                      .WithOne(donor => donor.ClinicalData)
                      .HasForeignKey<ClinicalData>(clinicalData => clinicalData.DonorId);

                entity.HasOne<Sample>()
                      .WithOne(sample => sample.ClinicalData)
                      .HasForeignKey<ClinicalData>(clinicalData => clinicalData.SampleId);
            });
        }
    }
}
