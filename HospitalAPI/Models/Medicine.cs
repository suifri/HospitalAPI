using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models
{
    public class Medicine
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string MName { get; set; } = string.Empty;
        public int MQuantity { get; set; }

        [Precision(10, 2)]
        public decimal MCost { get; set; }
        public int MDosage { get; set; }

        public int MAmount { get; set; }

        public ICollection<Prescription> prescriptions { get; set; } = null!;
    }
}
