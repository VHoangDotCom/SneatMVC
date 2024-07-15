using Sneat.MVC.Common;
using Sneat.MVC.Models.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sneat.MVC.App_Start
{
    public class UserAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        readonly int Role1 = 0;
        readonly int Role2 = 0;
        public UserAuthenticationFilter()
        {

        }
        public UserAuthenticationFilter(int role1, int role2)
        {
            this.Role1 = role1;
            this.Role2 = role2;
        }

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            UserDetailOutputModel ss = (UserDetailOutputModel)HttpContext.Current.Session[SystemParam.SESSION_LOGIN];
            if (ss != null)
            {

            }

            else
            {
                //Chuyen ve trang dang nhap
                var routeValues = new RouteValueDictionary();
                routeValues["controller"] = "Home";
                routeValues["action"] = "Login";
                //routeValues["action"] = "LoginExpired";
                filterContext.Result = new RedirectToRouteResult(routeValues);
            }
        }

        //Runs after the OnAuthentication method  
        //------------//
        //OnAuthenticationChallenge:- if Method gets called when Authentication or Authorization is 
        //failed and this method is called after
        //Execution of Action Method but before rendering of View
        //------------//
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //We are checking Result is null or Result is HttpUnauthorizedResult 
            // if yes then we are Redirect to Error View
            /* if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
             {
                 filterContext.Result = new ViewResult
                 {
                     ViewName = "Error"
                 };
             }*/
        }
    }
}