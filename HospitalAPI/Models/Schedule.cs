using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Schedule
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public TimeOnly StartHour { get; set; }
        public TimeOnly EndHour { get; set;}

        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }

        public Doctor Doctor_ { get; set; } = null!;
    }
}
