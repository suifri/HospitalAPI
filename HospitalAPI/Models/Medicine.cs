using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models
{
    public class Medicine
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [StringLength(20)]
        public string MName { get; set; } = string.Empty;
        public int MQuantity { get; set; }

        [Precision(10, 2)]
        public decimal MCost { get; set; }

        public IEnumerable<Prescription> prescriptions { get; set; } = Enumerable.Empty<Prescription>();
    }
}
