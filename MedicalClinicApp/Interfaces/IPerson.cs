using MedicalClinicApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicApp.Interfaces
{
    public interface IPerson
    {
        public int IdA { get; set; }
        public Address Address { get; set; }
        public int IdPD { get; set; }
        public PersonalData PersonalData { get; set; }
        public ICollection<PersonalDataArchive> PersonalDataArchives { get; set; }
        public ICollection<AddressArchive> AddressArchives { get; set; }
        DateTime ActualizationDate { get; set; }
    }
}
