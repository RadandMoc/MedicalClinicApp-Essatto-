using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicApp.Classes
{
    public class PersonalDataArchive
    {
        [Key]
        public int IdPDA { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public int? Pesel { get; set; }
        public string? Phone { get; set; }
        public DateTime ActualizationDate { get; set; }
        [AllowNull]
        public Doctor? Doctor { get; set; }
        [AllowNull]
        public Patient? Patient { get; set; }
    }
}
