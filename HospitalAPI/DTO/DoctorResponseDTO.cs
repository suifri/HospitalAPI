namespace HospitalAPI.DTO
{
    public record DoctorResponseDTO
    {
        public Guid Id { get; set; }
        public string Qualification { get; set; }
        public string Specialization { get; set; }

        public string EmpFName { get; set; }
        public string EmpLName { get; set; }
        public DateOnly DateJoining { get; set; }
        public DateOnly DateSeparation { get; set; }
        public string EmpType { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int SSN { get; set; }

    }
}
