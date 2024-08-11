using Sneat.MVC.App_Start;
using Sneat.MVC.Common;
using Sneat.MVC.Models.DTO.Project;
using Sneat.MVC.Models.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sneat.MVC.Controllers
{
    public class ProjectsController : BaseController
    {
        [UserAuthenticationFilter]
        public ActionResult Index()
        {
            return View();
        }

        [UserAuthenticationFilter]
        public async Task<PartialViewResult> Search(int page, string search = "")
        {
            var result = await _projectService.SearchProject(page, SystemParam.MAX_ROW_IN_LIST_WEB, search);
            return PartialView("_ListProject", result);
        }

        [UserAuthenticationFilter]
        public async Task<ActionResult> Create()
        {
            ViewBag.ListTeam = await _teamService.GetListTeam();
            return View();
        }

        [HttpPost]
        public async Task<int> CreateProject(ProjectInputModel input)
        {
            return await _projectService.CreateProject(input);
        }

        [UserAuthenticationFilter]
        public async Task<ActionResult> Update(int ID)
        {
            var detail = await _projectService.DetailProject(ID);
            return View(detail);
        }

        [HttpPost]
        public async Task<int> UpdateProject(ProjectOutputModel input)
        {
            return await _projectService.UpdateProject(input);
        }

        [HttpPost]
        public async Task<int> RemoveProject(int ID)
        {
            return await _projectService.RemoveProject(ID);
        }

        [HttpPost]
        public async Task<List<UpdateUserInputModel>> ListUserByTeam(List<int> teamIds)
        {
            return await _teamService.ListUserByTeam(teamIds);
        }
    }
}