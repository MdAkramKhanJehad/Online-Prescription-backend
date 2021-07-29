using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Online_Prescription.Models;
using Online_Prescription.Repository;

namespace Online_Prescription.Controllers
{
    public class PrescriptionController : Controller
    {
        private readonly PrescriptionRepository _prescriptionRepository = new PrescriptionRepository();


        [HttpPost("api/prescription/add")]
        public IActionResult AddPrescription([FromBody] Prescription prescription)
        {
            var addedPrescription = _prescriptionRepository.Add(prescription);
            return Ok(addedPrescription);
        }



        [HttpGet("api/prescription/getById")]
        public IActionResult GetPrescriptionById(int pId)
        {
            var prescription = _prescriptionRepository.GetById(pId);

            return Ok(prescription);
        }


        [HttpGet("api/prescription/getAll")]
        public IActionResult GetAllPrescriptions()
        {
            return Ok(_prescriptionRepository.GetAll());
        }


        [HttpPut("api/prescription/update")]
        public IActionResult UpdatePrescription([FromBody] Prescription prescription)
        {
            return Ok(_prescriptionRepository.Update(prescription));
        }


        [HttpDelete("api/prescription/delete")]
        public IActionResult DeletePrescription(int pId)
        {
            var prescription = _prescriptionRepository.GetById(pId);
            if (prescription != null)
            {
                _prescriptionRepository.Delete(prescription);
                return Ok(true);
            }
            else
            {
                return BadRequest("Invalid Prescription ID, object not available");
            }
               
        }
    }
}
