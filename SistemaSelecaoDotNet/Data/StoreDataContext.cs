using Microsoft.EntityFrameworkCore;
using SistemaSelecaoDotNet.Data.Maps;
using SistemaSelecaoDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaSelecaoDotNet.Data
{
  public class StoreDataContext : DbContext
  {
    public StoreDataContext(DbContextOptions<StoreDataContext> options)
            : base(options)
    { }
    public StoreDataContext()
    { }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Coursies { get; set; }
    public DbSet<Enrolment> Enrolments { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0U31MOA\SQLEXPRESS;Initial Catalog=SelecaoDotNet;User ID=sa;Password=4565");
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.ApplyConfiguration(new StudentMap());
      builder.ApplyConfiguration(new CourseMap());
      builder.ApplyConfiguration(new EnrolmentMap());
      builder.ApplyConfiguration(new CardMap());
      builder.ApplyConfiguration(new SubscriptionMap());
      builder.ApplyConfiguration(new PaymentMap());
      builder.ApplyConfiguration(new UserMap());
    }
  }
}
