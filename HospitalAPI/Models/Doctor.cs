using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Doctor
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string Qualifications { get; set; } = string.Empty;

        [StringLength(100)]
        public string Specialization {  get; set; } = string.Empty;

        public ICollection<Appointment> Appointments { get; set; } = null!;

        [ForeignKey("Staff")]
        public Guid StaffId { get; set; }
        public Staff Staff_ { get; set; } = null!;
        public ICollection<Prescription> Prescriptions { get; set; } = null!;
    }
}
