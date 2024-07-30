using Sneat.MVC.App_Start;
using Sneat.MVC.Common;
using Sneat.MVC.Models.DTO.Role;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sneat.MVC.Controllers
{
    public class RolesController : BaseController
    {
        [UserAuthenticationFilter]
        public async Task<ActionResult> Index()
        {
            ViewBag.PermissionOptionTree = await _roleService.GetAllPermissions();
            return View();
        }

        [UserAuthenticationFilter]
        public async Task<PartialViewResult> SearchRole(int page, string search = "")
        {
            var result = await _roleService.SearchRole(page, SystemParam.MAX_ROW_IN_LIST_WEB, search);
            return PartialView("_ListRole", result);
        }
       
        public async Task<int> CreateRole(RoleInputModel input)
        {
            return await _roleService.CreateRole(input);
        }

        public async Task<int> UpdateRole(RoleOutputModel input)
        {
            return await _roleService.UpdateRole(input);
        }

        public async Task<int> RemoveRole(int ID)
        {
            return await _roleService.RemoveRole(ID);
        }
    }
}