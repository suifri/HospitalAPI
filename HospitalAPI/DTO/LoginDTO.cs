using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTO
{
    public class LoginDTO
    {
        [Required]
        [MaxLength(255)]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
