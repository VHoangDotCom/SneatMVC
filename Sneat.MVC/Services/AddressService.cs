using Sneat.MVC.DAL;
using Sneat.MVC.Models.DTO.Address;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Sneat.MVC.Services
{
    public class AddressService
    {
        private readonly SneatContext _dbContext;

        public AddressService(SneatContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProvinceModel>> ListProvince()
        {
            try
            {
                var provinces = await _dbContext.Provinces
                    .Select(x =>  new ProvinceModel
                    {
                        ID = x.ID,
                        Name = x.Name,
                        Districts = _dbContext.Districts
                            .Where(y => y.ProvinceID == x.ID)
                            .Select(y => new DistrictModel 
                            {
                                ID = y.ID,
                                Name = y.Name + " - " + x.Name,
                            }).ToList(),
                    })
                    .ToListAsync();

                return provinces;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new List<ProvinceModel>();
            }
        }
    }
}