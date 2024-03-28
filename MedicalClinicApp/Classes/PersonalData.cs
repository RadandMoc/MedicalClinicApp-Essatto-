using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicApp.Classes
{
    public class PersonalData
    {
        [Key]
        public int IdPD { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string LastName { get; set; }
        public int Pesel { get; set; }
        public string Phone { get; set; }
        public DateTime ActualizationDate { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

        public PersonalData() 
        {
            //IdPD = DBService.cr.ReadLastIndexOfPersonalData() + 1;
        }
        public override string ToString()
        {
            if(SecondName == null)
                return $"{FirstName} \n{LastName}, {Phone}";
            else
                return $"{FirstName}, {SecondName} \n{LastName}, {Phone}";
        }

    }
}
