using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Prescription
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Dosage { get; set; }

        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }
        public Patient Patient_ { get; set; } = null!;

        [ForeignKey("Medicine")]
        public Guid MedicineId { get; set; }
        public IEnumerable<Medicine> medicines { get; set; } = Enumerable.Empty<Medicine>();

        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }
        public Doctor Doctor_ { get; set; } = null!;
    }
}
