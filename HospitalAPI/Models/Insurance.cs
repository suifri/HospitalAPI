using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Insurance
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string PolicyNumber { get; set; } = string.Empty;

        [StringLength(50)]
        public string InsCode { get; set; } = string.Empty;

        [StringLength(50)]
        public string EndDate {  get; set; } = string.Empty;

        [StringLength(200)]
        public string Provider {  get; set; } = string.Empty;

        [Precision(10, 2)]
        public decimal Co_Pay {  get; set; }
        public bool Maternity { get; set; }
        public bool Dental { get; set; }
        public bool Optical { get; set; }

        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }
        public Patient Patient_ { get; set; } = null!;
    }
}
