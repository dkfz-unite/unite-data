using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Entities.Donors.Clinical;
using Unite.Data.Entities.Donors.Clinical.Enums;

namespace Unite.Data.Context.Mappers.Donors.Clinical;

internal class ClinicalDataMapper : IEntityTypeConfiguration<ClinicalData>
{
    public void Configure(EntityTypeBuilder<ClinicalData> entity)
    {
        entity.ToTable("clinical_data", DomainDbSchemaNames.Donors);

        entity.HasKey(clinicalData => clinicalData.DonorId);

        entity.Property(clinicalData => clinicalData.DonorId)
              .IsRequired()
              .ValueGeneratedNever();

        entity.Property(clinicalData => clinicalData.SexId)
              .HasConversion<int>();

        entity.Property(clinicalData => clinicalData.Diagnosis)
              .HasMaxLength(255);


        entity.HasOne<EnumEntity<Sex>>()
              .WithMany()
              .HasForeignKey(clinicalData => clinicalData.SexId);

        entity.HasOne(clinicalData => clinicalData.PrimarySite)
              .WithMany()
              .HasForeignKey(clinicalData => clinicalData.PrimarySiteId);

        entity.HasOne(clinicalData => clinicalData.Localization)
              .WithMany()
              .HasForeignKey(clinicalData => clinicalData.LocalizationId);

        entity.HasOne(clinicalData => clinicalData.Donor)
              .WithOne(donor => donor.ClinicalData)
              .HasForeignKey<ClinicalData>(clinicalData => clinicalData.DonorId);
    }
}
