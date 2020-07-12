using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaSelecaoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Data.Maps
{
  public class EnrolmentMap : IEntityTypeConfiguration<Enrolment>
  {
    public void Configure(EntityTypeBuilder<Enrolment> builder)
    {
      builder.ToTable("Enrolment");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Date).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
      //builder.Property(x => x.CreateDate).IsRequired();

      // FK
      builder.HasOne(x => x.Student).WithMany(x => x.Enrolments);
      builder.HasOne(x => x.Course).WithMany(x => x.Enrolments);
    } 
  }
}
