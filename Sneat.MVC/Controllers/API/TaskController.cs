using Sneat.MVC.Common;
using Sneat.MVC.Models.APIModel;
using Sneat.MVC.Models.DTO.WorkPackage;
using Sneat.MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Sneat.MVC.Controllers.API
{
    public class TaskController : ApiController
    {
        private readonly TaskService _taskService;

        public TaskController()
        {
            _taskService = new TaskService();
        }

        [HttpGet]
        public async Task<JsonResultModel> GetListTaskPaging(
            string search = "",
            int? projectID = null,
            int? sprintID = null,
            int? assigneeID = null,
            int page = SystemParam.PAGE_DEFAULT,
            int limit = SystemParam.MAX_ROW_IN_LIST_WEB
        )
        {
            return await _taskService.GetListTaskPaging(search, projectID, sprintID, assigneeID, page, limit);
        }

        [HttpPost]
        public async Task<JsonResultModel> CreateTask(WorkPackageInputModel input)
        {
            return await _taskService.CreateTask(input);
        }

        [HttpPost]
        public async Task<JsonResultModel> UpdateTask(WorkPackageOutputModel input)
        {
            return await _taskService.UpdateTask(input);
        }

        [HttpGet]
        public async Task<JsonResultModel> DetailTask(int ID)
        {
            return await _taskService.DetailTask(ID);
        }

        [HttpPost]
        public async Task<JsonResultModel> DeleteTask(int ID)
        {
            return await _taskService.DeleteTask(ID);
        }
    }
}