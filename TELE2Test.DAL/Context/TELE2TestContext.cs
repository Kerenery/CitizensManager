using Microsoft.EntityFrameworkCore;
using TELE2Test.DAL.Entities;

namespace TELE2Test.DAL.Context;

public class TELE2TestContext : DbContext
{
    public DbSet<Citizen> Citizens { get; set; } = null!;
    
    public TELE2TestContext(DbContextOptions<TELE2TestContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Citizen>().ToTable("Citizens");
        base.OnModelCreating(modelBuilder);
    }
}