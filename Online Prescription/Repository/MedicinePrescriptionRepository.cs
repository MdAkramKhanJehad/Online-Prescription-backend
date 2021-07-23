using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Prescription.Models;

namespace Online_Prescription.Repository
{
    public class MedicinePrescriptionRepository : DatabaseRepository
    {
        public MedicinePrescription Add(MedicinePrescription doctorPrescription)
        {
            DatabaseContext.MedicinePrescriptions.Add(doctorPrescription);
            DatabaseContext.SaveChanges();
            return doctorPrescription;
        }

        public List<MedicinePrescription> GetAll()
        {
            return DatabaseContext.MedicinePrescriptions.ToList();
        }

        public MedicinePrescription GetByPrescriptionId(int prescriptionId)
        {
            return DatabaseContext.MedicinePrescriptions.FirstOrDefault(medicinePrescription =>
                medicinePrescription.PrescriptionId == prescriptionId);
        }

        public MedicinePrescription GetByMedicineIdAndPrescriptionId(int prescriptionId, int medicineId)
        {
            var oldMedicinePrescription = DatabaseContext.MedicinePrescriptions.FirstOrDefault(medPrescription =>
                            medPrescription.PrescriptionId == prescriptionId && medPrescription.MedicineId == medicineId);

            
            return oldMedicinePrescription;
           
           
        }
        public MedicinePrescription GetById(int id)
        {
            return DatabaseContext.MedicinePrescriptions.FirstOrDefault(medicinePrescription =>
                medicinePrescription.Id == id);
        }

        public MedicinePrescription Update(MedicinePrescription doctorPrescription)
        {
            DatabaseContext.MedicinePrescriptions.Update(doctorPrescription);
            DatabaseContext.SaveChanges();
            return doctorPrescription;
        }

        public bool Delete(MedicinePrescription doctorPrescription)
        {
            try
            {
                DatabaseContext.MedicinePrescriptions.Remove(doctorPrescription);
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
