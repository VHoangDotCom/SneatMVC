using Sneat.MVC.Models.APIModel;
using Sneat.MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sneat.MVC.Controllers.API
{
    public class ProjectController : ApiController
    {
        private readonly ProjectService _projectService;
        public ProjectController()
        {
            _projectService = new ProjectService();
        }

        [HttpGet]
        public async Task<JsonResultModel> GetListProject(int page = 1, int limit = 12, string search = "")
        {
            return await _projectService.GetListProject(page, limit, search);
        }
    }
}
