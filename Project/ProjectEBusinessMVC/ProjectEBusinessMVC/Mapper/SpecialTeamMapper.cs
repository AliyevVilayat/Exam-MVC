using AutoMapper;
using ProjectEBusinessMVC.Areas.EBusinessVAdmin.ViewModels.SpecialTeam;
using ProjectEBusinessMVC.Core.Entities;
using ProjectEBusinessMVC.ViewModels.Index;

namespace ProjectEBusinessMVC.Mapper
{
    public class SpecialTeamMapper:Profile
    {
        public SpecialTeamMapper()
        {
            CreateMap<SpecialTeam, SpecialTeamVM>().ReverseMap();
            CreateMap<SpecialTeam, SpecialTeamIndexVM>().ReverseMap();
            CreateMap<SpecialTeam, SpecialTeamCreateVM>().ReverseMap();
            CreateMap<SpecialTeam, SpecialTeamUpdateVM>().ReverseMap();
            CreateMap<SpecialTeam, SpecialTeamDeleteVM>().ReverseMap();

        }
    }
}
