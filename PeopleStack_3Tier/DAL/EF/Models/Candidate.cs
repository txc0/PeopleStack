using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }

        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? Phone { get; set; }

        // Frequency tracking fields (updated in BLL when an application is submitted)
        public int TotalApplications { get; set; } = 0;

        public DateTime? LastAppliedAt { get; set; }

        // Optional: helps HR filter quickly
        [MaxLength(50)]
        public string? CurrentStatus { get; set; } // e.g., New, Shortlisted, Hired, Rejected

        // Navigation
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}
