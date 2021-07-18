using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Online_Prescription.Models;

namespace Online_Prescription.Repository
{
    public class MedicineRepository : DatabaseRepository
    {
        public Medicine Add(Medicine medicine)
        {
            DatabaseContext.Medicines.Add(medicine);
            DatabaseContext.SaveChanges();
            return medicine;
        }

        public List<Medicine> GetAll()
        {
            return DatabaseContext.Medicines.ToList();
        }

        public Medicine GetById(int mId)
        {
            return DatabaseContext.Medicines.SingleOrDefault(medicine => medicine.MId == mId);
        }

        public Medicine Update(Medicine medicine)
        {
            DatabaseContext.Medicines.Update(medicine);
            DatabaseContext.SaveChanges();
            return medicine;
        }

        public bool Delete(Medicine medicine)
        {
            try
            {
                DatabaseContext.Medicines.Remove(medicine);
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
