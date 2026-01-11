using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class NoticeTarget
    {
        [Key]
        public int NoticeTargetId { get; set; }

        [Required]
        public int NoticeId { get; set; }

        // "All" | "Department" | "Employee"
        [Required]
        [MaxLength(20)]
        public string TargetType { get; set; } = "All";

        // Used only when TargetType = "Department"
        public int? DepartmentId { get; set; }

        // Used only when TargetType = "Employee"
        public int? EmployeeId { get; set; }

        // Navigation
        public Notice? Notice { get; set; }
        public Department? Department { get; set; }
        public Employee? Employee { get; set; }
    }
}
