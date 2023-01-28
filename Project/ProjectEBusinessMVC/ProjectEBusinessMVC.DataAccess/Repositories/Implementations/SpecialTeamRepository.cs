using ProjectEBusinessMVC.Core.Entities;
using ProjectEBusinessMVC.DataAccess.Contexts;
using ProjectEBusinessMVC.DataAccess.Repositories.Interfaces;

namespace ProjectEBusinessMVC.DataAccess.Repositories.Implementations;

public class SpecialTeamRepository : Repository<SpecialTeam>,ISpecialTeamRepository
{
    public SpecialTeamRepository(AppDbContext context) : base(context)
    {
    }
}
