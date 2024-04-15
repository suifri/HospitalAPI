using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models
{
    public class Patient
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [StringLength(200)]
        public string PatientFName { get; set; } = string.Empty;

        [StringLength(200)]
        public string PatientLName { get; set; } = string.Empty;

        [StringLength(25)]
        public string Phone { get; set; } = string.Empty;

        [StringLength(5)]
        public string BloodType { get; set; } = string.Empty;

        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(20)]
        public string Gender { get; set; } = string.Empty;

        [StringLength(60)]
        public string Condition { get; set; } = string.Empty;
        public DateTime AdmissionDate { get; set; }
        public DateTime DischargeTime { get; set; }

        public bool Rhesus {  get; set; }

        public string Diagnosis {  get; set; } = string.Empty;

        public RoomPatients RoomPatient { get; set; } = null!;

        public ICollection<Bill> bills { get; set; } = null!;

        public ICollection<Prescription> Prescriptions { get; set; } = null!;

        public ICollection<Appointment> Appointments { get; set; } = null!;

        public Insurance Insurance_ { get; set; } = null!;
    }
}
