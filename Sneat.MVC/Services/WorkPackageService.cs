using Sneat.MVC.DAL;
using Sneat.MVC.Models.DTO.WorkPackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Sneat.MVC.Services
{
    public class WorkPackageService
    {
        private readonly SneatContext _dbContext;
        public WorkPackageService(SneatContext dbContext)
        {
            _dbContext = dbContext;
        }

       /* public async Task<List<WorkPackageOutputModel>> GetListWorkPackage(string search = "")
        {

        }*/
    }
}