using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Online_Prescription.Models;
using Online_Prescription.Repository;

namespace Online_Prescription.Controllers
{

    public class DoctorController : Controller
    {
        private readonly DoctorRepository _doctorRepository = new DoctorRepository();     
        
        [HttpPost("api/doctor/add")]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            var addedDoctor = _doctorRepository.Add(doctor);
            
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
            return Ok(new { Token = tokenString });

            //return Ok(addedDoctor);
        }


        [HttpGet("api/doctor/getById")]
        [Authorize]
        public IActionResult GetDoctorById(int dId)
        {
            var doctor = _doctorRepository.GetById(dId);

            return Ok(doctor);
        }


        [HttpGet("api/doctor/getAll")]
        [Authorize]
        public IActionResult GetAllDoctors()
        {
            return Ok(_doctorRepository.GetAll());
        }


        [HttpPut("api/doctor/update")]
        [Authorize]
        public IActionResult UpdateDoctor([FromBody] Doctor doctor)
        {
            return Ok(_doctorRepository.Update(doctor));
        }


        [HttpDelete("api/doctor/delete")]
        [Authorize]
        public IActionResult DeleteDoctor(int dId)
        {
            var doctor = _doctorRepository.GetById(dId);
            if (doctor != null)
            {
                _doctorRepository.Delete(doctor);
                return Ok(true);
            }
            else
            {
                return BadRequest("Invalid Doctor ID, object not available");
            }
            
        }
    }
}
 