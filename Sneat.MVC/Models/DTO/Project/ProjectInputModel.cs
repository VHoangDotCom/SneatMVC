using Sneat.MVC.Models.Enum;
using System;

namespace Sneat.MVC.Models.DTO.Project
{
    public class ProjectInputModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ProjectOutputModel : ProjectInputModel
    {
        public int ID { get; set; }
        public int? Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}