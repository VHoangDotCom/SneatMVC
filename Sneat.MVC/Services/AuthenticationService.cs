﻿using Sneat.MVC.Common;
using Sneat.MVC.DAL;
using Sneat.MVC.Models.APIModel;
using Sneat.MVC.Models.DTO.User;
using Sneat.MVC.Models.Enum;
using Sneat.MVC.Templates;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Sneat.MVC.Services
{
    public class AuthenticationService
    {
        private readonly SneatContext _dbContext;
        private readonly ResponseService _responseService;
        public AuthenticationService(
            SneatContext dbContext, 
            ResponseService responseService)
        {
            _dbContext = dbContext;
            _responseService = responseService;
        }

        #region Authentication WebAdmin MVC
        public async Task<int> UserLogin(string phone, string password)
        {
            try
            {
                var user = await _dbContext.Users
                    .Where(u => u.IsDeleted == SystemParam.IS_NOT_DELETED
                        && (u.Phone.Equals(phone) || u.Email.Equals(phone)))
                    .FirstOrDefaultAsync();

                var roleIds = user.UserRoles.Select(u => u.RoleID).ToList();
                var permissionIds = await _dbContext.RolePermissions
                    .Where(rp => roleIds.Contains(rp.RoleID))
                    .Select(rp => rp.PermissionID)
                    .Distinct()
                    .ToListAsync();
                var listPermissionTabs = await _dbContext.Permissions
                    .Where(p => permissionIds.Contains(p.ID))
                    .Select(p => p.TabID)
                    .ToListAsync();

                if (user == null)
                    return SystemParam.INVALID_EMAIL_OR_PASSWORD_ERR;
                if (user.Status == Status.IN_ACTIVE)
                    return SystemParam.ACCOUNT_HAD_BEEN_BLOCKED_ERR;
                if (Utils.CheckPass(password, user.Password))
                {
                    var projectIDs = user.UserProjects
                         .Where(x => x.Project.IsDeleted == SystemParam.IS_NOT_DELETED)
                         .Select(x => x.ProjectID)
                         .ToList();
                    var userProjects = _dbContext.Projects
                            .Where(x => projectIDs.Contains(x.ID))
                            .Select(x => new ProjectUserOutputModel
                            {
                                ProjectID = x.ID,
                                ProjectName = x.Name,
                            })
                            .ToList();
                    var userDetail = new UserDetailOutputModel
                    {
                        UserName = user.UserName,
                        ID = user.ID,
                        Phone = user.Phone,
                        Email = user.Email,
                        Avatar = user.Avatar,
                        Status = (int?)user.Status,
                        PermissionTabs = listPermissionTabs,
                        ListProjects = userProjects,
                        TotalProjects = userProjects != null ? userProjects.Count : 0,
                    };
                    HttpContext.Current.Session[SystemParam.SESSION_LOGIN] = userDetail;
                    return SystemParam.RETURN_TRUE;
                }
                return SystemParam.INVALID_EMAIL_OR_PASSWORD_ERR;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return SystemParam.RETURN_FALSE;
            }
        }

        public async Task<int> ForgotPassword(string email)
        {
            try
            {
                var emailService = new EmailService();
                var user = await _dbContext.Users
                    .Where(u => u.IsDeleted == SystemParam.IS_NOT_DELETED && u.Email.Equals(email))
                    .FirstOrDefaultAsync();
                if (user == null)
                    return SystemParam.INVALID_EMAIL_ERR;

                var random = new Random();
                string newPass = random.Next(100000, 999999).ToString();
                user.Password = Utils.GenPass(newPass);
                await _dbContext.SaveChangesAsync();

                var loginUrl = Utils.getFullUrl();

                // HTML content for the email
                string htmlContent = SendMailTemplate.ForgotPasswordTemplate(user.UserName, newPass, loginUrl);

                // Send the email asynchronously
                emailService.configClient(email, SystemParam.EMAIL_TITLE, htmlContent);

                return SystemParam.RETURN_TRUE;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return SystemParam.RETURN_FALSE;
            }
        }

        public async Task<int> ChangePassword(int ID, string currentPass, string newPass)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(ID);
                if (Utils.CheckPass(currentPass, user.Password))
                {
                    user.Password = Utils.GenPass(newPass);
                    await _dbContext.SaveChangesAsync();
                    return SystemParam.RETURN_TRUE;
                }
                return SystemParam.INVALID_PASSWORD_ERR;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return SystemParam.RETURN_FALSE;
            }
        }

        #endregion

        #region Authentication WebAdmin React
        public async Task<JsonResultModel> CheckLoginWeb(string phone, string password)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ex.ToString();
                return _responseService.serverError();
            }
        }
        #endregion
    }
}