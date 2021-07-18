using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Online_Prescription.Models
{
    public class DatabaseContext : DbContext
    {
        private const string ConnectionString = @"Server=DESKTOP-AM8A223;Database=TestWebtech;Trusted_Connection=true";

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<DoctorPrescription> DoctorPrescriptions { get; set; }
        public DbSet<MedicinePrescription> MedicinePrescriptions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
