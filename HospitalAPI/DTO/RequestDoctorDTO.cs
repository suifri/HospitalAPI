namespace HospitalAPI.DTO
{
    public class RequestDoctorDTO
    {
        public string Qualification {  get; set; }
        public string Specialization { get; set; }

        public Guid ScheduleId { get; set; }

        public string EmpFName { get; set; }

        public string EmpLName { get; set; }

        public string DateJoining { get; set; }

        public string EmpType { get; set; }

        public string Email {  get; set; }

        public string Address {  get; set; }

        public int SSN { get; set; }

        public Guid DepartmentId { get; set; }

    }
}
