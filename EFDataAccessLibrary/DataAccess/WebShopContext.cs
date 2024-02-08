using EFDataAccessLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.DataAccess;

public class WebShopContext : DbContext
{
    //public ProductContext(DbContextOptions options): base(options) // calls the parent constructor
    //{ }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Istedenfor passord og bruker kan man bruke Integrated Security=True; det funker bra i lukket miljø. Den bruker "credentials" fra windows innlogging, funker ikke i produksjon da
        optionsBuilder.UseSqlServer(@"Data Source=localhost,1433;Connect Timeout=30;Initial Catalog=WebShopIncDB;Encrypt=False;TrustServerCertificate=False;User=sa;Password=pasSord123");
    }

    public DbSet<Product> Product { get; set; }

    public DbSet<ProductDeliveryTime> ProductDeliveryTime { get; set; }
}
