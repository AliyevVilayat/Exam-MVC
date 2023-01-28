using Microsoft.EntityFrameworkCore;
using ProjectEBusinessMVC.Core.Entities;
using ProjectEBusinessMVC.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEBusinessMVC.DataAccess.Contexts
{
    public class AppDbContextInitializer
    {
        private readonly AppDbContext _context;
        private readonly ISpecialTeamRepository _specialTeamRepository;

        public AppDbContextInitializer(AppDbContext context, ISpecialTeamRepository specialTeamRepository)
        {
            _context = context;
            _specialTeamRepository = specialTeamRepository;
        }

        public async Task InitializeAsync()
        {
            await _context.Database.MigrateAsync();
        }

        public async Task CreateSpecialTeamAsync()
        {
            if (await _context.SpecialTeams.CountAsync() != 0) return;
            SpecialTeam specialTeam1 = new()
            {
                Img = "1.jpg",
                FullName = "Jhon Mickel",
                Position = "Seo",

            };

            SpecialTeam specialTeam2 = new()
            {
                Img = "2.jpg",
                FullName = "Andrew Arnold",
                Position = "Web Developer",

            };

            try
            {
                await _specialTeamRepository.CreateAsync(specialTeam1);
                await _specialTeamRepository.CreateAsync(specialTeam2);
                await _specialTeamRepository.SaveAsync();
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}
