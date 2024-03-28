using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalClinicApp.Classes
{
    public class MedicalAppointmentDoctors
    {
        [ForeignKey("MedicalAppointment")]
        public int IdMA { get; set; }
        [ForeignKey("Doctor")]
        public int IdD { get; set; }
        public MedicalAppointment MedicalAppointment { get; set; }
        public Doctor Doctor { get; set; }

        public override string ToString() => Doctor.ToString();
    }
}