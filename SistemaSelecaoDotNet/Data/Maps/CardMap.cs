using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaSelecaoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Data.Maps
{
  public class CardMap : IEntityTypeConfiguration<Card>
  {
    public void Configure(EntityTypeBuilder<Card> builder)
    {
      builder.ToTable("Card");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Number).IsRequired().HasMaxLength(120).HasColumnType("varchar(120)");

      // FK
      builder.HasOne(x => x.Student).WithOne(x => x.Card);
    }
  }
}
