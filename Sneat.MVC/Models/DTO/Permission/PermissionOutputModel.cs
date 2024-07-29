using Sneat.MVC.Models.Common;
using System.Collections.Generic;

namespace Sneat.MVC.Models.DTO.Permission
{
    public class PermissionOutputModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? Level { get; set; }
        public int? IsLeaf { get; set; }
        public int? ParentID { get; set; }
    }

    public class PermissionTreeModel
    {
        public long Id => 0;
        public string Code => "Root";
        public string Name => "Root";
        public bool IsLeaf => false;
        public IEnumerable<TreeItem<PermissionOutputModel>> Childrens { get; set; }
    }
}