using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicApp.Classes
{
    public class MedicalAppointmentPatients
    {
        [ForeignKey("MedicalAppointment")]
        public int IdMA {  get; set; }
        [ForeignKey("Patient")]
        public int IdP {  get; set; }
        public MedicalAppointment MedicalAppointment { get; set; }
        public Patient Patient { get; set; }

        public override string ToString() => Patient.ToString();
    }
}
