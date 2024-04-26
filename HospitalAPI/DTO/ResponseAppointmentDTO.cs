namespace HospitalAPI.DTO
{
    public record ResponseAppointmentDTO
    {
        public Guid Id { get; set; }

        public DateTime ScheduledOn { get; set; }
        public DateOnly Date {  get; set; }
        public TimeOnly Time { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
    }
}
