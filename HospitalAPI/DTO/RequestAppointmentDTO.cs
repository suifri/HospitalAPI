namespace HospitalAPI.DTO
{
    public record RequestAppointmentDTO
    {
        public string PatientEmail { get; set; }
        public string DoctorName { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }
    }
}
