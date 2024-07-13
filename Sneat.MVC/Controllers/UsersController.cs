using Sneat.MVC.Common;
using Sneat.MVC.Models.DTO.User;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sneat.MVC.Controllers
{
    public class UsersController : BaseController
    {
        public string fullUrl = Utils.getFullUrl();
        public ActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> Search(int page, string search = "")
        {
            var result = await _userService.Search(page, SystemParam.MAX_ROW_IN_LIST_WEB, search);
            return PartialView("_ListUser", result);
        }

        public ActionResult Create()
        {
            ViewBag.ServerUrl = fullUrl;
            return View();
        }

        [HttpPost]
        public async Task<int> CreateUser(UserInputModel input)
        {
            UserDetailOutputModel userLogin = UserLogins;
            return await _userService.CreateUser(input);
        }
    }
}