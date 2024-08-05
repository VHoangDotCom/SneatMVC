using Sneat.MVC.App_Start;
using Sneat.MVC.Common;
using Sneat.MVC.Models.DTO.Team;
using Sneat.MVC.Models.DTO.User;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sneat.MVC.Controllers
{
    public class TeamsController : BaseController
    {
        [UserAuthenticationFilter]
        public ActionResult Index()
        {
            ViewBag.TechStack = Helper.GetTechStackModels();
            return View();
        }

        [UserAuthenticationFilter]
        public async Task<PartialViewResult> Search(int page, string search = "")
        {
            var result = await _teamService.SearchTeam(page, SystemParam.MAX_ROW_IN_LIST_WEB, search);
            return PartialView("_ListTeam", result);
        }

        [HttpPost]
        public async Task<int> CreateTeam(TeamInputModel input)
        {
            return await _teamService.CreateTeam(input);
        }

        [HttpPost]
        public async Task<int> UpdateTeam(TeamOutputModel input)
        {
            return await _teamService.UpdateTeam(input);
        }

        [HttpPost]
        public async Task<int> RemoveTeam(int ID)
        {
            return await _teamService.RemoveTeam(ID);
        }
    }
}