using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectEBusinessMVC.Core.Entities;
using ProjectEBusinessMVC.DataAccess.Repositories.Interfaces;
using ProjectEBusinessMVC.ViewModels.Index;

namespace ProjectEBusinessMVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISpecialTeamRepository _repository;
        private readonly IMapper _mapper;
        public HomeController(ISpecialTeamRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            List<Core.Entities.SpecialTeam> specialTeams = await _repository.FindAll().ToListAsync();
            List<ViewModels.Index.SpecialTeamVM> specialItemVMs = _mapper.Map<List<ViewModels.Index.SpecialTeamVM>>(specialTeams);
            IndexVM indexVM = new();
            indexVM.SpecialTeamVMs = specialItemVMs;

            return View(indexVM);
        }
    }
}
