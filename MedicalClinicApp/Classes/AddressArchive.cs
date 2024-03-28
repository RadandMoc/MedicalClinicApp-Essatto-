using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicApp.Classes
{
    public class AddressArchive
    {
        [Key]
        public int IdAA { get; set; }
        public string? Country { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public DateTime ActualizationDate { get; set; }
        [AllowNull]
        public Doctor? Doctor { get; set; }
        [AllowNull]
        public Patient? Patient { get; set; }
    }
}
