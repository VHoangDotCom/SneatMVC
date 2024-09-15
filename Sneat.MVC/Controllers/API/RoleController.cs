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
    public class RoleController : ApiController
    {
        private readonly RoleService _roleService;
        public RoleController()
        {
            _roleService = new RoleService();
        }

        [HttpGet]
        public async Task<JsonResultModel> GetListRoles(int page = 1, int limit = 12, string search = null)
        {
            var list =  await _roleService.SearchRole(page, limit, search);
            var paging = new PagingModel
            {
                Page = page,
                Limit = limit,
                TotalItemCount = list.TotalItemCount,
            };

            return JsonResponse.SucessPaging(list, paging);
        }
    }
}
