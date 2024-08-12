using PagedList;
using Sneat.MVC.Common;
using Sneat.MVC.DAL;
using Sneat.MVC.Models.DTO.Project;
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
    public class ProjectService
    {
        private readonly SneatContext _dbContext;
        public ProjectService(SneatContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IPagedList<ProjectOutputModel>> SearchProject(int page, int limit, string search = "")
        {
            try
            {
                var list = await GetListProject(search);
                var listPaging = list.ToPagedList(page, limit);

                return listPaging;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new List<ProjectOutputModel>().ToPagedList(1, 1);
            }
        }

        public async Task<List<ProjectOutputModel>> GetListProject(string search = "")
        {
            try
            {
                search = Utils.RemoveDiacritics(search);
                var listProjects = _dbContext.Projects
                    .Where(x => x.IsDeleted == SystemParam.IS_NOT_DELETED)
                    .Select(x => new
                    {
                        x.ID,
                        x.Name, 
                        x.Status,
                        x.Description,
                        x.CreatedDate,
                        x.UpdatedDate
                    })
                    .AsEnumerable()
                    .Select(x => new ProjectOutputModel
                    {
                        ID = x.ID,
                        Name = x.Name,
                        Description = x.Description,
                        Status = (int)x.Status,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate,
                    })
                    .Where(x => string.IsNullOrEmpty(search)
                        || Utils.RemoveDiacritics(x.Name).Contains(search))
                    .ToList();

                return listProjects;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new List<ProjectOutputModel>();
            }
        }  

        public async Task<int> CreateProject(ProjectInputModel input)
        {
            try
            {
                var existedProject = await _dbContext.Projects
                    .Where(x => x.IsDeleted == SystemParam.IS_NOT_DELETED
                         && x.Name.ToLower() == input.Name.ToLower())
                    .FirstOrDefaultAsync();
                if (existedProject != null)
                    return SystemParam.EXISTED_PROJECT_NAME_ERR;

                var newProject = new Project
                {
                    Name = input.Name,
                    Description = input.Description,
                    Status = Status.ACTIVE,
                    IsDeleted = SystemParam.IS_NOT_DELETED,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };
                _dbContext.Projects.Add(newProject);

                if (input.UserIds.Count > 0)
                {
                    foreach (var id in input.UserIds)
                    {
                        var userProject = new UserProject
                        {
                            UserID = id,
                            ProjectID = newProject.ID
                        };
                        _dbContext.UserProjects.Add(userProject);
                    }
                }

                await _dbContext.SaveChangesAsync();
                return SystemParam.RETURN_TRUE;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return SystemParam.RETURN_FALSE;
            }
        }

        public async Task<int> UpdateProject(ProjectOutputModel input)
        {
            try
            {
                var existedProject = await _dbContext.Projects
                     .Where(x => x.IsDeleted == SystemParam.IS_NOT_DELETED
                          && x.Name.ToLower() == input.Name.ToLower()
                          && x.ID != input.ID)
                     .FirstOrDefaultAsync();
                if (existedProject != null)
                    return SystemParam.EXISTED_PROJECT_NAME_ERR;

                var project = await _dbContext.Projects
                    .Where(x => x.IsDeleted == SystemParam.IS_NOT_DELETED
                        && x.ID == input.ID)
                    .FirstOrDefaultAsync();
                if (project == null)
                    return SystemParam.PROJECT_NOT_FOUND_ERR;

                project.Name = input.Name;
                project.Description = input.Description;
                project.UpdatedDate = DateTime.Now;
                
                // Update user project
                _dbContext.UserProjects.RemoveRange(project.UserProjects);
                if (input.UserIds.Count > 0)
                {
                    foreach (var id in input.UserIds)
                    {
                        var userProject = new UserProject
                        {
                            UserID = id,
                            ProjectID = project.ID
                        };
                        _dbContext.UserProjects.Add(userProject);
                    }
                }

                await _dbContext.SaveChangesAsync();
                return SystemParam.RETURN_TRUE;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return SystemParam.RETURN_FALSE;
            }
        }

        public async Task<ProjectOutputModel> DetailProject(int ID)
        {
            try
            {
                var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.IsDeleted == SystemParam.IS_NOT_DELETED && x.ID == ID);
                var projectDetail = new ProjectOutputModel
                {
                    ID = ID,
                    Name = project.Name,
                    Description = project.Description,
                    Status = (int)project.Status,
                    CreatedDate = project.CreatedDate,
                    UpdatedDate = project.UpdatedDate,
                };

                return projectDetail;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new ProjectOutputModel();
            }
        }

        public async Task<int> RemoveProject(int ID)
        {
            try
            {
                var project = await _dbContext.Projects
                    .Where(x => x.ID == ID && x.IsDeleted == SystemParam.IS_NOT_DELETED)
                    .FirstOrDefaultAsync();
                if (project == null)
                    return SystemParam.PROJECT_NOT_FOUND_ERR;

                project.IsDeleted = SystemParam.IS_DELETED;
                
                await _dbContext.SaveChangesAsync();
                return SystemParam.RETURN_TRUE;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return SystemParam.RETURN_FALSE;
            }
        }

    }
}