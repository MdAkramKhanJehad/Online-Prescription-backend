using Microsoft.AspNetCore.Mvc;
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
            return Ok(addedDoctor);
        }


        [HttpGet("api/doctor/getById")]
        public IActionResult GetDoctorById(int dId)
        {
            var doctor = _doctorRepository.GetById(dId);

            return Ok(doctor);
        }


        [HttpGet("api/doctor/getAll")]
        public IActionResult GetAllDoctors()
        {
            return Ok(_doctorRepository.GetAll());
        }


        [HttpPost("api/doctor/update")]
        public IActionResult UpdateDoctor([FromBody] Doctor doctor)
        {
            return Ok(_doctorRepository.Update(doctor));
        }


        [HttpGet("api/doctor/delete")]
        public IActionResult DeleteDoctor(int dId)
        {
            var doctor = _doctorRepository.GetById(dId);
            _doctorRepository.Delete(doctor);
            return Ok(true); 
        }
    }
}
 