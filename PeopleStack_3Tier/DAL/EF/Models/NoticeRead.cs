using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class NoticeRead
    {
        [Key]
        public int NoticeReadId { get; set; }

        [Required]
        public int NoticeId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public DateTime ReadAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public Notice? Notice { get; set; }
        public Employee? Employee { get; set; }
    }
}
