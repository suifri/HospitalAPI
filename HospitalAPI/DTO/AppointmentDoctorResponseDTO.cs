namespace HospitalAPI.DTO
{
    public record AppointmentDoctorResponseDTO
    {
        public DateOnly Date {  get; set; }
        public TimeOnly Time { get; set; }
        public string PatientName { get; set; }
    }
}
