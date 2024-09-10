using Microsoft.EntityFrameworkCore;
using Proyecto_Practica02_.Models;

namespace Proyecto_Practica02_.Data
  {
  public class DataBaseContext : DbContext
    {

    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
      {

      }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
      base.OnModelCreating(modelBuilder);
      modelBuilder.Entity<Product>().HasIndex(p => p.Id).IsUnique();
      }
    }
  }
