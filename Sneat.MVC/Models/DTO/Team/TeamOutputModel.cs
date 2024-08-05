﻿using Sneat.MVC.Common;
using System;
using System.Collections.Generic;

namespace Sneat.MVC.Models.DTO.Team
{
    public class TeamInputModel
    {
        public string Name { get; set; }
        public List<int> TechStack { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }

    public class TeamOutputModel : TeamInputModel
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
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
    }
}