using MedicalClinicApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicApp.Classes
{
    public class Patient : IPerson, IComparable<Patient>
    {
        [Key]
        public int IdP { get; set; }
        [ForeignKey("Address")]
        public int IdA { get; set; }
        public Address Address { get; set; }
        [ForeignKey("PersonalData")]
        public int IdPD { get; set; }
        public PersonalData PersonalData { get; set; }
        public ICollection<PersonalDataArchive> PersonalDataArchives { get; set; }
        public ICollection<AddressArchive> AddressArchives { get; set; }
        public DateTime ActualizationDate { get; set; }
        public ICollection<MedicalAppointmentPatients> MedicalAppointmentPatients { get; set; }

        public override string ToString()
        {
            string returner = "";
            if (PersonalData != null)
                returner += $"Patient {PersonalData.ToString()}, \n";
            returner += $"No. {IdP.ToString()}";
            if (Address != null)
                returner += $"\nLifing at {Address.ToString()}";
            return returner;
        }
        public int CompareTo(Patient other)
        {
            if (other == null) return 1;
            if (ReferenceEquals(this, other)) return 0;
            int lastNameComparison = this.PersonalData.LastName.CompareTo(other.PersonalData.LastName);
            if (lastNameComparison != 0) return lastNameComparison;
            return this.PersonalData.FirstName.CompareTo(other.PersonalData.FirstName);
        }
    }
}
