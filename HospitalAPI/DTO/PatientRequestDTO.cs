namespace HospitalAPI.DTO
{
    public record PatientRequestDTO
    {
        public Guid Id { get; set; }
        public string PatientFName { get; set; }
        public string PatientLName { get; set;}

        public string Phone {  get; set;}

        public string Email { get; set;}

        public string Gender { get; set;}   

        public string AdmissionDate { get; set;}
    }
}
