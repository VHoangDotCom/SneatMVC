using System;

namespace Sneat.MVC.Models.DTO.WorkPackage
{
    public class WorkPackageInputModel
    {
        public string Subject { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public int? EstimateTime { get; set; }
        public int? SpentTime { get; set; }
        public int? RemainingTime { get; set; }
        public int? PriorityPoint { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Description { get; set; }

    }

    public class WorkPackageOutputModel : WorkPackageInputModel
    {
        public int ID { get; set; }
    }
}