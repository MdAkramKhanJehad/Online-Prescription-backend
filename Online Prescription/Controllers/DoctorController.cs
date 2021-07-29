using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online_Prescription.Models;
using Online_Prescription.Repository;

namespace Online_Prescription.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DoctorRepository _doctorRepository = new DoctorRepository();     
        
        [HttpPost("api/doctor/add")]
        [Authorize]
        public IActionResult AddDoctor([FromBody] Doctor doctor)
        {
            var addedDoctor = _doctorRepository.Add(doctor);
            return Ok(addedDoctor);
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
 