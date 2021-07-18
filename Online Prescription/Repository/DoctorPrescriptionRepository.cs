using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Prescription.Models;

namespace Online_Prescription.Repository
{
    public class DoctorPrescriptionRepository : DatabaseRepository
    {
        
        public DoctorPrescription Add(DoctorPrescription doctorPrescription)
        {
            DatabaseContext.DoctorPrescriptions.Add(doctorPrescription);
            DatabaseContext.SaveChanges();
            return doctorPrescription;
        }

        public List<DoctorPrescription> GetAll()
        {
            return DatabaseContext.DoctorPrescriptions.ToList();
        }

        public DoctorPrescription GetById(int prescriptionId)
        {
            return DatabaseContext.DoctorPrescriptions.FirstOrDefault(doctorPrescription =>
                doctorPrescription.PrescriptionId == prescriptionId);
        }

        public DoctorPrescription Update(DoctorPrescription doctorPrescription)
        {
            DatabaseContext.DoctorPrescriptions.Update(doctorPrescription);
            DatabaseContext.SaveChanges();
            return doctorPrescription;
        }

        public bool Delete(DoctorPrescription doctorPrescription)
        {
            try
            {
                DatabaseContext.DoctorPrescriptions.Remove(doctorPrescription);
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
