using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Donors.Clinical;
using Unite.Data.Entities.Donors.Clinical.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Donors.Clinical
{
    internal static class ClinicalDataModelBuilder
    {
        internal static void BuildClinicalDataModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicalData>(entity =>
            {
                entity.ToTable("ClinicalData");

                entity.HasKey(clinicalData => clinicalData.DonorId);

                entity.Property(clinicalData => clinicalData.DonorId)
                      .IsRequired()
                      .ValueGeneratedNever();

                entity.Property(clinicalData => clinicalData.GenderId)
                      .HasConversion<int>();

                entity.Property(clinicalData => clinicalData.Diagnosis)
                      .HasMaxLength(255);


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
            });
        }
    }
}
