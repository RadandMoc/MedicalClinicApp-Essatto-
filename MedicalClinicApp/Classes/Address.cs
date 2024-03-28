using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicApp.Classes
{
    public class Address
    {
        [Key]
        public int IdA { get; set; }
        [DisallowNull]
        public string Country { get; set; }
        [DisallowNull]
        public string Street { get; set; }
        [DisallowNull]
        public string City { get; set; }
        [AllowNull]
        public string? ZipCode { get; set; }
        public DateTime ActualizationDate { get; set; }
        [AllowNull]
        public Doctor Doctor { get; set; }
        [AllowNull]
        public Patient Patient { get; set; }

        public override string ToString() => $"{Country}/{City}/{Street}";
    }
}
