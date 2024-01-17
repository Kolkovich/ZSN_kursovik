using Microsoft.EntityFrameworkCore;
using ZavodSocialNetwork.Server.Models;

namespace ZavodSocialNetwork.Server;

public class ApplicationContext : DbContext
{
    public DbSet<Check> Checks { get; set; } = null!;
    public DbSet<Conditions> Conditions { get; set; } = null!;
    public DbSet<Contract> Contracts { get; set; } = null!;
    public DbSet<Goods_package> GoodsPackages { get; set; } = null!;
    public DbSet<Goods_position> GoodsPositions { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

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