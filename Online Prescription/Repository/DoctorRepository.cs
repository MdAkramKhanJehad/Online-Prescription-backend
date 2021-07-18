using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Online_Prescription.Models;

namespace Online_Prescription.Repository
{
    public class DoctorRepository : DatabaseRepository
    {
        private readonly DoctorPrescriptionRepository _doctorToPrescriptionRepository = new DoctorPrescriptionRepository();
        private readonly PrescriptionRepository _prescriptionRepository = new PrescriptionRepository();
        public Doctor Add(Doctor doctor)
        {
            DatabaseContext.Doctors.Add(doctor);
            DatabaseContext.SaveChanges();
            return doctor;
        }

        public List<Doctor> GetAll()
        {
            return DatabaseContext.Doctors.ToList();
        }

        public Doctor GetById(int dId)
        {
            return DatabaseContext.Doctors.SingleOrDefault(doctor => doctor.DId == dId);

        }

        public Doctor Update(Doctor doctor)
        {
            DatabaseContext.Doctors.Update(doctor);
            DatabaseContext.SaveChanges();
            return doctor;
        }

        public bool Delete(Doctor doctor)
        {
            try
            {
                var doctorPrescription = _doctorToPrescriptionRepository.GetByDoctorId(doctor.DId);
                while (doctorPrescription != null)
                {
                    var prescriptionId = doctorPrescription.PrescriptionId;
                    var prescription = _prescriptionRepository.GetById(prescriptionId);
                    if (prescription != null)
                    {
                        _prescriptionRepository.Delete(prescription);
                    }

                    doctorPrescription = _doctorToPrescriptionRepository.GetByDoctorId(doctor.DId); ;
                }


                DatabaseContext.Doctors.Remove(doctor);
                DatabaseContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            
           
        }
    }
}
