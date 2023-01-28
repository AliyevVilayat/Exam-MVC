using Microsoft.EntityFrameworkCore;
using ProjectEBusinessMVC.Core.Entities;

namespace ProjectEBusinessMVC.DataAccess.Contexts;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {

    }

    public DbSet<SpecialTeam> SpecialTeams { get; set; } = null!;
}
