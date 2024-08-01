using Microsoft.EntityFrameworkCore;
using ReStore.Domain.Entities;

namespace ReStore.Infra.Data.Context;
public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
