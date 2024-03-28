using MedicalClinicApp.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinicApp.Classes
{
    public class Crud
    {
        private readonly MedicalClinicContext _context;

        public Crud(MedicalClinicContext context)
        {
            _context = context;

            var wszystkieObiekty = context.Set<Patient>().ToList();
            var wszystkieObiekty2 = context.Set<Doctor>().ToList();
            var wszystkieObiekty3 = context.Set<Address>().ToList();
            var wszystkieObiekty4 = context.Set<AddressArchive>().ToList();
            var wszystkieObiekty5 = context.Set<DoctorSpecializations>().ToList();
            var wszystkieObiekty6 = context.Set<MedicalAppointment>().ToList();
            var wszystkieObiekty7 = context.Set<MedicalAppointmentDoctors>().ToList();
            var wszystkieObiekty8 = context.Set<MedicalAppointmentPatients>().ToList();
            var wszystkieObiekty9 = context.Set<PersonalData>().ToList();
            var wszystkieObiekty10 = context.Set<PersonalDataArchive>().ToList();
            var wszystkieObiekty11 = context.Set<Specialization>().ToList();
        }

        #region Create
        public void Create(PersonalData personalData)
        {
            var pd = new PersonalData
            {
                IdPD = personalData.IdPD,
                FirstName = personalData.FirstName,
                SecondName = personalData.SecondName,
                LastName = personalData.LastName,
                Pesel = personalData.Pesel,
                Phone = personalData.Phone,
                ActualizationDate = personalData.ActualizationDate,
                Doctor = personalData.Doctor,
                Patient = personalData.Patient
            };

            _context.PersonalData.Add(pd);
            _context.SaveChanges();
        }
        public void Create(Address x)
        {
            var returner = new Address
            {
                IdA = x.IdA,
                Country = x.Country,
                Street = x.Street,
                City = x.City,
                ZipCode = x.ZipCode,
                ActualizationDate = x.ActualizationDate,
                Doctor = x.Doctor,
                Patient = x.Patient
            };

            _context.Addresses.Add(returner);
            _context.SaveChanges();
        }
        public void Create(Patient x)
        {
            var returner = new Patient
            {
                IdP = x.IdP,
                IdA = x.IdA,
                Address = x.Address,
                IdPD = x.IdPD,
                PersonalData = x.PersonalData,
                PersonalDataArchives = x.PersonalDataArchives,
                AddressArchives = x.AddressArchives,
                ActualizationDate = x.ActualizationDate,
                MedicalAppointmentPatients = x.MedicalAppointmentPatients
            };

            _context.Patients.Add(returner);
            _context.SaveChanges();
        }
        public void Create(Doctor x)
        {
            var returner = new Doctor
            {
                IdD = x.IdD,
                IdA = x.IdA,
                Address = x.Address,
                IdPD = x.IdPD,
                PersonalData = x.PersonalData,
                PersonalDataArchives = x.PersonalDataArchives,
                AddressArchives = x.AddressArchives,
                ActualizationDate = x.ActualizationDate,
                DoctorsSpecializations = x.DoctorsSpecializations,
                MedicalAppointmentDoctors = x.MedicalAppointmentDoctors
            };

            _context.Doctors.Add(returner);
            _context.SaveChanges();
        }
        public void Create(MedicalAppointment x)
        {
            var returner = new MedicalAppointment
            {
                IdMA = x.IdMA,
                Time = x.Time,
                WasAMeeting = x.WasAMeeting,
                ActualizationDate = x.ActualizationDate,
                MedicalAppointmentPatients = x.MedicalAppointmentPatients,
                MedicalAppointmentDoctors = x.MedicalAppointmentDoctors
            };

            _context.MedicalAppointment.Add(returner);
            _context.SaveChanges();
        }
        public void Create(Specialization x)
        {
            var returner = new Specialization
            {
                IdS = x.IdS,
                SpecializationName = x.SpecializationName,
                DoctorsSpecializations = x.DoctorsSpecializations
            };

            _context.Specializations.Add(returner);
            _context.SaveChanges();
        }
        public void Create(PersonalDataArchive x)
        {
            var returner = new PersonalDataArchive
            {
                IdPDA = x.IdPDA,
                FirstName = x.FirstName,
                LastName = x.LastName,
                SecondName = x.SecondName,
                Pesel = x.Pesel,
                Phone = x.Phone,
                ActualizationDate = x.ActualizationDate,
                Doctor = x.Doctor,
                Patient = x.Patient
            };

            _context.PersonalDataArchives.Add(returner);
            _context.SaveChanges();
        }
        public void Create(AddressArchive x)
        {
            var returner = new AddressArchive
            {
                IdAA = x.IdAA,
                Country = x.Country,
                Street = x.Street,
                City = x.City,
                ZipCode = x.ZipCode,
                ActualizationDate = x.ActualizationDate,
                Doctor = x.Doctor,
                Patient = x.Patient
            };

            _context.AddressesArchives.Add(returner);
            _context.SaveChanges();
        }
        public void Create(MedicalAppointmentPatients x)
        {
            var returner = new MedicalAppointmentPatients
            {
                IdMA = x.IdMA,
                IdP = x.IdP,
                MedicalAppointment = x.MedicalAppointment,
                Patient = x.Patient
            };
            if(_context.MedicalAppointmentPatients.FirstOrDefault(c=>c.IdMA==returner.IdMA && c.IdP==returner.IdP)==null)
            {
                _context.MedicalAppointmentPatients.Add(returner);
                _context.SaveChanges();
            }
        }
        public void Create(MedicalAppointmentDoctors x)
        {
            var returner = new MedicalAppointmentDoctors
            {
                IdMA = x.IdMA,
                IdD = x.IdD,
                MedicalAppointment = x.MedicalAppointment,
                Doctor = x.Doctor
            };

            _context.MedicalAppointmentDoctors.Add(returner);
            _context.SaveChanges();
        }
        public void Create(DoctorSpecializations x)
        {
            var returner = new DoctorSpecializations
            {
                IdD = x.IdD,
                IdS = x.IdS,
                Doctor = x.Doctor,
                Specialization = x.Specialization
            };
            if(_context.DoctorSpecializations.FirstOrDefault(c=>c.IdD==returner.IdD && c.IdS==returner.IdS) == null)
            {
                _context.DoctorSpecializations.Add(returner);
                _context.SaveChanges();
            }
        }

        #endregion Create
        #region Update
        #region UpdateWithObj

        /// <summary>
        /// Update item. First item is with old data, second with actual data
        /// </summary>
        /// <param name="updating"></param>
        /// <param name="personalData"></param>
        public void Update(PersonalData updating, PersonalData personalData)
        {
            int IdPDc = ReadLastIndexOfPersonalDataArchive() + 1;
            int Peselc = updating.Pesel;
            DateTime ActualizationDatec = personalData.ActualizationDate;
            string FirstNamec = null;
            string SecondNamec = null;
            string LastNamec = null;
            string Phonec = null;
            Doctor Doctorc = null;
            Patient Patientc = null;
            if (updating.FirstName != personalData.FirstName && personalData.FirstName != null)
                FirstNamec = personalData.FirstName;
            if (updating.SecondName != personalData.SecondName && personalData.SecondName != null)
                SecondNamec = personalData.SecondName;
            if (updating.LastName != personalData.LastName && personalData.LastName != null)
                LastNamec = personalData.LastName;
            if (updating.Phone != personalData.Phone && personalData.Phone != null)
                Phonec = personalData.Phone;
            if (updating.Doctor != personalData.Doctor && personalData.Doctor != null)
                Doctorc = personalData.Doctor;
            if (updating.Patient != personalData.Patient && personalData.Patient != null)
                Patientc = personalData.Patient;

            var pd = new PersonalData
            {
                IdPD = updating.IdPD,
                FirstName = personalData.FirstName,
                SecondName = personalData.SecondName,
                LastName = personalData.LastName,
                Pesel = personalData.Pesel,
                Phone = personalData.Phone,
                ActualizationDate = DateTime.Now,
                Doctor = personalData.Doctor,
                Patient = personalData.Patient
            };

            var a = new PersonalDataArchive
            {
                IdPDA = IdPDc,
                FirstName = FirstNamec,
                SecondName = SecondNamec,
                LastName = LastNamec,
                Pesel = Peselc,
                Phone = Phonec,
                ActualizationDate = ActualizationDatec,
                Doctor = Doctorc,
                Patient = Patientc
            };

            _context.PersonalData.Remove(updating);
            _context.PersonalData.Add(pd);
            _context.PersonalDataArchives.Add(a);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. First item is with old data, second with actual data
        /// </summary>
        /// <param name="updating"></param>
        /// <param name="x"></param>
        public void Update(Address updating, Address x)
        {
            int IdAc = ReadLastIndexOfAddressArchive() + 1;
            DateTime ActualizationDatec = x.ActualizationDate;
            string Countryc = null;
            string Streetc = null;
            string Cityc = null;
            string ZipCodec = null;
            Doctor Doctorc = null;
            Patient Patientc = null;
            if (updating.Country != x.Country && x.Country != null)
                Countryc = x.Country;
            if (updating.Street != x.Street && x.Street != null)
                Streetc = x.Street;
            if (updating.City != x.City && x.City != null)
                Cityc = x.City;
            if (updating.Doctor != x.Doctor && x.Doctor != null)
                Doctorc = x.Doctor;
            if (updating.Patient != x.Patient && x.Patient != null)
                Patientc = x.Patient;

            AddressArchive a = new AddressArchive
            {
                IdAA = IdAc,
                Country = Countryc,
                Street = Streetc,
                City = Cityc,
                ZipCode = ZipCodec,
                ActualizationDate = ActualizationDatec,
                Doctor = Doctorc,
                Patient = Patientc
            };

            var returner = new Address
            {
                IdA = updating.IdA,
                Country = x.Country,
                Street = x.Street,
                City = x.City,
                ZipCode = x.ZipCode,
                ActualizationDate = x.ActualizationDate,
                Doctor = x.Doctor,
                Patient = x.Patient
            };

            _context.Addresses.Remove(updating);
            _context.Addresses.Add(returner);
            _context.AddressesArchives.Add(a);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. First item is with old data, second with actual data
        /// </summary>
        /// <param name="updating"></param>
        /// <param name="x"></param>
        public void Update(Patient updating, Patient x)
        {
            var returner = new Patient
            {
                IdP = updating.IdP,
                IdA = x.IdA,
                Address = x.Address,
                IdPD = x.IdPD,
                PersonalData = x.PersonalData,
                PersonalDataArchives = x.PersonalDataArchives,
                AddressArchives = x.AddressArchives,
                ActualizationDate = x.ActualizationDate,
                MedicalAppointmentPatients = x.MedicalAppointmentPatients
            };

            _context.Patients.Remove(updating);
            _context.Patients.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. First item is with old data, second with actual data
        /// </summary>
        /// <param name="updating"></param>
        /// <param name="x"></param>
        public void Update(Doctor updating, Doctor x)
        {
            var returner = new Doctor
            {
                IdD = updating.IdD,
                IdA = x.IdA,
                Address = x.Address,
                IdPD = x.IdPD,
                PersonalData = x.PersonalData,
                PersonalDataArchives = x.PersonalDataArchives,
                AddressArchives = x.AddressArchives,
                ActualizationDate = x.ActualizationDate,
                DoctorsSpecializations = x.DoctorsSpecializations,
                MedicalAppointmentDoctors = x.MedicalAppointmentDoctors
            };

            _context.Doctors.Remove(updating);
            _context.Doctors.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. First item is with old data, second with actual data
        /// </summary>
        /// <param name="updating"></param>
        /// <param name="x"></param>
        public void Update(MedicalAppointment updating, MedicalAppointment x)
        {
            var returner = new MedicalAppointment
            {
                IdMA = updating.IdMA,
                Time = x.Time,
                WasAMeeting = x.WasAMeeting,
                ActualizationDate = x.ActualizationDate,
                MedicalAppointmentPatients = x.MedicalAppointmentPatients,
                MedicalAppointmentDoctors = x.MedicalAppointmentDoctors
            };

            _context.MedicalAppointment.Remove(updating);
            _context.MedicalAppointment.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. First item is with old data, second with actual data
        /// </summary>
        /// <param name="updating"></param>
        /// <param name="x"></param>
        public void Update(Specialization updating, Specialization x)
        {
            var returner = new Specialization
            {
                IdS = updating.IdS,
                SpecializationName = x.SpecializationName,
                DoctorsSpecializations = x.DoctorsSpecializations
            };

            _context.Specializations.Remove(updating);
            _context.Specializations.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. First item is with old data, second with actual data
        /// </summary>
        /// <param name="updating"></param>
        /// <param name="x"></param>
        public void Update(PersonalDataArchive updating, PersonalDataArchive x)
        {
            var returner = new PersonalDataArchive
            {
                IdPDA = updating.IdPDA,
                FirstName = x.FirstName,
                LastName = x.LastName,
                SecondName = x.SecondName,
                Pesel = x.Pesel,
                Phone = x.Phone,
                ActualizationDate = x.ActualizationDate,
                Doctor = x.Doctor,
                Patient = x.Patient
            };

            _context.PersonalDataArchives.Remove(updating);
            _context.PersonalDataArchives.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. First item is with old data, second with actual data
        /// </summary>
        /// <param name="updating"></param>
        /// <param name="x"></param>
        public void Update(AddressArchive updating, AddressArchive x)
        {
            var returner = new AddressArchive
            {
                IdAA = updating.IdAA,
                Country = x.Country,
                Street = x.Street,
                City = x.City,
                ZipCode = x.ZipCode,
                ActualizationDate = x.ActualizationDate,
                Doctor = x.Doctor,
                Patient = x.Patient
            };

            _context.AddressesArchives.Remove(updating);
            _context.AddressesArchives.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. First item is with old data, second with actual data
        /// </summary>
        /// <param name="updating"></param>
        /// <param name="x"></param>
        public void Update(MedicalAppointmentPatients updating, MedicalAppointmentPatients x)
        {
            var returner = new MedicalAppointmentPatients
            {
                IdMA = updating.IdMA,
                IdP = updating.IdP,
                MedicalAppointment = x.MedicalAppointment,
                Patient = x.Patient
            };

            _context.MedicalAppointmentPatients.Remove(updating);
            _context.MedicalAppointmentPatients.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. First item is with old data, second with actual data
        /// </summary>
        /// <param name="updating"></param>
        /// <param name="x"></param>
        public void Update(MedicalAppointmentDoctors updating, MedicalAppointmentDoctors x)
        {
            var returner = new MedicalAppointmentDoctors
            {
                IdMA = updating.IdMA,
                IdD = updating.IdD,
                MedicalAppointment = x.MedicalAppointment,
                Doctor = x.Doctor
            };

            _context.MedicalAppointmentDoctors.Remove(updating);
            _context.MedicalAppointmentDoctors.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. First item is with old data, second with actual data
        /// </summary>
        /// <param name="updating"></param>
        /// <param name="x"></param>
        public void Update(DoctorSpecializations updating, DoctorSpecializations x)
        {
            var returner = new DoctorSpecializations
            {
                IdD = updating.IdD,
                IdS = updating.IdS,
                Doctor = x.Doctor,
                Specialization = x.Specialization
            };

            _context.DoctorSpecializations.Remove(updating);
            _context.DoctorSpecializations.Add(returner);
            _context.SaveChanges();
        }

        #endregion UpdateWithObj
        #region UpdateWithId

        /// <summary>
        /// Update item. Id is with old data, second with actual data
        /// </summary>
        /// <param name="updatingId"></param>
        /// <param name="x"></param>
        public void Update(int updatingId, Address x)
        {
            Address updating = _context.Addresses.SingleOrDefault(c => c.IdA == updatingId);
            int IdAc = ReadLastIndexOfAddressArchive() + 1;
            DateTime ActualizationDatec = x.ActualizationDate;
            string Countryc = null;
            string Streetc = null;
            string Cityc = null;
            string ZipCodec = null;
            Doctor Doctorc = null;
            Patient Patientc = null;
            if (updating.Country != x.Country && x.Country != null)
                Countryc = x.Country;
            if (updating.Street != x.Street && x.Street != null)
                Streetc = x.Street;
            if (updating.City != x.City && x.City != null)
                Cityc = x.City;
            if (updating.Doctor != x.Doctor && x.Doctor != null)
                Doctorc = x.Doctor;
            if (updating.Patient != x.Patient && x.Patient != null)
                Patientc = x.Patient;

            AddressArchive a = new AddressArchive
            {
                IdAA = IdAc,
                Country = Countryc,
                Street = Streetc,
                City = Cityc,
                ZipCode = ZipCodec,
                ActualizationDate = ActualizationDatec,
                Doctor = Doctorc,
                Patient = Patientc
            };
            var returner = new Address
            {
                IdA = updatingId,
                Country = x.Country,
                Street = x.Street,
                City = x.City,
                ZipCode = x.ZipCode,
                ActualizationDate = x.ActualizationDate,
                Doctor = x.Doctor,
                Patient = x.Patient
            };

            _context.Addresses.Remove(_context.Addresses.SingleOrDefault(c => c.IdA == updatingId));
            _context.Addresses.Add(returner);
            _context.AddressesArchives.Add(a);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. Id is with old data, second with actual data
        /// </summary>
        /// <param name="updatingId"></param>
        /// <param name="x"></param>
        public void Update(int updatingId, PersonalData personalData)
        {
            PersonalData updating = _context.PersonalData.SingleOrDefault(c => c.IdPD == updatingId);
            int IdPDc = ReadLastIndexOfPersonalDataArchive() + 1;
            int Peselc = updating.Pesel;
            DateTime ActualizationDatec = personalData.ActualizationDate;
            string FirstNamec = null;
            string SecondNamec = null;
            string LastNamec = null;
            string Phonec = null;
            Doctor Doctorc = null;
            Patient Patientc = null;
            if (updating.FirstName != personalData.FirstName && personalData.FirstName != null)
                FirstNamec = personalData.FirstName;
            if (updating.SecondName != personalData.SecondName && personalData.SecondName != null)
                SecondNamec = personalData.SecondName;
            if (updating.LastName != personalData.LastName && personalData.LastName != null)
                LastNamec = personalData.LastName;
            if (updating.Phone != personalData.Phone && personalData.Phone != null)
                Phonec = personalData.Phone;
            if (updating.Doctor != personalData.Doctor && personalData.Doctor != null)
                Doctorc = personalData.Doctor;
            if (updating.Patient != personalData.Patient && personalData.Patient != null)
                Patientc = personalData.Patient;

            var pd = new PersonalData
            {
                IdPD = updatingId,
                FirstName = personalData.FirstName,
                SecondName = personalData.SecondName,
                LastName = personalData.LastName,
                Pesel = personalData.Pesel,
                Phone = personalData.Phone,
                ActualizationDate = DateTime.Now,
                Doctor = personalData.Doctor,
                Patient = personalData.Patient
            };
            var a = new PersonalDataArchive
            {
                IdPDA = IdPDc,
                FirstName = FirstNamec,
                SecondName = SecondNamec,
                LastName = LastNamec,
                Pesel = Peselc,
                Phone = Phonec,
                ActualizationDate = ActualizationDatec,
                Doctor = Doctorc,
                Patient = Patientc
            };

            _context.PersonalData.Remove(_context.PersonalData.SingleOrDefault(c => c.IdPD == updatingId));
            _context.PersonalData.Add(pd);
            _context.PersonalDataArchives.Add(a);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. Id is with old data, second with actual data
        /// </summary>
        /// <param name="updatingId"></param>
        /// <param name="x"></param>
        public void Update(int updatingId, Patient x)
        {
            var returner = new Patient
            {
                IdP = updatingId,
                IdA = x.IdA,
                Address = x.Address,
                IdPD = x.IdPD,
                PersonalData = x.PersonalData,
                PersonalDataArchives = x.PersonalDataArchives,
                AddressArchives = x.AddressArchives,
                ActualizationDate = x.ActualizationDate,
                MedicalAppointmentPatients = x.MedicalAppointmentPatients
            };

            _context.Patients.Remove(_context.Patients.SingleOrDefault(c => c.IdP == updatingId));
            _context.Patients.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. Id is with old data, second with actual data
        /// </summary>
        /// <param name="updatingId"></param>
        /// <param name="x"></param>
        public void Update(int updatingId, Doctor x)
        {
            var returner = new Doctor
            {
                IdD = updatingId,
                IdA = x.IdA,
                Address = x.Address,
                IdPD = x.IdPD,
                PersonalData = x.PersonalData,
                PersonalDataArchives = x.PersonalDataArchives,
                AddressArchives = x.AddressArchives,
                ActualizationDate = x.ActualizationDate,
                DoctorsSpecializations = x.DoctorsSpecializations,
                MedicalAppointmentDoctors = x.MedicalAppointmentDoctors
            };

            _context.Doctors.Remove(_context.Doctors.SingleOrDefault(c => c.IdD == updatingId));
            _context.Doctors.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. Id is with old data, second with actual data
        /// </summary>
        /// <param name="updatingId"></param>
        /// <param name="x"></param>
        public void Update(int updatingId, MedicalAppointment x)
        {
            var returner = new MedicalAppointment
            {
                IdMA = updatingId,
                Time = x.Time,
                WasAMeeting = x.WasAMeeting,
                ActualizationDate = x.ActualizationDate,
                MedicalAppointmentPatients = x.MedicalAppointmentPatients,
                MedicalAppointmentDoctors = x.MedicalAppointmentDoctors
            };

            _context.MedicalAppointment.Remove(_context.MedicalAppointment.SingleOrDefault(c => c.IdMA == updatingId));
            _context.MedicalAppointment.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. Id is with old data, second with actual data
        /// </summary>
        /// <param name="updatingId"></param>
        /// <param name="x"></param>
        public void Update(int updatingId, Specialization x)
        {
            var returner = new Specialization
            {
                IdS = updatingId,
                SpecializationName = x.SpecializationName,
                DoctorsSpecializations = x.DoctorsSpecializations
            };

            _context.Specializations.Remove(_context.Specializations.SingleOrDefault(c => c.IdS == updatingId));
            _context.Specializations.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. Id is with old data, second with actual data
        /// </summary>
        /// <param name="updatingId"></param>
        /// <param name="x"></param>
        public void Update(int updatingId, PersonalDataArchive x)
        {
            var returner = new PersonalDataArchive
            {
                IdPDA = updatingId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                SecondName = x.SecondName,
                Pesel = x.Pesel,
                Phone = x.Phone,
                ActualizationDate = x.ActualizationDate,
                Doctor = x.Doctor,
                Patient = x.Patient
            };

            _context.PersonalDataArchives.Remove(_context.PersonalDataArchives.SingleOrDefault(c => c.IdPDA == updatingId));
            _context.PersonalDataArchives.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. Id is with old data, second with actual data
        /// </summary>
        /// <param name="updatingId"></param>
        /// <param name="x"></param>
        public void Update(int updatingId, AddressArchive x)
        {
            var returner = new AddressArchive
            {
                IdAA = updatingId,
                Country = x.Country,
                Street = x.Street,
                City = x.City,
                ZipCode = x.ZipCode,
                ActualizationDate = x.ActualizationDate,
                Doctor = x.Doctor,
                Patient = x.Patient
            };

            _context.AddressesArchives.Remove(_context.AddressesArchives.SingleOrDefault(c => c.IdAA == updatingId));
            _context.AddressesArchives.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. Id is from first part name with old data, second is from second part of name, third with actual data
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="x"></param>
        public void Update(int id1, int id2, MedicalAppointmentPatients x)
        {
            var returner = new MedicalAppointmentPatients
            {
                IdMA = id1,
                IdP = id2,
                MedicalAppointment = x.MedicalAppointment,
                Patient = x.Patient
            };

            _context.MedicalAppointmentPatients.Remove(_context.MedicalAppointmentPatients.SingleOrDefault(c => c.IdMA == id1 && c.IdP == id2));
            _context.MedicalAppointmentPatients.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. Id is from first part name with old data, second is from second part of name, third with actual data
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="x"></param>
        public void Update(int id1, int id2, MedicalAppointmentDoctors x)
        {
            var returner = new MedicalAppointmentDoctors
            {
                IdMA = id1,
                IdD = id2,
                MedicalAppointment = x.MedicalAppointment,
                Doctor = x.Doctor
            };

            _context.MedicalAppointmentDoctors.Remove(_context.MedicalAppointmentDoctors.SingleOrDefault(c => c.IdMA == id1 && c.IdD == id2));
            _context.MedicalAppointmentDoctors.Add(returner);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update item. Id is from first part name with old data, second is from second part of name, third with actual data
        /// </summary>
        /// <param name="id1"></param>
        /// <param name="id2"></param>
        /// <param name="x"></param>
        public void Update(int id1, int id2, DoctorSpecializations x)
        {
            var returner = new DoctorSpecializations
            {
                IdD = id1,
                IdS = id2,
                Doctor = x.Doctor,
                Specialization = x.Specialization
            };

            _context.DoctorSpecializations.Remove(_context.DoctorSpecializations.SingleOrDefault(c => c.IdD == id1 && c.IdS == id2));
            _context.DoctorSpecializations.Add(returner);
            _context.SaveChanges();
        }

        #endregion UpdateWithId
        #endregion Update
        #region Read
        #region ReadLastIndex
        public int ReadLastIndexOfPersonalData()
        {
            if (_context.PersonalData.Count() > 0)
                return _context.PersonalData.Max(c => c.IdPD);
            else
                return -1;
        }
        public int ReadLastIndexOfAddress()
        {
            if (_context.Addresses.Count() > 0)
                return _context.Addresses.Max(c => c.IdA);
            else
                return -1;
        }
        public int ReadLastIndexOfPatient()
        {
            if (_context.Patients.Count() > 0)
                return _context.Patients.Max(c => c.IdP);
            else
                return -1;
        }
        public int ReadLastIndexOfDoctor()
        {
            if (_context.Doctors.Count() > 0)
                return _context.Doctors.Max(c => c.IdD);
            else
                return -1;
        }
        public int ReadLastIndexOfSpecialization()
        {
            if (_context.Doctors.Count() > 0)
                return _context.Specializations.Max(c => c.IdS);
            else
                return -1;
        }
        public int ReadLastIndexOfMedicalAppointment()
        {
            if (_context.MedicalAppointment.Count() > 0)
                return _context.MedicalAppointment.Max(c => c.IdMA);
            else
                return -1;
        }
        public int ReadLastIndexOfPersonalDataArchive()
        {
            if (_context.PersonalDataArchives.Count() > 0)
                return _context.PersonalDataArchives.Max(c => c.IdPDA);
            else
                return -1;
        }
        public int ReadLastIndexOfAddressArchive()
        {
            if (_context.AddressesArchives.Count() > 0)
                return _context.AddressesArchives.Max(c => c.IdAA);
            else
                return -1;
        }
        #endregion ReadLastIndex
        #region ReadItems
        public List<object> Read(DataToManipulate en)
        {
            List<object> returner = new List<object>();
            switch (en)
            {
                case DataToManipulate.Address:
                    foreach(object o in _context.Addresses)
                    {
                        returner.Add(o);
                    }
                    break;
                case DataToManipulate.Doctor:
                    foreach (object o in _context.Doctors)
                    {
                        returner.Add(o);
                    }
                    break;
                case DataToManipulate.Patient:
                    foreach (object o in _context.Patients)
                    {
                        returner.Add(o);
                    }
                    break;
                case DataToManipulate.Medical_Appointment:
                    foreach (object o in _context.MedicalAppointment)
                    {
                        returner.Add(o);
                    }
                    break;
                case DataToManipulate.Specialization:
                    foreach (object o in _context.Specializations)
                    {
                        returner.Add(o);
                    }
                    break;
                case DataToManipulate.Personal_Data:
                    foreach (object o in _context.PersonalData)
                    {
                        returner.Add(o);
                    }
                    break;
            }
            return returner;
        }
        #endregion ReadItems
        #endregion Read
        #region Delete
        public void Delete(Patient patient)
        {
            foreach (var patientsMedical in patient.MedicalAppointmentPatients)
            {
                Delete(patientsMedical.MedicalAppointment);
            }
            changeIdInPersonalData(patient.IdP, true);
            _context.Patients.Remove(_context.Patients.SingleOrDefault(c => c.IdP == patient.IdP));
            _context.SaveChanges();
        }

        public void Delete(Doctor doctor)
        {
            Delete(doctor.IdD, true);
            foreach (var doctorMedical in doctor.MedicalAppointmentDoctors)
            {
                Delete(doctorMedical.MedicalAppointment);
            }
            changeIdInPersonalData(doctor.IdD, false);
            _context.Doctors.Remove(_context.Doctors.SingleOrDefault(d => d.IdD == doctor.IdD));
            _context.SaveChanges();
        }

        public void Delete(Address adress)
        {
            if(adress.Patient != null)
                Delete(adress.Patient);
            if(adress.Doctor != null)
                Delete(adress.Doctor);
            _context.Addresses.Remove(_context.Addresses.SingleOrDefault(a => a.IdA == adress.IdA));
            _context.SaveChanges();
        }

        public void Delete(int id, bool deleteDoctor)
        {
            if (deleteDoctor)
            {
                if (_context.DoctorSpecializations.Select(x => x.IdD).Contains(id))
                {
                    _context.DoctorSpecializations.Remove(_context.DoctorSpecializations.SingleOrDefault(DS => DS.IdD == id));
                }
            }
            else
            {
                if (_context.DoctorSpecializations.Select(x => x.IdS).Contains(id))
                {
                    _context.DoctorSpecializations.Remove(_context.DoctorSpecializations.SingleOrDefault(DS => DS.IdS == id));
                }
            }
            _context.SaveChanges();
        }

        public void Delete(Specialization specialitzation)
        {
            Delete(specialitzation.IdS, false);
            _context.Specializations.Remove(_context.Specializations.SingleOrDefault(s => s.IdS == specialitzation.IdS));
            _context.SaveChanges();
        }

        public void Delete(MedicalAppointment medicalApp)
        {
            _context.MedicalAppointmentDoctors.Remove(_context.MedicalAppointmentDoctors.SingleOrDefault(m => m.IdMA == medicalApp.IdMA));
            _context.MedicalAppointmentPatients.Remove(_context.MedicalAppointmentPatients.SingleOrDefault(m => m.IdMA == medicalApp.IdMA));
            _context.MedicalAppointment.Remove(_context.MedicalAppointment.SingleOrDefault(m => m.IdMA == medicalApp.IdMA));
            _context.SaveChanges();
        }

        public void Delete(PersonalData personalData)
        {
            var dataToRemove = _context.PersonalData.SingleOrDefault(PD => PD.IdPD == personalData.IdPD);
            if (dataToRemove != null)
            {
                _context.PersonalData.Remove(dataToRemove);
                _context.SaveChanges();
            }
        }

        public void Delete(PersonalDataArchive personalData)
        {
            _context.PersonalDataArchives.Remove(_context.PersonalDataArchives.SingleOrDefault(PDA => PDA.IdPDA == personalData.IdPDA));
            _context.SaveChanges();
        }
        public void Delete(AddressArchive address)
        {
            _context.AddressesArchives.Remove(_context.AddressesArchives.SingleOrDefault(AA => AA.IdAA == address.IdAA));
            _context.SaveChanges();
        }

        private void changeIdInPersonalData(int id, bool forPatient)
        {
            List<Patient> plist = null;
            List<Doctor> dlist = null;
            if (forPatient)
            {
                plist = _context.PersonalDataArchives.Where(x => x.Patient.IdP == id).Select(x => x.Patient).ToList();
                for (int i = 0; i < plist.Count; i++)
                {
                    plist[i] = null;
                }
            }
            else
            {
                dlist = _context.PersonalDataArchives.Where(x => x.Doctor.IdD == id).Select(x => x.Doctor).ToList();

                for (int i = 0; i < dlist.Count; i++)
                {
                    dlist[i] = null;
                }
            }
        }

        public void Delete(int id, DataToManipulate dataToManipulate)
        {

            switch (dataToManipulate)
            {
                case DataToManipulate.Address:
                    {
                        Address a = _context.Addresses.FirstOrDefault(x => x.IdA == id);
                        if (a != null)
                        {
                            Delete(a);
                        }
                        break;
                    }
                case DataToManipulate.Patient:
                    {
                        Patient p = _context.Patients.FirstOrDefault(x => x.IdP == id);
                        if (p != null)
                        {
                            Delete(p);
                        }
                        break;
                    }
                case DataToManipulate.Doctor:
                    {
                        Doctor d = _context.Doctors.FirstOrDefault(x => x.IdD == id);
                        if (d != null)
                        {
                            Delete(d);
                        }
                        break;
                    }
                case DataToManipulate.Medical_Appointment:
                    {
                        MedicalAppointment m = _context.MedicalAppointment.FirstOrDefault(x => x.IdMA == id);
                        if (m != null)
                        {
                            Delete(m);
                        }
                        break;
                    }
                case DataToManipulate.Specialization:
                    {
                        Specialization s = _context.Specializations.FirstOrDefault(x => x.IdS == id);
                        if (s != null)
                        {
                            Delete(s);
                        }
                        break;
                    }
                    case DataToManipulate.Personal_Data:
                    {
                        PersonalData pd = _context.PersonalData.FirstOrDefault(x => x.IdPD == id);
                        if(pd != null)
                        {
                            Delete(pd);
                        }
                        break;
                    }

            }
            _context.SaveChanges();
        }

        #endregion Delete
    }
}
