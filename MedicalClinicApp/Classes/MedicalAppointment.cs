using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicApp.Classes
{
    public class MedicalAppointment
    {
        [Key]
        public int IdMA { get; set; }
        public DateTime Time { get; set; }
        public bool? WasAMeeting { get; set; }
        public DateTime ActualizationDate { get; set; }
        public ICollection<MedicalAppointmentPatients> MedicalAppointmentPatients { get; set; }
        public ICollection<MedicalAppointmentDoctors> MedicalAppointmentDoctors { get; set; }

        public override string ToString()
        {
            string returner = "";
            int assist = 0;
            foreach (MedicalAppointmentPatients item in MedicalAppointmentPatients)
            {
                if(assist == 2)
                {
                    assist = 0;
                    returner += "\n";
                }
                returner += $"{item.ToString()}, ";
            }
            foreach (MedicalAppointmentDoctors item in MedicalAppointmentDoctors)
            {
                if (assist == 2)
                {
                    assist = 0;
                    returner += "\n";
                }
                returner += $"{item.ToString()}, ";
            }
            return returner;
        }
    }
}
