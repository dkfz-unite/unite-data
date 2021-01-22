﻿using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities;

namespace Unite.Data.Services.Extensions.Model
{
    public static class FileModelBuilder
    {
        public static void BuildFileModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("Files");

                entity.HasKey(file => file.Id);

                entity.Property(file => file.Id)
                      .IsRequired()
                      .ValueGeneratedOnAdd();

                entity.Property(file => file.Name)
                      .IsRequired();
            });
        }
    }
}
