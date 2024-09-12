using Sneat.MVC.Models.APIModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace Sneat.MVC.Controllers.API
{
    public class AuthenticationController : BaseAPIController
    {
        [HttpPost]
        public async Task<JsonResultModel> LoginWeb(string phone, string password)
        {
           return await _authenticationService.CheckLoginWeb(phone, password);
        }

        [HttpPost]
        public async Task<JsonResultModel> ForgotPasswordWeb(string email)
        {
            return await _authenticationService.ForgotPasswordWeb(email);
        }

        [HttpPost]
        public async Task<JsonResultModel> ChangePasswordWeb(int ID, string currentPass, string newPass)
        {
            return await _authenticationService.ChangePasswordWeb(ID, currentPass, newPass);
        }
    }
}