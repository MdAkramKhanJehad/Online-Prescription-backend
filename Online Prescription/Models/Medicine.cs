using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Prescription.Models
{
    public class Medicine
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MId { get; set; }
        public string Name { get; set; }
        public string Indication { get; set; }
        public string Usage { get; set; }
        public int Instruction { get; set; }

    }
}
