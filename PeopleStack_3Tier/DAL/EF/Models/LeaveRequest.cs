using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class LeaveRequest
    {
        [Key]
        public int LeaveRequestId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public int LeaveTypeId { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }

        [MaxLength(500)]
        public string? Reason { get; set; }

        // Pending / Approved / Rejected / Cancelled
        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending";

        // Manager / HR who approved or rejected
        public int? ApproverId { get; set; }

        public DateTime? DecisionAt { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Employee? Employee { get; set; }
        public LeaveType? LeaveType { get; set; }
        public Employee? Approver { get; set; }
    }
}
