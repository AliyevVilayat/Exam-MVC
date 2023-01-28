using ProjectEBusinessMVC.Core.Entities;

namespace ProjectEBusinessMVC.ViewModels.Index
{
    public class IndexVM
    {
        public IEnumerable<SpecialTeamVM> SpecialTeamVMs { get; set; } = null!;
    }
}
