using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class JobPost
    {
        [Key]
        public int JobPostId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(2000)]
        public string? Description { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public DateTime OpenDate { get; set; } = DateTime.UtcNow.Date;
        public DateTime? CloseDate { get; set; }

        // Open / Closed / OnHold
        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Open";

        // Navigation
        public Department? Department { get; set; }
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}
