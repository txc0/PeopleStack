using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string? Description { get; set; }

        // Navigation
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>(); // Recruitment module
    }
}
