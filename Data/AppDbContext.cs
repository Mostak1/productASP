
using Microsoft.EntityFrameworkCore;
using productASP.Models;

namespace productASP.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
}
