using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Prescription.Models;

namespace Online_Prescription.Repository
{
    public class PrescriptionRepository : DatabaseRepository
    {

        private readonly DoctorPrescriptionRepository _doctorToPrescriptionRepository = new DoctorPrescriptionRepository();

        private readonly MedicinePrescriptionRepository _medicinePrescriptionRepository = new MedicinePrescriptionRepository();


        public Prescription Add(Prescription prescription)
        {
           // prescription.DateTime = DateTime.Now;
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
            var prescriptions = DatabaseContext.Prescriptions.ToList();
             var medicinePrescriptions = _medicinePrescriptionRepository.GetAll();

             for (var i = 0; i < prescriptions.Count; i++)
             {
                 prescriptions[i].MedicineIdsList = new List<int>();
                 var ids = new List<int>();

                 for (var j = 0; j < medicinePrescriptions.Count; j++)
                 {
                     if (medicinePrescriptions[j].PrescriptionId == prescriptions[i].PId)
                     {
                         ids.Add(medicinePrescriptions[j].MedicineId);
                     }
                 }
                 ids.Sort();
                 prescriptions[i].MedicineIdsList = ids;
             }
             return prescriptions;
        }


        public Prescription GetById(int pId)
        {
            var prescription =  DatabaseContext.Prescriptions.SingleOrDefault(prescription => prescription.PId == pId);
            var medicinePrescriptions = _medicinePrescriptionRepository.GetAll();
            
            
            prescription.MedicineIdsList = new List<int>();
            var ids = new List<int>();
            foreach (var medicinePrescription in medicinePrescriptions)
            {
                if (medicinePrescription.PrescriptionId == prescription.PId)
                {
                    ids.Add(medicinePrescription.MedicineId);
                }
            }
            ids.Sort();
            prescription.MedicineIdsList = ids;

            return prescription;
        }
        

        public Prescription Update(Prescription prescription)
        {
            var medicinePrescriptions = _medicinePrescriptionRepository.GetAll();
            var id  = DatabaseContext.Prescriptions.Update(prescription);
            DatabaseContext.SaveChanges();
            var medicineIdsList = prescription.MedicineIdsList;
            
            for (var j = 0; j < medicinePrescriptions.Count; j++)
            {
                if(medicinePrescriptions[j].PrescriptionId == prescription.PId)
                {

                    if (!medicineIdsList.Contains(medicinePrescriptions[j].MedicineId))
                    {
                        _medicinePrescriptionRepository.Delete(medicinePrescriptions[j]);
                    }
                }
            }


            foreach (var medicineId in medicineIdsList)
            {
                var oldMedicinePrescription = _medicinePrescriptionRepository.GetByMedicineIdAndPrescriptionId(id.Entity.PId, medicineId);

                var medicinePrescription  = new MedicinePrescription
                {
                    PrescriptionId = id.Entity.PId,
                    MedicineId = medicineId
                };

                if (oldMedicinePrescription != null)
                {
                    medicinePrescription.Id = oldMedicinePrescription.Id;
                }
                
                
                DatabaseContext.MedicinePrescriptions.Update(medicinePrescription);
                DatabaseContext.SaveChanges();
                
            }


            var doctorPrescription = new DoctorPrescription
            {
                PrescriptionId = id.Entity.PId,
                DoctorId = id.Entity.DoctorId
            };

            DatabaseContext.DoctorPrescriptions.Update(doctorPrescription);
            DatabaseContext.SaveChanges();


            return prescription;
        }


        public bool Delete(Prescription prescription)
        {
            try
            {
                var pId = prescription.PId;
                var doctorPrescription = _doctorToPrescriptionRepository.GetByPrescriptionId(pId);

                var medicinePrescription = _medicinePrescriptionRepository.GetByPrescriptionId(pId);
                while (medicinePrescription != null)
                {
                    DatabaseContext.MedicinePrescriptions.Remove(medicinePrescription);
                    DatabaseContext.SaveChanges();
                    medicinePrescription = _medicinePrescriptionRepository.GetByPrescriptionId(pId);
                }


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
