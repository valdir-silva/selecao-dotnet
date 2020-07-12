using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaSelecaoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Data.Maps
{
  public class UserMap : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.ToTable("User");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Login).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");
      builder.Property(x => x.Password).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");

      // FK
      builder.HasOne(x => x.Student).WithOne(x => x.user);
    }
  }
}
