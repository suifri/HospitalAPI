using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models
{
    public class RoomPatients
    {
        [Required]
        public Guid PatientId { get; set; }

        [Required]
        public Guid RoomId { get; set; }

        public Patient Patient { get; set; } = null!;
        public Room Room { get; set; } = null!;
    }
}
