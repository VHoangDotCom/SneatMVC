using Sneat.MVC.Common;
using Sneat.MVC.Models.APIModel;
using Sneat.MVC.Models.DTO.User;
using Sneat.MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sneat.MVC.Controllers.API
{
    public class UsersController : BaseAPIController
    {
      /*  [HttpPost]
        public async Task<JsonResultModel> CreateUser(UserInputModel input)
        {
            var result = await _userService.CreateUser(input);
            if(result == SystemParam.EMAIL_USED_ERR)
                return _responseService.ErrorResult(SystemParam.EMAIL_USED_ERR_STR, SystemParam.EMAIL_USED_ERR);
        }*/
    }
}