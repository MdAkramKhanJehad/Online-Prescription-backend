using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Online_Prescription.Models;
using Online_Prescription.Repository;

namespace Online_Prescription.Controllers
{
    public class AuthController: Controller
    {
        private readonly DoctorRepository _doctorRepository = new DoctorRepository();

        [HttpPost("api/login")]
        public IActionResult Login([FromBody] Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest("Invalid client request");
            }

            var doctors = _doctorRepository.GetAll();

            foreach (var doc in doctors)
            {
                if (doctor.Username != doc.Username || doctor.Password != doc.Password) continue;
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1007AksSecretKey1007"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:5002",
                    audience: "http://localhost:5002",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new {Token = tokenString});
            }

            return Unauthorized();
        }
    }
}
