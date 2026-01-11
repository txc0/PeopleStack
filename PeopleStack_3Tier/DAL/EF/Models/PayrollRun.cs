using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class PayrollRun
    {
        [Key]
        public int PayrollRunId { get; set; }

        [Range(1, 12)]
        public int Month { get; set; }

        [Range(2000, 2100)]
        public int Year { get; set; }

        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

        // Draft / Finalized
        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Draft";

        // Navigation
        public ICollection<Payslip> Payslips { get; set; } = new List<Payslip>();
    }
}
