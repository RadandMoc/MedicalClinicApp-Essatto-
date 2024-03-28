using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicApp.Classes
{
    public class DoctorSpecializations
    {
        [ForeignKey("Doctor")]
        public int IdD { get; set; }
        [ForeignKey("Specialization")]
        public int IdS { get; set; }
        public Doctor Doctor { get; set; }
        public Specialization Specialization { get; set; }
        public override string ToString() => Specialization.ToString();
    }
}
