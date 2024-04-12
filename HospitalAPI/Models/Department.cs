using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models
{
    public class Department
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [StringLength(20)]
        public string DeptHead { get; set; } = string.Empty;

        [StringLength(15)]
        public string DeptName { get; set; } = string.Empty;

        public int EmpCount { get; set; }

        public IEnumerable<Staff> Staffs { get; set; } = Enumerable.Empty<Staff>();
    }
}
