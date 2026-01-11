using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? Phone { get; set; }

        [Required]
        public DateTime JoiningDate { get; set; } = DateTime.UtcNow.Date;

        // Active / Inactive (simple; can be enum later)
        public bool IsActive { get; set; } = true;

        // Payroll-related (you can expand later)
        [Range(0, double.MaxValue)]
        public decimal BaseSalary { get; set; } = 0;

        // FKs
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }

        // Self-reference (Manager)
        public int? ManagerId { get; set; }

        // Navigation
        public Department? Department { get; set; }
        public Designation? Designation { get; set; }

        public Employee? Manager { get; set; }
        public ICollection<Employee> Subordinates { get; set; } = new List<Employee>();

        // Navigation to modules
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();

        public ICollection<Notice> NoticesCreated { get; set; } = new List<Notice>();
        public ICollection<NoticeRead> NoticeReads { get; set; } = new List<NoticeRead>();


        public ICollection<Payslip> Payslips { get; set; } = new List<Payslip>();
    }
}
