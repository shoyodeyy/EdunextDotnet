using Microsoft.EntityFrameworkCore;

namespace Edunext.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // public DbSet<EmployeeEntity> Employees { get; set; }
}