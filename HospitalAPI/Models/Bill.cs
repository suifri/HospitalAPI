using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Models
{
    [Table("Bill")]
    public class Bill
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Precision(10, 2)]
        public decimal RoomCost { get; set; }

        [Precision(10, 2)]  
        public decimal TestCost { get; set;}

        [Precision(10, 2)]
        public decimal OtherCharges { get; set; }

        [Precision(10, 2)]
        public decimal MedicineCost { get; set;}

        [Precision(10, 2)]
        public decimal Total { get; set; }

        [ForeignKey("Patient")]
        public Guid PatientId { get; set; }
        public Patient Patient_ { get; set; } = null!;
    }
}
