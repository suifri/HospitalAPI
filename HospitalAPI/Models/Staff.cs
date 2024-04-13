using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Staff
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [StringLength(20)]
        public string EmpFName { get; set; } = string.Empty;

        [StringLength(20)]
        public string EmpLName { get; set; } = string.Empty;
        public DateOnly DateJoining { get; set; }
        public DateOnly DateSeparation { get; set; }

        [StringLength(15)]
        public string EmpType { get; set; } = string.Empty;

        [StringLength(50)]
        public string Email {  get; set; } = string.Empty;

        [StringLength(50)]
        public string Address { get; set; } = string.Empty;
        public int SSN { get; set; }

        public Doctor Doctor_ { get; set; } = null!;
        public Payroll Payroll_ { get; set; } = null!;

        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }
        public Department Department_ { get; set; } = null!;
    }
}
