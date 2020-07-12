using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaSelecaoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Data.Maps
{
  public class CourseMap : IEntityTypeConfiguration<Course>
  {
    public void Configure(EntityTypeBuilder<Course> builder)
    {
      builder.ToTable("Course");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Title).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
    }
  }
}
