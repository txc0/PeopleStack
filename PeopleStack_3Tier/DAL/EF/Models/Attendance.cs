using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class Attendance
    {
        [Key]
        public int AttendanceId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }

        // Total worked minutes for the day (calculated in BLL)
        public int WorkedMinutes { get; set; }

        // Navigation
        public Employee? Employee { get; set; }
    }
}
