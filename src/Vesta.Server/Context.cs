using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vesta.Server.Domain;

namespace Vesta.Server
{
    public class Context : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }

    public class CustomerConfiguration  : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(c => c.Id)
                .ValueGeneratedNever();

            builder.OwnsOne(x => x.Email);
            builder.OwnsOne(x => x.Name);
            builder.OwnsOne(x => x.Address);
            builder
                .HasMany(x => x.Animals)
                .WithOne()
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }

    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder
                .Property(c => c.Id)
                .ValueGeneratedNever();

            builder.OwnsOne(x => x.LocatedAt);
            builder
                .HasMany(x => x.Journals)
                .WithOne()
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }

    public class JournalConfiguration : IEntityTypeConfiguration<Journal>
    {
        public void Configure(EntityTypeBuilder<Journal> builder)
        {
            builder
                .Property(c => c.Id)
                .ValueGeneratedNever();
        }
    }
}
