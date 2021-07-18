using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Prescription.Models
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PId { get; set; }

        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public DateTime DateTime { get; set; }
        public int DoctorId { get; set; }
        [NotMapped]
        public List<int> MedicineIdsList { get; set; }
    }
}
