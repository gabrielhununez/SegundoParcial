using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SegundoParcial.Data.Models;

namespace SegundoParcial.Data.EF;

public class DBContext : DbContext
{
    public DBContext() { }
    public DbSet<Animal> Animales { get; set; }

    public DBContext(DbContextOptions<DBContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<DBContext>()
                .Build();
            var connectionString = config.GetConnectionString("conexion-db");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}