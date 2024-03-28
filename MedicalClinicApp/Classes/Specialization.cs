using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicApp.Classes
{
    public class Specialization
    {
        [Key]
        public int IdS { get; set; }
        public string SpecializationName { get; set; }
        public virtual ICollection<DoctorSpecializations> DoctorsSpecializations { get; set; }

        public override string ToString() => SpecializationName;
    }
}
