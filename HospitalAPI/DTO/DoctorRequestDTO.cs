namespace HospitalAPI.DTO
{
    public class DoctorRequestDTO
    {
        public Guid Id { get; set; }
        public Guid DepartmentID { get; set; }
        public string EmpFName { get; set; }
        public string EmpLName { get; set; }
        public string DateJoining { get; set; }

        public string EmpType { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }

        public string SSN { get; set; }

        public Guid ScheduleId { get; set; }

        public string Qualifications { get; set; }

        public string Specialization { get; set; }
    }
}
