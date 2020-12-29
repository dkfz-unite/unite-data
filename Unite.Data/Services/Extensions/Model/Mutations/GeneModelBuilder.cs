﻿using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Services.Extensions.Model.Mutations
{
    public static class GeneModelBuilder
    {
        public static void BuildGeneModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gene>(entity =>
            {
                entity.ToTable("Genes");

                entity.HasKey(gene => gene.Id);

                entity.HasAlternateKey(gene => gene.Name);

                entity.Property(gene => gene.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(gene => gene.Name)
                      .IsRequired()
                      .HasMaxLength(100);
            });
        }
    }
}
