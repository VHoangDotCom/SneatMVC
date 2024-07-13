﻿using PagedList;
using Sneat.MVC.Common;
using Sneat.MVC.DAL;
using Sneat.MVC.Models.DTO.User;
using Sneat.MVC.Models.Entity;
using Sneat.MVC.Models.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Sneat.MVC.Services
{
    public class UserService
    {
        private readonly SneatContext _dbContext;

        public UserService(SneatContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IPagedList<UserDetailOutputModel>> Search(int page, int limit, string search = "")
        {
            try
            {
                search = Utils.RemoveDiacritics(search);
                var query = (from u in _dbContext.Users
                             where u.IsDeleted == SystemParam.IS_NOT_DELETED
                             orderby u.ID descending
                             select new
                             {
                                 IsDeleted = u.IsDeleted,
                                 ID = u.ID,
                                 Role = u.Role,
                                 Status = (int?)u.Status,
                                 UserName = u.UserName,
                                 Phone = u.Phone,
                                 CreateDate = u.CreatedDate,
                                 Email = u.Email,
                             })
                             .AsEnumerable()
                             .Select(u => new UserDetailOutputModel
                             {
                                 ID = u.ID,
                                 IsDeleted = u.IsDeleted,
                                 Role = u.Role,
                                 Status = (int?)u.Status,
                                 UserName = u.UserName,
                                 Phone = u.Phone,
                                 CreateDate = u.CreateDate,
                                 Email = u.Email,
                             })
                            .Where(x => string.IsNullOrEmpty(search)
                                || Utils.RemoveDiacritics(x.UserName).Contains(search)
                                || Utils.RemoveDiacritics(x.Phone).Contains(search)
                                || Utils.RemoveDiacritics(x.Email).Contains(search))
                            .ToPagedList(page, limit);
                return query;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new List<UserDetailOutputModel>().ToPagedList(1, 1);
            }
        }

        public async Task<int> CreateUser(UserInputModel input)
        {
            try
            {
                var users = await _dbContext.Users
                    .Where(x => x.IsDeleted == SystemParam.IS_NOT_DELETED)
                    .ToListAsync();

                var checkMail = users.Count(u => u.Email == input.Email);
                var checkPhone = users.Count(u => u.Phone == input.Phone);
                if (checkMail > 0)
                    return SystemParam.EMAIL_USED_ERR;
                if (checkPhone > 0)
                    return SystemParam.PHONEL_USED_ERR;

                var user = new User
                {
                    UserName = input.Name,
                    Email = input.Email,
                    Phone = input.Phone,
                    Password = Utils.GenPass(input.Password),
                    CreatedDate = DateTime.Now,
                    IsDeleted = SystemParam.IS_NOT_DELETED,
                    Status = Status.ACTIVE,
                    DistrictID = input.DistrictID,
                };
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();

                return SystemParam.RETURN_TRUE;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return SystemParam.RETURN_TRUE;
            }
        }

    }
}