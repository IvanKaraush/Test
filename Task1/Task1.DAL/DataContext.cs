using Microsoft.EntityFrameworkCore;
using Task1.DAL.Configurations;
using Task1.DAL.Entities;

namespace Task1.DAL;

public class DataContext : DbContext
{
    public DbSet<Data> Data => Set<Data>();

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DataConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}