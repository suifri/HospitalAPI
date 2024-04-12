using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Models
{
    [Table("Room")]
    public class Room
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; } = null!;

        [Precision(10, 1)]
        public decimal Cost { get; set; }

        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }
        public IEnumerable<Patient> patients { get; set; } = Enumerable.Empty<Patient>();
        
    }
}
