using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Nurse
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }

        public IEnumerable<Patient> Patients { get; set; } = Enumerable.Empty<Patient>();

        [ForeignKey("Staff")]
        public Guid StaffId { get; set; }
        public Staff Staff_ { get; set; } = null!;
    }
}
