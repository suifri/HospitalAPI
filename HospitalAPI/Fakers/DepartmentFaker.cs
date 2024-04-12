using Bogus;
using HospitalAPI.Constants;
using HospitalAPI.Models;

namespace HospitalAPI.Fakers
{
    public class DepartmentFaker : Faker<Department>
    {
        public DepartmentFaker() 
        {
            RuleFor(d => d.Id, Guid.NewGuid());
            RuleFor(d => d.DeptHead, f => f.Name.FullName());
            RuleFor(d => d.DeptName, f => DepartmentsConstants.Departments.ElementAt(f.Random.Number(0, DepartmentsConstants.Departments.Count())));
            RuleFor(d => d.EmpCount, f => f.Random.Number(1, 25));
        }
    }
}
