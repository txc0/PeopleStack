using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class JobApplication
    {
        [Key]
        public int ApplicationId { get; set; }

        [Required]
        public int CandidateId { get; set; }

        [Required]
        public int JobPostId { get; set; }

        public DateTime AppliedAt { get; set; } = DateTime.UtcNow;

        // Applied / UnderReview / Shortlisted / Interview / Offered / Hired / Rejected
        [Required]
        [MaxLength(30)]
        public string ApplicationStatus { get; set; } = "Applied";

        [MaxLength(1000)]
        public string? Notes { get; set; }

        // Navigation
        public Candidate? Candidate { get; set; }
        public JobPost? JobPost { get; set; }
    }
}
