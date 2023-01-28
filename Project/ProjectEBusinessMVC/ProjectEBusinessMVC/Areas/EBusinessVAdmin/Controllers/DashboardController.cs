using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel;
using ProjectEBusinessMVC.Areas.EBusinessVAdmin.ViewModels.SpecialTeam;
using ProjectEBusinessMVC.Core.Entities;
using ProjectEBusinessMVC.DataAccess.Contexts;
using ProjectEBusinessMVC.DataAccess.Repositories.Interfaces;
using ProjectEBusinessMVC.Extensions;
using ProjectEBusinessMVC.ViewModels.Index;
using System.Drawing;
using IndexVM = ProjectEBusinessMVC.Areas.EBusinessVAdmin.ViewModels.SpecialTeam.IndexVM;

namespace ProjectEBusinessMVC.Areas.EBusinessVAdmin.Controllers
{
    [Area("EBusinessVAdmin")]
    public class DashboardController : Controller
    {
        private readonly ISpecialTeamRepository _specialTeamRepository;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public DashboardController(ISpecialTeamRepository specialTeamRepository, IMapper mapper, IWebHostEnvironment env,AppDbContext context)
        {
            _specialTeamRepository = specialTeamRepository;
            _mapper = mapper;
            _env = env;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<SpecialTeam> specialTeams = await _specialTeamRepository.FindAll().ToListAsync();
            List<SpecialTeamIndexVM> specialTeamIndexVMs = _mapper.Map<List<SpecialTeamIndexVM>>(specialTeams);
            IndexVM indexVM = new();
            indexVM.SpecialTeamIndexVMs = specialTeamIndexVMs;
            return View(indexVM);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTeamCreateVM specialTeamCreateVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(specialTeamCreateVM);
                }

                if (specialTeamCreateVM.Img is null)
                {
                    ModelState.AddModelError("Img", "The Img field is required.");
                    return View(specialTeamCreateVM);
                }

                string filename = await specialTeamCreateVM.Img.FileSaveAsync(_env.WebRootPath, "asstes", "img", "team");

                SpecialTeam specialTeam = _mapper.Map<SpecialTeam>(specialTeamCreateVM);
                specialTeam.Img = filename;
                await _specialTeamRepository.CreateAsync(specialTeam);
                await _specialTeamRepository.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> Detail(int id)
        {

            SpecialTeam specialTeam = await _specialTeamRepository.FindById(id);
            return View(specialTeam);
        }

        public async Task<IActionResult> Update(int id)
        {

            SpecialTeam specialTeam = await _specialTeamRepository.FindById(id);
            if (specialTeam is null) return NotFound();
            SpecialTeamUpdateVM specialTeamUpdateVM = _mapper.Map<SpecialTeamUpdateVM>(specialTeam);
            ViewData["Img"] = specialTeam.Img;
            return View(specialTeamUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SpecialTeamUpdateVM specialTeamUpdateVM)
        {

            if (id != specialTeamUpdateVM.Id)
            {

                return BadRequest();
            }

            SpecialTeam baseSpecialItem = await _specialTeamRepository.FindByCondition(s => s.Id == specialTeamUpdateVM.Id).FirstOrDefaultAsync();
            if (baseSpecialItem is null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewData["Img"] = baseSpecialItem.Img;
                return View(specialTeamUpdateVM);
            }

            string filename = string.Empty;
            if (specialTeamUpdateVM.ImgFile is not null)
            {
                filename = await specialTeamUpdateVM.ImgFile.FileSaveAsync(_env.WebRootPath, "asstes", "img", "team");
            }
            SpecialTeam specialTeam = _mapper.Map<SpecialTeam>(specialTeamUpdateVM);
            if (baseSpecialItem.Img != null)
            {
                specialTeam.Img = filename;
            }
            else
            {
                specialTeam.Img = baseSpecialItem.Img;
            }

            _specialTeamRepository.Update(specialTeam);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            
            SpecialTeam specialTeam = await _specialTeamRepository.FindById(id);
            if (specialTeam is null) return NotFound();       
            if(await _context.SpecialTeams.CountAsync() <= 2)
            {
                TempData["DeleteMinRequired"] = "2 - den az melumat olduqda silmek olmaz";
                return RedirectToAction(nameof(Index));
            }
            SpecialTeamUpdateVM specialTeamUpdateVM = _mapper.Map<SpecialTeamUpdateVM>(specialTeam);
            ViewData["Img"] = specialTeam.Img;
            return View(specialTeamUpdateVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(SpecialTeamDeleteVM specialTeamDeleteVM)
        {

            SpecialTeam specialTeam = _mapper.Map<SpecialTeam>(specialTeamDeleteVM);

            try
            {
                if (System.IO.File.Exists(specialTeam.Img))
                {
                    System.IO.File.Delete(specialTeam.Img);
                }
                _specialTeamRepository.Delete(specialTeam);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
            
            
        }


    }
}
