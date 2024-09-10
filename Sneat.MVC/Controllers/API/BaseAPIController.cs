using Sneat.MVC.DAL;
using Sneat.MVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Sneat.MVC.Controllers.API
{
    public class BaseAPIController : ApiController
    {
        protected SneatContext Context;
        public UserService _userService;
        public AddressService _addressService;
        public BankService _bankService;
        public RoleService _roleService;
        public TeamService _teamService;
        public ProjectService _projectService;
        public WorkPackageService _workPackageService;

        public AuthenticationService _authenticationService;

        public BaseAPIController() : base()
        {
            _userService = new UserService(this.GetContext());
            _addressService = new AddressService(this.GetContext());
            _bankService = new BankService(this.GetContext());
            _roleService = new RoleService(this.GetContext());
            _teamService = new TeamService(this.GetContext());
            _projectService = new ProjectService(this.GetContext());
            _workPackageService = new WorkPackageService(this.GetContext());
        }

        public SneatContext GetContext()
        {
            if (Context == null)
            {
                Context = new SneatContext();
            }
            return Context;
        }
    }
}