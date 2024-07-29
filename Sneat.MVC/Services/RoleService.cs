﻿using PagedList;
using Sneat.MVC.Common;
using Sneat.MVC.DAL;
using Sneat.MVC.Models.Common;
using Sneat.MVC.Models.DTO.Permission;
using Sneat.MVC.Models.DTO.Role;
using Sneat.MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Sneat.MVC.Services
{
    public class RoleService
    {
        private readonly SneatContext _dbContext;

        public RoleService(SneatContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Role management

        public async Task<IPagedList<RoleOutputModel>> SearchRole(int page, int limit, string search = "")
        {
            try
            {
                search = Utils.RemoveDiacritics(search);
                var query = _dbContext.Roles
                    .Where(x => x.IsDeleted == SystemParam.IS_NOT_DELETED)
                    .Select(x => new
                    {
                        x.ID,
                        x.Name,
                        x.Description,
                        x.CreatedDate,
                        x.UpdatedDate
                    })
                    .AsEnumerable()
                    .Select(x => new RoleOutputModel
                    {
                        ID = x.ID,
                        Name = x.Name,
                        Description = x.Description,
                        CreatedDate = x.CreatedDate,
                        UpdatedDate = x.UpdatedDate
                    })
                    .Where(x => string.IsNullOrEmpty(search)
                        || Utils.RemoveDiacritics(x.Name).Contains(search)
                    )
                    .ToPagedList(page, limit);
                    
                return query;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new List<RoleOutputModel>().ToPagedList(1, 1);
            }
        }

        #endregion

        #region Permission management

        public async Task<PermissionTreeModel> GetAllPermissions()
        {
            try
            {
                var listPermission = await _dbContext.Permissions
                    .Where(x => x.IsDeleted == SystemParam.IS_NOT_DELETED)
                    .ToListAsync();
                var listTreePermission = listPermission
                    .Select(x => new PermissionOutputModel
                    {
                        ID = x.ID,
                        Name = x.Name,
                        Level = x.Level,
                        IsLeaf = x.IsLeaf,
                        ParentID = x.ParentID,
                    })
                    .ToList();

                var listPermissionIds = listPermission.Select(x => x.ID).ToList();
                var resultIds = new List<int>();

                foreach ( var id in listPermissionIds )
                {
                    resultIds.AddRange(GetAllNodeAndLeafIdById(id, listPermission, 1));
                }
                resultIds = resultIds.Distinct().ToList();
                var filteredTreePermission = new PermissionTreeModel
                {
                    Childrens = listTreePermission
                        .Where(x => resultIds.Contains(x.ID))
                        .ToList()
                        .GenerateTree(c => c.ID, c => c.ParentID),
                };

                return filteredTreePermission;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return new PermissionTreeModel();
            }
        }

        public List<int> GetAllNodeAndLeafIdById(int Id, List<Permission> list, int isGetParent = 0)
        {
            var listIds = new List<int>();
            var PC = list.Where(x => x.ID == Id).FirstOrDefault();
            if(PC.IsLeaf == SystemParam.ACTIVE || isGetParent == SystemParam.ACTIVE)
            {
                listIds.AddRange(GetAllParentId(PC.ID, list));
            }
            if(PC.IsLeaf == SystemParam.ACTIVE)
            {
                listIds.Add(PC.ID);
            }
            else
            {
                listIds.Add(PC.ID);
                var listPCs = list.Where(x => x.ParentID == Id).ToList();
                foreach (var child in listPCs)
                {
                    listIds.AddRange(GetAllChildId(child.ID, list));
                }
            }
            return listIds;
        }

        public List<int> GetAllParentId(int Id, List<Permission> list)
        {
            var result = new List<int>();
            var item = list.Where(x => x.ID == Id).FirstOrDefault();
            if(item == null) { return result; }
            if(item != null && item.ParentID.HasValue)
            {
                result.AddRange(GetAllParentId((int)item.ParentID, list));
            }
            result.Add((int)item.ID);
            return result;
        }

        public List<int> GetAllChildId(int Id, List<Permission> list)
        {
            var result = new List<int>();
            result.Add(Id);
            var items = list.Where(x => x.ParentID == Id).Select(x => x.ID).ToList();
            if (items.Count > 0) { result.AddRange(items); }
            items.ForEach(x =>
            {
                result.AddRange(GetAllChildId(x, list));
            });
            return result;
        }

        #endregion

    }
}