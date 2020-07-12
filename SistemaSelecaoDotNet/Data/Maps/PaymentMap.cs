using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaSelecaoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Data.Maps
{
  public class PaymentMap : IEntityTypeConfiguration<Payment>
  {
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
      builder.ToTable("Payment");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Date).IsRequired();

      // FK
      builder.HasOne(x => x.Student).WithMany(x => x.Payments);
    }
  }
}
