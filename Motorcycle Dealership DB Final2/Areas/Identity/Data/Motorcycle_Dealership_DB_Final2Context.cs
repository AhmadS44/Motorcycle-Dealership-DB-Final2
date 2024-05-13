using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motorcycle_Dealership_DB_Final2.Areas.Identity.Data;
using Motorcycle_Dealership_DB_Final2.Models;

namespace Motorcycle_Dealership_DB_Final2.Areas.Identity.Data;

public class Motorcycle_Dealership_DB_Final2Context : IdentityDbContext<ApplicationUser>
{
    public Motorcycle_Dealership_DB_Final2Context(DbContextOptions<Motorcycle_Dealership_DB_Final2Context> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }

    internal static async Task<string?> ToListAsync()
    {
        throw new NotImplementedException();
    }

    public DbSet<Motorcycle_Dealership_DB_Final2.Models.Customer> Customer { get; set; } = default!;

public DbSet<Motorcycle_Dealership_DB_Final2.Models.Inventory> Inventory { get; set; } = default!;

public DbSet<Motorcycle_Dealership_DB_Final2.Models.Location> Location { get; set; } = default!;

public DbSet<Motorcycle_Dealership_DB_Final2.Models.Motorcycle> Motorcycle { get; set; } = default!;

public DbSet<Motorcycle_Dealership_DB_Final2.Models.PurchaseOrder> PurchaseOrder { get; set; } = default!;

public DbSet<Motorcycle_Dealership_DB_Final2.Models.Supplier> Supplier { get; set; } = default!;
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(20);
        builder.Property(u => u.LastName).HasMaxLength(20);
        builder.Property(u => u.PhoneNumber).HasMaxLength(10);
    }
}
