using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models
{
    public class Department
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string DeptHead { get; set; } = string.Empty;

        [StringLength(100)]
        public string DeptName { get; set; } = string.Empty;

        public int EmpCount { get; set; }

        public ICollection<Staff> Staffs { get; set; } = null!;
    }
}
