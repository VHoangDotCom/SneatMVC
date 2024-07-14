using Sneat.MVC.Common;
using Sneat.MVC.Models.DTO.User;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<int> CreateUser(UserInputModel input)
        {
            UserDetailOutputModel userLogin = UserLogins;
            return await _userService.CreateUser(input);
        }

        [HttpGet]
        public async Task<ActionResult> Update(int ID)
        {
            var userDetail = await _userService.DetailUser(ID);
            return View(userDetail);
        }

        [HttpPost]
        public async Task<int> UpdateUser(UpdateUserInputModel input)
        {
            return await _userService.UpdateUser(input);
        }

        [HttpPost]
        public async Task<int> DeleteUser(int ID)
        {
            return await _userService.DeleteUser(ID);
        }
    }
}