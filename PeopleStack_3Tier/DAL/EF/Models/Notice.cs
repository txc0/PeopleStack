using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class Notice
    {
        [Key]
        public int NoticeId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(4000)]
        public string Content { get; set; } = string.Empty;

        // Who created it (Admin/HR/Manager)
        [Required]
        public int CreatedByEmployeeId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // If set, notice becomes inactive after this time
        public DateTime? ExpiresAt { get; set; }

        // Pin important notices to top
        public bool IsPinned { get; set; } = false;

        // 1 = Low, 2 = Normal, 3 = High (simple, can be enum later)
        [Range(1, 3)]
        public int Priority { get; set; } = 2;

        // Navigation
        public Employee? CreatedByEmployee { get; set; }

        public ICollection<NoticeTarget> Targets { get; set; } = new List<NoticeTarget>();
        public ICollection<NoticeRead> Reads { get; set; } = new List<NoticeRead>();
    }
}
