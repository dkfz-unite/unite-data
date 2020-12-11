using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Donors.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Donors
{
    public static class ClinicalDataModelBuilder
    {
        public static void BuildClinicalDataModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicalData>(entity =>
            {
                entity.ToTable("ClinicalData");

                entity.HasKey(clinicalData => clinicalData.DonorId);

                entity.Property(clinicalData => clinicalData.DonorId)
                      .IsRequired();

                entity.Property(clinicalData => clinicalData.GenderId)
                      .HasConversion<int>();

                entity.Property(clinicalData => clinicalData.AgeCategoryId)
                      .HasConversion<int>();

                entity.Property(clinicalData => clinicalData.VitalStatusId)
                      .HasConversion<int>();


                entity.HasOne<EnumValue<Gender>>()
                      .WithMany()
                      .HasForeignKey(clinicalData => clinicalData.GenderId);

                entity.HasOne<EnumValue<AgeCategory>>()
                      .WithMany()
                      .HasForeignKey(clinicalData => clinicalData.AgeCategoryId);

                entity.HasOne<EnumValue<VitalStatus>>()
                      .WithMany()
                      .HasForeignKey(clinicalData => clinicalData.VitalStatusId);


                entity.HasOne(clinicalData => clinicalData.Localization)
                      .WithMany()
                      .HasForeignKey(clinicalData => clinicalData.LocalizationId);

                entity.HasOne<Donor>()
                      .WithOne(donor => donor.ClinicalData)
                      .HasForeignKey<ClinicalData>(clinicalData => clinicalData.DonorId)
                      .IsRequired();
            });
        }
    }
}
