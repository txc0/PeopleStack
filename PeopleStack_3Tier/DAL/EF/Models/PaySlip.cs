using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class Payslip
    {
        [Key]
        public int PayslipId { get; set; }

        [Required]
        public int PayrollRunId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        // Salary breakdown
        [Range(0, double.MaxValue)]
        public decimal BasicSalary { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Allowances { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Deductions { get; set; }

        [Range(0, double.MaxValue)]
        public decimal NetPay { get; set; }

        // Optional: store summary calculation info for viva/demo
        public int? PresentDays { get; set; }
        public int? AbsentDays { get; set; }
        public int? LateCount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public PayrollRun? PayrollRun { get; set; }
        public Employee? Employee { get; set; }
    }
}
