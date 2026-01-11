using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class Designation
    {
        [Key]
        public int DesignationId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        // Optional: used for payroll grading, hierarchy, etc.
        public int? GradeLevel { get; set; }

        // Navigation
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
