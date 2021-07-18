using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Prescription.Models;

namespace Online_Prescription.Repository
{
    public class DoctorRepository : DatabaseRepository
    {
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
