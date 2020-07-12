using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaSelecaoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Data.Maps
{
  public class SubscriptionMap : IEntityTypeConfiguration<Subscription>
  {
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
      builder.ToTable("Subscription");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Active).IsRequired();
      builder.Property(x => x.Price).IsRequired().HasColumnType("money");

      // FK
      builder.HasOne(x => x.Student).WithOne(x => x.Subscription);
    }
  }
}
