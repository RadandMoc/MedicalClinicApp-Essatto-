using MedicalClinicApp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicApp.Classes
{
    public class Doctor : IPerson, IComparable<Doctor>
    {
        [Key]
        public int IdD { get; set; }
        [ForeignKey("Address")]
        public int IdA { get; set; }
        public Address Address { get; set; }
        [ForeignKey("PersonalData")]
        public int IdPD { get; set; }
        public PersonalData PersonalData { get; set; }
        public ICollection<PersonalDataArchive> PersonalDataArchives { get; set; }
        public ICollection<AddressArchive> AddressArchives { get; set; }
        public DateTime ActualizationDate { get; set; }
        public virtual ICollection<DoctorSpecializations> DoctorsSpecializations { get; set; }
        public ICollection<MedicalAppointmentDoctors> MedicalAppointmentDoctors { get; set; }
        public override string ToString() => $"{GetTitles()}\n{PersonalData.ToString()}, \nNo. {IdD.ToString()}, \nlife at {Address.ToString()}";
        private string GetTitles()
        {
            string returner = "Doctor ";
            if (DoctorsSpecializations is null)
            {
                returner = "Doctor without specialization";
            }
            else
            {
                foreach (DoctorSpecializations item in DoctorsSpecializations)
                {
                    returner += item.ToString();
                    returner += ", ";
                }
            }
            return returner;
        }
        public int CompareTo(Doctor? other)
        {
            if (other == null) return 1;
            if (other == this) return 0;
            return (this.IdD > other.IdD) ? 1 : (this.IdD < other.IdD) ? -1 : 0;
        }
    }
}
