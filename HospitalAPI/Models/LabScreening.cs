using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Models
{
    [Table("LabScreening")]
    public class LabScreening
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Precision(10, 2)]
        public decimal TestCost { get; set; }

        [Required]
        public DateOnly Date { get; set; }

        [ForeignKey("Patient")]
        public Guid Guid_ { get; set; }
        public Patient Patient_ { get; set; } = null!;

        [ForeignKey("Doctor")]
        public Guid DoctorId { get; set; }
        public Doctor Doctor_ { get; set; } = null!;
    }
}
