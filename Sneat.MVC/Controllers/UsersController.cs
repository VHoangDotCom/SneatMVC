using Sneat.MVC.App_Start;
using Sneat.MVC.Common;
using Sneat.MVC.Models.DTO.User;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sneat.MVC.Controllers
{
    public class UsersController : BaseController
    {
        [UserAuthenticationFilter]
        public ActionResult Index()
        {
            return View();
        }

        [UserAuthenticationFilter]
        public async Task<PartialViewResult> Search(int page, string search = "")
        {
            var result = await _userService.Search(page, SystemParam.MAX_ROW_IN_LIST_WEB, search);
            return PartialView("_ListUser", result);
        }

        [UserAuthenticationFilter]
        public async Task<ActionResult> Create()
        {
            ViewBag.ListProvince = await _addressService.ListProvince();
            ViewBag.ListBank = await _bankService.GetListBanks();
            return View();
        }

        [HttpPost]
        public async Task<int> CreateUser(UserInputModel input)
        {
            UserDetailOutputModel userLogin = UserLogins;
            return await _userService.CreateUser(input);
        }

        [UserAuthenticationFilter]
        [HttpGet]
        public async Task<ActionResult> Update(int ID)
        {
            ViewBag.ListProvince = await _addressService.ListProvince();
            ViewBag.ListBank = await _bankService.GetListBanks();
            var userDetail = await _userService.DetailUser(ID);
            return View(userDetail);
        }

        [UserAuthenticationFilter]
        [HttpGet]
        public async Task<ActionResult> UserProfile(int? ID)
        {
            var userDetail = await _userService.DetailUser((int)ID);
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

        [HttpPost]
        public async Task<int> DeactiveUser(int ID)
        {
            return await _userService.ChangeUserStatus(ID, SystemParam.IN_ACTIVE);
        }

        [HttpPost]
        public async Task<int> ActivateUser(int ID)
        {
            return await _userService.ChangeUserStatus(ID, SystemParam.ACTIVE);
        }

        [HttpPost]
        public async Task<int> ChangePassword(string currentPass, string newPass)
        {
            UserDetailOutputModel userLogin = UserLogins;
            return await _userService.ChangePassword(userLogin.ID, currentPass, newPass);
        }

    }
}