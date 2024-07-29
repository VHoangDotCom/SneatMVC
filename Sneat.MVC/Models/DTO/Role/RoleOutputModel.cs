using System;

namespace Sneat.MVC.Models.DTO.Role
{
    public class RoleOutputModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}