using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models
{
    public class Patient
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [StringLength(20)]
        public string PatientFName { get; set; } = string.Empty;

        [StringLength(20)]
        public string PatientLName { get; set; } = string.Empty;

        [StringLength(25)]
        public string Phone { get; set; } = string.Empty;

        [StringLength(5)]
        public string BloodType { get; set; } = string.Empty;

        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        [StringLength(20)]
        public string Gender { get; set; } = string.Empty;

        [StringLength(30)]
        public string Condition { get; set; } = string.Empty;
        public DateTime AdmissionDate { get; set; }
        public DateTime DischargeTime { get; set; }

        public Room Room_ { get; set; } = null!;

        public IEnumerable<Bill> bills { get; set; } = Enumerable.Empty<Bill>();

        public IEnumerable<Prescription> Prescriptions { get; set; } = Enumerable.Empty<Prescription>();

        public IEnumerable<Appointment> Appointments { get; set; } = Enumerable.Empty<Appointment>();

        public Insurance Insurance_ { get; set; } = null!;
    }
}
