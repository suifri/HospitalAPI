using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Doctor
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [StringLength(15)]
        public string Qualifications { get; set; } = string.Empty;

        [StringLength(20)]
        public string Specialization {  get; set; } = string.Empty;

        public IEnumerable<Appointment> Appointments { get; set; } = Enumerable.Empty<Appointment>();

        [ForeignKey("Staff")]
        public Guid StaffId { get; set; }
        public Staff Staff_ { get; set; } = null!;
        public IEnumerable<Prescription> Prescriptions { get; set; } = Enumerable.Empty<Prescription>();
    }
}
