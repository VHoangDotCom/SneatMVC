using Sneat.MVC.Common;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sneat.MVC.Controllers
{
    public class UsersController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> Search(int page, string search = "")
        {
            var result = await _userService.Search(page, SystemParam.MAX_ROW_IN_LIST_WEB, search);
            return PartialView("_ListUser", result);
        }
    }
}