using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class MedicalHistory
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Allergies { get; set; } = string.Empty;

        [StringLength(50)]
        public string PreConditions { get; set; } = string.Empty;

        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }
        public Patient Patient_ { get; set; } = null!;
    }
}
