using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Online_Prescription.Models;
using Online_Prescription.Repository;

namespace Online_Prescription.Controllers
{
    public class DoctorPrescriptionController : Controller
    {
        private readonly DoctorPrescriptionRepository _doctorPrescriptionRepository = new DoctorPrescriptionRepository();

        [HttpPost("api/doctorPrescription/add")]
        public IActionResult AddDoctorToPrescription([FromBody] DoctorPrescription doctorPrescription)
        {
            var addedDoctorPrescription = _doctorPrescriptionRepository.Add(doctorPrescription);
            return Ok(addedDoctorPrescription);
        }


        [HttpGet("api/doctorPrescription/getById")]
        public IActionResult GetDoctorPrescriptionById(int dId)
        {
            var doctorPrescription = _doctorPrescriptionRepository.GetById(dId);

            return Ok(doctorPrescription);
        }


        [HttpGet("api/doctorPrescription/getAll")]
        public IActionResult GetAllDoctorPrescription()
        {
            return Ok(_doctorPrescriptionRepository.GetAll());
        }


        [HttpPost("api/doctorPrescription/update")]
        public IActionResult UpdateDoctorPrescription([FromBody] DoctorPrescription doctorPrescription)
        {
            return Ok(_doctorPrescriptionRepository.Update(doctorPrescription));
        }


        [HttpGet("api/doctorPrescription/delete")]
        public IActionResult DeleteDoctorToPrescription(int dId)
        {
            var doctorPrescription = _doctorPrescriptionRepository.GetById(dId);
            _doctorPrescriptionRepository.Delete(doctorPrescription);
            return Ok(true);
        }

    }
}
