using MedicalClinicApp.Classes;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinicApp.Persistance
{
    public class MedicalClinicContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressArchive> AddressesArchives { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSpecializations> DoctorSpecializations { get; set; }
        public DbSet<MedicalAppointment> MedicalAppointment { get; set; }
        public DbSet<MedicalAppointmentDoctors> MedicalAppointmentDoctors { get; set; }
        public DbSet<MedicalAppointmentPatients> MedicalAppointmentPatients { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PersonalData> PersonalData { get; set; }
        public DbSet<PersonalDataArchive> PersonalDataArchives { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        public MedicalClinicContext(DbContextOptions<MedicalClinicContext> options) : base(options)
        {
            // Database.EnsureCreated() sprawdza, czy baza danych istnieje.
            // Jeśli tak - nic nie robi. Jeśli nie - tworzy bazę i tabele zgodnie z modelem.
            // UWAGA: Gdy baza istnieje, nie jest sprawdzane, czy jest zgodna z modelem.
            // Aby zagwarantować zgodność bazy z modelem można rozważyć sekwecję instrukcji:
            // Database.EnsureDeleted();
            // Database.EnsureCreated();
            // Powoduje to jednak zawsze usuwanie bazy przed rozpoczęciem dzialania programu.
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DoctorSpecializations>().HasKey(sc => new { sc.IdD, sc.IdS });
            modelBuilder.Entity<MedicalAppointmentDoctors>().HasKey(sc => new { sc.IdD, sc.IdMA });
            modelBuilder.Entity<MedicalAppointmentPatients>().HasKey(sc => new { sc.IdP, sc.IdMA });
        }

    }
}