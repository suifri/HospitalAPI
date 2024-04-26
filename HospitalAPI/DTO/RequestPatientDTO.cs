namespace HospitalAPI.DTO
{
    public record RequestPatientDTO
    {
        public string PatientFName { get; set; }
        public string PatientLName { get; set; }
        public string Phone {  get; set; }
        public string BloodType { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Condition { get; set; }
        public bool Rhesus {  get; set; }

        public string Password { get; set; }

    }
}
