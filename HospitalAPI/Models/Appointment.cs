using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        public DateTime ScheduledOn { get; set; }

        public DateOnly Date {  get; set; }

        public TimeOnly Time { get; set; }

        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }
        public Patient Patient_ { get; set; } = null!;

        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }

        public Doctor Doctor_ { get; set; } = null!;

    }
}
