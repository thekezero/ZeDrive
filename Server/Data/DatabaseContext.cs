using Microsoft.EntityFrameworkCore;
using ZeDrive.Shared.Models;

namespace ZeDrive.Server.Data;

public class DatabaseContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=databse.sqlite");
        base.OnConfiguring(options);
    }

    public override Task<int> SaveChangesAsync(CancellationToken token = default)
    {
        return Task.Run(() => SaveChanges(), token == default ? CancellationToken.None : token);
    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries().Where(x => x.State is EntityState.Added or EntityState.Modified))
        {
            var entity = entry.Entity;
            var createdAt = entity.GetType().GetProperty("CreatedAt");
            var updatedAt = entity.GetType().GetProperty("UpdatedAt");

            if (createdAt is { CanRead: true, CanWrite: true } && entry.State is EntityState.Added)
                createdAt?.SetValue(entity, DateTime.UtcNow);
            if (updatedAt is { CanRead: true, CanWrite: true })
                updatedAt?.SetValue(entity, DateTime.UtcNow);
        }

        return base.SaveChanges();
    }

}