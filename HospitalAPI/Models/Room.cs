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
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Type { get; set; } = null!;

        [Precision(10, 1)]
        public decimal Cost { get; set; }

        public ICollection<RoomPatients> RoomPatients { get; set; } = null!;
    }
}
