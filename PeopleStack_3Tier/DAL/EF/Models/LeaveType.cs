using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class LeaveType
    {
        [Key]
        public int LeaveTypeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        // Yearly allowed days (e.g., Annual = 20)
        [Range(0, 365)]
        public int YearlyQuota { get; set; }

        // Navigation
        public ICollection<LeaveRequest> LeaveRequests { get; set; } = new List<LeaveRequest>();
    }
}
