using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Online_Prescription.Models;
using Online_Prescription.Repository;

namespace Online_Prescription.Controllers
{
    public class MedicinePrescriptionController : Controller
    {
        private readonly MedicinePrescriptionRepository _medicinePrescriptionRepository = new MedicinePrescriptionRepository();

        [HttpPost("api/medicinePrescription/add")]
        public IActionResult AddMedicinePrescription([FromBody] MedicinePrescription medicinePrescription)
        {
            var addedMedicinePrescription = _medicinePrescriptionRepository.Add(medicinePrescription);
            return Ok(medicinePrescription);
        }


        [HttpGet("api/medicinePrescription/getByPrescriptionId")]
        public IActionResult GetMedicinePrescriptionByPrescriptionId(int pId)
        {
            var medicinePrescription = _medicinePrescriptionRepository.GetByPrescriptionId(pId);

            return Ok(medicinePrescription);
        }

        [HttpGet("api/medicinePrescription/getById")]
        public IActionResult GetMedicinePrescriptionById(int id)
        {
            var medicinePrescription = _medicinePrescriptionRepository.GetById(id);

            return Ok(medicinePrescription);
        }


        [HttpGet("api/medicinePrescription/getAll")]
        public IActionResult GetAllMedicinePrescription()
        {
            return Ok(_medicinePrescriptionRepository.GetAll());
        }


        [HttpPut("api/medicinePrescription/update")]
        public IActionResult UpdateMedicinePrescription([FromBody] MedicinePrescription medicinePrescription)
        {
            return Ok(_medicinePrescriptionRepository.Update(medicinePrescription));
        }


        [HttpDelete("api/medicinePrescription/delete")]
        public IActionResult DeleteMedicinePrescription(int id)
        {
            var medicinePrescription = _medicinePrescriptionRepository.GetById(id);

            if (medicinePrescription != null)
            {
                _medicinePrescriptionRepository.Delete(medicinePrescription);
                return Ok(true);
            }
            else
            {
                return BadRequest("MedicinePrescription object is not available");
            }
           
        }
    }
}
