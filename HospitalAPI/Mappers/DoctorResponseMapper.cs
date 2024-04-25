using HospitalAPI.DTO;
using HospitalAPI.Models;

namespace HospitalAPI.Mappers
{
    public static class DoctorResponseMapper
    {
        public static DoctorResponseDTO Doctor2Response(Doctor source)
        {
            return new DoctorResponseDTO
            {
                Id = source.Id,
                Address = source.Staff_.Address,
                DateJoining = source.Staff_.DateJoining,
                DateSeparation = source.Staff_.DateSeparation,
                Email = source.Staff_.Email,
                EmpFName = source.Staff_.EmpFName,
                EmpLName = source.Staff_.EmpLName,
                EmpType = source.Staff_.EmpType,
                Qualification = source.Qualifications,
                Specialization = source.Specialization,
                SSN = source.Staff_.SSN
            };
        }
    }
}
