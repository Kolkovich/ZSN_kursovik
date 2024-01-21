using Microsoft.EntityFrameworkCore;
using ZavodSocialNetwork.Server.Models;

namespace ZavodSocialNetwork.Server;

public class ApplicationContext : DbContext
{
    public DbSet<Receipt> Receipts { get; set; } = null!;
    public DbSet<Contract> Contracts { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Product> Product { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=KursachS;Username=postgres;Password=rootroot");
    }
    
}