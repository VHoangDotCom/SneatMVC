using Sneat.MVC.Common;
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
        public async Task<JsonResultModel> GetListProject(
            int page = SystemParam.PAGE_DEFAULT, 
            int limit = SystemParam.MAX_ROW_IN_LIST_WEB, 
            string search = "")
        {
            return await _projectService.GetListProject(page, limit, search);
        }
    }
}
