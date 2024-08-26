using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Sneat.MVC.Models.Enum;
using System;

namespace Sneat.MVC.Models.Entity
{
    public class WorkPackage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Subject { get; set; }
        public WorkPackageType Type { get; set; }
        public WorkPackageStatus Status { get; set; }
        public int? EstimateTime { get; set; }
        public int? SpentTime { get; set; }
        public int? RemainingTime { get; set; }
        public int? CompletePercent { get; set; }
        public int? PriorityPoint { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int IsDeleted { get; set; }
    }
}