using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Payroll
    {
        [Key]
        [Required]
        public string AccountNo { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public decimal Bonus { get; set; }
        public string IBAN { get; set; } = string.Empty ;

        [ForeignKey("Staff")]
        public Guid StaffId { get; set; }
        public Staff Staff_ { get; set; } = null!;
    }
}
