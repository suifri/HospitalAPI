using Bogus;
using HospitalAPI.Constants;
using HospitalAPI.Contexts;
using HospitalAPI.DTO;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HospitalAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController(HospitalContext context,
        UserManager<HospitalUser> userManager,
        SignInManager<HospitalUser> signInManager,
        IConfiguration configuration,
        IDoctorRepository doctorRepository,
        IPatientRepository patientRepository
        ) : ControllerBase
    {

        [Authorize(Roles = RoleNames.Administrator)]
        [HttpPost]
        public async Task<IActionResult> RegisterExistingUsers()
        {
            var patients = await patientRepository.GetAll();

            foreach (var patient in patients)
            {
                var newUser = new HospitalUser() { UserName = patient.PatientFName + patient.PatientLName, Email = patient.Email };
                await userManager.CreateAsync(newUser, new Faker().Internet.Password());

                var search = await userManager.FindByNameAsync(newUser.UserName);
                if (search is not null)
                    await userManager.AddToRoleAsync(search, RoleNames.Patient);
            }

            var doctors = await doctorRepository.GetAll();

            foreach (var doctor in doctors)
            {
                var newUser = new HospitalUser() { UserName = doctor.Staff_.EmpFName + doctor.Staff_.EmpLName, Email = doctor.Staff_.Email };
                var result = await userManager.CreateAsync(newUser, new Faker().Internet.Password());

                var search = await userManager.FindByNameAsync(newUser.UserName);
                if (search is not null)
                    await userManager.AddToRoleAsync(search, RoleNames.Doctor);
            }

            var administrator = new { Name = "Illia", FName = "Khveshchuk", Email = "illiaKhveshchuk@gmail.com" };

            var hospitalAdministrator = new HospitalUser() { UserName = administrator.Name + administrator.FName, Email = administrator.Email };

            await userManager.CreateAsync(hospitalAdministrator, "Db1488htry");

            var search_ = await userManager.FindByNameAsync("IlliaKhveshchuk");

            await userManager.AddToRoleAsync(search_, RoleNames.Administrator);

            return StatusCode(201);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var user = new HospitalUser();
                    user.UserName = registerDTO.UserName;
                    user.Email = registerDTO.Email;

                    var result = await userManager.CreateAsync(user, registerDTO.Password);

                    if (result.Succeeded)
                    {
                        return StatusCode(201, $"User '{user.UserName}' has been created.");
                    }
                    else
                        throw new Exception(string.Format("Error: {0}", string.Join(" ", result.Errors.Select(e => e.Description))));
                }
                else
                {
                    var details = new ValidationProblemDetails(ModelState);
                    details.Type =
                    "https://tools.ietf.org/html/rfc7231#section-6.5.1";
                    details.Status = StatusCodes.Status400BadRequest;
                    return new BadRequestObjectResult(details);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(loginDTO.Email);

                    if (user == null || !await userManager.CheckPasswordAsync(user, loginDTO.Password))
                        throw new Exception("Invalid login attempt.");
                    else
                    {
                        var signingCredantials = new SigningCredentials(new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"])),
                            SecurityAlgorithms.HmacSha256);

                        var claims = new List<Claim>();

                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));

                        claims.AddRange((await userManager.GetRolesAsync(user)).Select(r => new Claim(ClaimTypes.Role, r)));

                        var jwtObject = new JwtSecurityToken(
                            issuer: configuration["JWT:Issuer"],
                            audience: configuration["JWT:Audience"],
                            claims: claims,
                            expires: DateTime.Now.AddSeconds(300),
                            signingCredentials: signingCredantials
                            );

                        var jwtString = new JwtSecurityTokenHandler().WriteToken(jwtObject);

                        return StatusCode(StatusCodes.Status200OK, jwtString);
                    }
                }
                else
                {
                    var details = new ValidationProblemDetails(ModelState);
                    details.Type =
                    "https://tools.ietf.org/html/rfc7231#section-6.5.1";
                    details.Status = StatusCodes.Status400BadRequest;
                    return new BadRequestObjectResult(details);

                }
            }
            catch  
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
        }
    }
}
