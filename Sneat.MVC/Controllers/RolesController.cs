using Sneat.MVC.App_Start;
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
    }
}