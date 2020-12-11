using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Cells;
using Unite.Data.Entities.Cells.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Cells
{
    public static class CellLineModelBuilder
    {
        public static void BuildCellLineModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CellLine>(entity =>
            {
                entity.ToTable("CellLines");

                entity.HasKey(cellLine => cellLine.Id);

                entity.Property(cellLine => cellLine.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(cellLine => cellLine.DonorId)
                      .IsRequired();

                entity.Property(cellLine => cellLine.Name)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(cellLine => cellLine.TypeId)
                      .HasConversion<int>();

                entity.Property(cellLine => cellLine.SpeciesId)
                      .HasConversion<int>();

                entity.Property(cellLine => cellLine.GeneExpressionSubtypeId)
                      .HasConversion<int>();

                entity.Property(cellLine => cellLine.IdhStatusId)
                      .HasConversion<int>();

                entity.Property(cellLine => cellLine.IdhMutationId)
                      .HasConversion<int>();

                entity.Property(cellLine => cellLine.MethylationStatusId)
                      .HasConversion<int>();

                entity.Property(cellLine => cellLine.MethylationSubtypeId)
                      .HasConversion<int>();


                entity.HasOne<EnumValue<CellLineType>>()
                      .WithMany()
                      .HasForeignKey(cellLine => cellLine.TypeId);

                entity.HasOne<EnumValue<Species>>()
                      .WithMany()
                      .HasForeignKey(cellLine => cellLine.SpeciesId);

                entity.HasOne<EnumValue<GeneExpressionSubtype>>()
                      .WithMany()
                      .HasForeignKey(cellLine => cellLine.GeneExpressionSubtypeId);

                entity.HasOne<EnumValue<IDHStatus>>()
                      .WithMany()
                      .HasForeignKey(cellLine => cellLine.IdhStatusId);

                entity.HasOne<EnumValue<IDHMutation>>()
                      .WithMany()
                      .HasForeignKey(cellLine => cellLine.IdhMutationId);

                entity.HasOne<EnumValue<MethylationStatus>>()
                      .WithMany()
                      .HasForeignKey(cellLine => cellLine.MethylationStatusId);

                entity.HasOne<EnumValue<MethylationSubtype>>()
                      .WithMany()
                      .HasForeignKey(cellLine => cellLine.MethylationSubtypeId);


                entity.HasOne(cellLine => cellLine.Donor)
                      .WithMany(donor => donor.CellLines)
                      .HasForeignKey(cellLine => cellLine.DonorId);

                entity.HasOne(cellLine => cellLine.Parent)
                      .WithMany()
                      .HasForeignKey(cellLine => cellLine.ParentId);

                entity.HasMany(cellLine => cellLine.Childern)
                      .WithOne()
                      .HasForeignKey(cellLine => cellLine.Id);
            });
        }
    }
}
