using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Prescription.Models;

namespace Online_Prescription.Repository
{
    public class PrescriptionRepository : DatabaseRepository
    {

        private readonly DoctorPrescriptionRepository _doctorToPrescriptionRepository = new DoctorPrescriptionRepository();

        private readonly MedicinePrescriptionRepository _medicinePrescriptionRepository = new MedicinePrescriptionRepository();


        public Prescription Add(Prescription prescription)
        {
            prescription.DateTime = DateTime.Now;
            var id = DatabaseContext.Prescriptions.Add(prescription);
            DatabaseContext.SaveChanges();


            var medicineIdsList = prescription.MedicineIdsList;
            foreach (var medicineId in medicineIdsList)
            {
                var medicinePrescription = new MedicinePrescription
                {
                    PrescriptionId = id.Entity.PId,
                    MedicineId = medicineId
                };
                DatabaseContext.MedicinePrescriptions.Add(medicinePrescription);
                DatabaseContext.SaveChanges();
            }


            var doctorPrescription = new DoctorPrescription
            {
                PrescriptionId = id.Entity.PId,
                DoctorId = id.Entity.DoctorId
            };

            DatabaseContext.DoctorPrescriptions.Add(doctorPrescription);
            DatabaseContext.SaveChanges();

            return prescription;
        }


        public List<Prescription> GetAll()
        {
            return DatabaseContext.Prescriptions.ToList();
        }


        public Prescription GetById(int pId)
        {
            return DatabaseContext.Prescriptions.SingleOrDefault(prescription => prescription.PId == pId);
        }
        

        public Prescription Update(Prescription prescription)
        {
            DatabaseContext.Prescriptions.Update(prescription);
            DatabaseContext.SaveChanges();
            return prescription;
        }


        public bool Delete(Prescription prescription)
        {
            try
            {
                var id = prescription.PId;
                var doctorPrescription = _doctorToPrescriptionRepository.GetById(id);
                    
                
                DatabaseContext.Prescriptions.Remove(prescription);
                DatabaseContext.SaveChanges();
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
