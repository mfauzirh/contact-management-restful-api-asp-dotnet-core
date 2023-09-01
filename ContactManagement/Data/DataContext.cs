using Microsoft.EntityFrameworkCore;
using ContactManagement.Models;

namespace ContactManagement.Data;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Address> Addresses { get; set; }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserName);

            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.User)
                .WithMany(u => u.Contact)
                .HasForeignKey(e => e.UserName)
                .IsRequired();

            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.LastName)
                .HasMaxLength(100);

            entity.Property(e => e.Email)
                .HasMaxLength(100);

            entity.Property(e => e.Phone)
                .HasMaxLength(20);
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Street)
                .HasMaxLength(255);

            entity.Property(e => e.City)
                .HasMaxLength(100);

            entity.Property(e => e.Province)
                .HasMaxLength(100);

            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsRequired();

        });
    }
}