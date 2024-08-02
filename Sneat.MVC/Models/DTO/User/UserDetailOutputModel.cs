using Sneat.MVC.Common;
using Sneat.MVC.Models.DTO.Permission;
using System;
using System.Collections.Generic;

namespace Sneat.MVC.Models.DTO.User
{
    public class UserDetailOutputModel
    {
        public int ID { get; set; }
        public int? Status { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Avatar { get; set; }
        public DateTime? CreateDate { set; get; }
        public string CreateDateStr
        {
            set { }
            get
            {
                return CreateDate.HasValue ? CreateDate.Value.ToString(SystemParam.CONVERT_DATETIME) : "";
            }
        }
        public DateTime? Dob { get; set; }
        public string DobSTR
        {
            get
            {
                return Dob.HasValue ? Dob.Value.ToString(SystemParam.CONVERT_DATETIME) : "";
            }
        }
        public int IsDeleted { get; set; }
        public int? Sex { get; set; }
        public int? ProvinceID { get; set; }
        public int? DistrictID { get; set; }
        public string StatusStr
        {
            get
            {
                switch (Status)
                {
                    case SystemParam.ACTIVE:
                        return SystemParam.STATUS_ACTIVE_STR;
                    case SystemParam.IN_ACTIVE:
                        return SystemParam.STATUS_IN_ACTIVE_STR;
                    default:
                        return "Undefined Status";
                }
            }
        }
        public List<string> PermissionTabs { get; set; }
    }
}