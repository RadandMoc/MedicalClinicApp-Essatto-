using MedicalClinicApp.Classes;
using MedicalClinicApp.Persistance;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MedicalClinicApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //DBService dbService;
        string sqliteConnectionString;
        DbContextOptions<MedicalClinicContext> options;
        Crud cr;
        MedicalClinicContext dbContext;
        bool SortType = false;
        public MainWindow()
        {
            sqliteConnectionString = "Data Source = EntityFrameworkMedicalClinicApp.db";
            options = new DbContextOptionsBuilder<MedicalClinicContext>().UseSqlite(sqliteConnectionString).Options;
            dbContext = new MedicalClinicContext(options);
            cr = new Crud(dbContext);
            //sqliteConnectionString = "Data Source = EntityFrameworkMedicalClinicApp.db";
            //options = new DbContextOptionsBuilder<MedicalClinicContext>().UseSqlite(sqliteConnectionString).Options;
            //dbContext = new MedicalClinicContext(options);
            //using (dbContext)
            //{
            //    cr = new Crud(dbContext);
            //    int index = cr.ReadLastIndexOfPersonalData() +1;
            //    PersonalData pd = new PersonalData();
            //    pd.IdPD = index;
            //    pd.FirstName = "imie";
            //    pd.LastName = "nazwaisko";
            //    pd.Pesel = 832;
            //    pd.Phone = "+48444";
            //    pd.ActualizationDate = DateTime.Now;
            //    // To Do: scenariusz testowy
            //    cr.Create(pd);
            //    //cr.Read();
            //    //cr.Update("ABC123", 1, 3);
            //    //cr.Delete("ABC123");
            //    dbContext.SaveChanges();
            //    dbContext.Dispose();
            //}
            InitializeComponent();
            DataToManipulate[] enumValues = (DataToManipulate[])Enum.GetValues(typeof(DataToManipulate));
            foreach (DataToManipulate value in enumValues)
            {
                DataTypeCmbBox.Items.Add(value);
                DataTypeCreateCmbBox.Items.Add(value);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dbContext = new MedicalClinicContext(options);
            using (dbContext)
            {
                PersonalData pd = new PersonalData();
                pd.IdPD = cr.ReadLastIndexOfPersonalData() + 1;
                pd.FirstName = "NoweImie";
                pd.LastName = "NoweNazwisko";
                pd.Pesel = 123456789; // Tutaj podaj właściwy numer PESEL
                pd.Phone = "+48123456789"; // Tutaj podaj właściwy numer telefonu
                pd.ActualizationDate = DateTime.Now;

                cr.Create(pd);
                dbContext.SaveChanges();
            }
        }

        private void CreateMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuView.Visibility = Visibility.Hidden;
            CreateView.Visibility = Visibility.Visible;
            DataEntry.Visibility = Visibility.Visible;
        }

        private void ReadMenuBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuView.Visibility = Visibility.Hidden;
            ReadView.Visibility = Visibility.Visible;
            DataEntry.Visibility = Visibility.Visible;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            ReadView.Visibility = Visibility.Hidden;
            CreateView.Visibility = Visibility.Hidden;
            DataEntry.Visibility = Visibility.Hidden;
            MenuView.Visibility = Visibility.Visible;
        }

        private void DataTypeCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dbContext = new MedicalClinicContext(options);
            switch (DataTypeCmbBox.SelectedIndex)
            {
                case 0:
                    ItemsLBox.Items.Clear();
                    using (dbContext)
                    {
                        foreach (object item in cr.Read((DataToManipulate)DataTypeCmbBox.SelectedIndex))
                        {
                            ItemsLBox.Items.Add((Address)item);
                        }
                    }
                    HideEvryEntry();
                    AddressEntry.Visibility = Visibility.Visible;
                    break;
                case 1:
                    ItemsLBox.Items.Clear();
                    using (dbContext)
                    {
                        foreach (object item in cr.Read((DataToManipulate)DataTypeCmbBox.SelectedIndex))
                        {
                            ItemsLBox.Items.Add((Doctor)item);
                        }
                        AddressCmbBox.Items.Clear();
                        foreach (object item in cr.Read(DataToManipulate.Address))
                        {
                            DocAddressCmbBox.Items.Add(item);
                        }
                        PersonalDataCmbBox.Items.Clear();
                        foreach (object item in cr.Read(DataToManipulate.Personal_Data))
                        {
                            DocPersonalDataCmbBox.Items.Add(item);
                        }
                        DocSpecLstBox.Items.Clear();
                        foreach (object item in cr.Read(DataToManipulate.Specialization))
                        {
                            DocSpecLstBox.Items.Add(item);
                        }
                    }
                    HideEvryEntry();
                    DoctorEntry.Visibility = Visibility.Visible;
                    break;
                case 2:
                    ItemsLBox.Items.Clear();
                    using (dbContext)
                    {
                        foreach (object item in cr.Read((DataToManipulate)DataTypeCmbBox.SelectedIndex))
                        {
                            ItemsLBox.Items.Add((MedicalAppointment)item);
                        }
                    }
                    VisitPatientsLstBox.Items.Clear();
                    foreach (object item in cr.Read(DataToManipulate.Patient))
                    {
                        VisitPatientsLstBox.Items.Add(item);
                    }
                    VisitDoctorsLstBox.Items.Clear();
                    foreach (object item in cr.Read(DataToManipulate.Doctor))
                    {
                        VisitDoctorsLstBox.Items.Add(item);
                    }
                    HideEvryEntry();
                    MedicalAppointmentEntry.Visibility = Visibility.Visible;
                    break;
                case 3:
                    ItemsLBox.Items.Clear();
                    using (dbContext)
                    {
                        foreach (object item in cr.Read((DataToManipulate)DataTypeCmbBox.SelectedIndex))
                        {
                            ItemsLBox.Items.Add((Patient)item);
                        }
                        AddressCmbBox.Items.Clear();
                        foreach (object item in cr.Read(DataToManipulate.Address))
                        {
                            AddressCmbBox.Items.Add(item);
                        }
                        PersonalDataCmbBox.Items.Clear();
                        foreach (object item in cr.Read(DataToManipulate.Personal_Data))
                        {
                            PersonalDataCmbBox.Items.Add(item);
                        }
                    }
                    HideEvryEntry();
                    PatientEntry.Visibility = Visibility.Visible;
                    break;
                case 4:
                    ItemsLBox.Items.Clear();
                    using (dbContext)
                    {
                        foreach (object item in cr.Read((DataToManipulate)DataTypeCmbBox.SelectedIndex))
                        {
                            ItemsLBox.Items.Add((PersonalData)item);
                        }
                    }
                    HideEvryEntry();
                    PersonalDataEntry.Visibility = Visibility.Visible;
                    break;
                case 5:
                    ItemsLBox.Items.Clear();
                    using (dbContext)
                    {
                        foreach (object item in cr.Read((DataToManipulate)DataTypeCmbBox.SelectedIndex))
                        {
                            ItemsLBox.Items.Add((Specialization)item);
                        }
                    }
                    HideEvryEntry();
                    SpecializationEntry.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void DeleteCreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsLBox.SelectedItem != null)
            {
                dbContext = new MedicalClinicContext(options);
                switch (DataTypeCmbBox.SelectedIndex)
                {
                    case 0:
                        using (dbContext)
                        {
                            cr.Delete((Address)ItemsLBox.SelectedItem);
                            dbContext.SaveChanges();
                        }
                        break;
                    case 1:
                        using (dbContext)
                        {
                            cr.Delete((Doctor)ItemsLBox.SelectedItem);
                            dbContext.SaveChanges();
                        }
                        break;
                    case 2:
                        using (dbContext)
                        {
                            cr.Delete((MedicalAppointment)ItemsLBox.SelectedItem);
                            dbContext.SaveChanges();
                        }
                        break;
                    case 3:
                        using (dbContext)
                        {
                            cr.Delete((Patient)ItemsLBox.SelectedItem);
                            dbContext.SaveChanges();
                        }
                        break;
                    case 4:
                        using (dbContext)
                        {
                            cr.Delete((PersonalData)ItemsLBox.SelectedItem);
                            dbContext.SaveChanges();
                        }
                        break;
                    case 5:
                        using (dbContext)
                        {
                            cr.Delete((Specialization)ItemsLBox.SelectedItem);
                            dbContext.SaveChanges();
                        }
                        break;
                }
                // Usuń zaznaczony obiekt
                ItemsLBox.Items.Remove(ItemsLBox.SelectedItem);
            }
            else
            {
                MessageBox.Show("Nie zaznaczono elementu do usunięcia.");
            }
        }

        private void DataTypeCreateCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (DataTypeCreateCmbBox.SelectedIndex)
            {
                case 0:
                    HideEvryEntry();
                    AddressEntry.Visibility = Visibility.Visible;
                    break;
                case 1:
                    HideEvryEntry();
                    DoctorEntry.Visibility = Visibility.Visible;
                    dbContext = new MedicalClinicContext(options);
                    using (dbContext)
                    {
                        AddressCmbBox.Items.Clear();
                        foreach (object item in cr.Read(DataToManipulate.Address))
                        {
                            DocAddressCmbBox.Items.Add(item);
                        }
                        PersonalDataCmbBox.Items.Clear();
                        foreach (object item in cr.Read(DataToManipulate.Personal_Data))
                        {
                            DocPersonalDataCmbBox.Items.Add(item);
                        }
                        DocSpecLstBox.Items.Clear();
                        foreach (object item in cr.Read(DataToManipulate.Specialization))
                        {
                            DocSpecLstBox.Items.Add(item);
                        }
                    }
                    break;
                case 2:
                    HideEvryEntry();
                    MedicalAppointmentEntry.Visibility = Visibility.Visible;
                    dbContext = new MedicalClinicContext(options);
                    using (dbContext)
                    {
                        VisitPatientsLstBox.Items.Clear();
                        foreach (object item in cr.Read(DataToManipulate.Patient))
                        {
                            VisitPatientsLstBox.Items.Add(item);
                        }
                        VisitDoctorsLstBox.Items.Clear();
                        foreach (object item in cr.Read(DataToManipulate.Doctor))
                        {
                            VisitDoctorsLstBox.Items.Add(item);
                        }
                    }
                    break;
                case 3:
                    HideEvryEntry();
                    PatientEntry.Visibility = Visibility.Visible;
                    dbContext = new MedicalClinicContext(options);
                    AddressCmbBox.Items.Clear();
                    using (dbContext)
                    {
                        foreach (object item in cr.Read(DataToManipulate.Address))
                        {
                            AddressCmbBox.Items.Add(item);
                        }
                        PersonalDataCmbBox.Items.Clear();
                        foreach (object item in cr.Read(DataToManipulate.Personal_Data))
                        {
                            PersonalDataCmbBox.Items.Add(item);
                        }
                    }
                    break;
                case 4:
                    HideEvryEntry();
                    PersonalDataEntry.Visibility = Visibility.Visible;
                    break;
                case 5:
                    HideEvryEntry();
                    SpecializationEntry.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void HideEvryEntry()
        {
            AddressEntry.Visibility = Visibility.Hidden;
            DoctorEntry.Visibility = Visibility.Hidden;
            MedicalAppointmentEntry.Visibility = Visibility.Hidden;
            PatientEntry.Visibility = Visibility.Hidden;
            PersonalDataEntry.Visibility = Visibility.Hidden;
            SpecializationEntry.Visibility = Visibility.Hidden;
        }

        private void CreateObjCreateBtn_Click(object sender, RoutedEventArgs e)
        {
            dbContext = new MedicalClinicContext(options);
            using (dbContext)
            {
                switch (DataTypeCreateCmbBox.SelectedItem)
                {
                    case DataToManipulate.Address:
                        Address a = new Address()
                        {
                            IdA = cr.ReadLastIndexOfAddress() + 1,
                            Country = CountryEntry.Text,
                            Street = StreetEntry.Text,
                            City = CityEntry.Text,
                            ZipCode = ZipCodeEntry.Text,
                            ActualizationDate = DateTime.Now
                        };
                        if (a.Country == null || a.Street == null || a.City == null)
                            break;
                        cr.Create(a);
                        dbContext.SaveChanges();
                        break;
                    case DataToManipulate.Personal_Data:
                        PersonalData personalData = new PersonalData()
                        {
                            IdPD = cr.ReadLastIndexOfPersonalData() + 1,
                            FirstName = FNameEntry.Text,
                            SecondName = SNameEntry.Text,
                            LastName = LNameEntry.Text,
                            Pesel = int.Parse(PeselEntry.Text),
                            Phone = PhoneEntry.Text,
                            ActualizationDate = DateTime.Now
                        };
                        if (personalData.FirstName == null || personalData.LastName == null || personalData.Pesel == null || personalData.Phone == null)
                            break;
                        cr.Create(personalData);
                        dbContext.SaveChanges();
                        break;
                    case DataToManipulate.Doctor:
                        Doctor d = new Doctor()
                        {
                            IdD = cr.ReadLastIndexOfDoctor() + 1,
                            IdA = ((Address)(DocAddressCmbBox.SelectedItem)).IdA,
                            Address = (Address)(DocAddressCmbBox.SelectedItem),
                            IdPD = ((PersonalData)(DocPersonalDataCmbBox.SelectedItem)).IdPD,
                            PersonalData = (PersonalData)(DocPersonalDataCmbBox.SelectedItem),
                            ActualizationDate = DateTime.Now
                        };
                        if (d.Address == null || d.PersonalData == null)
                            break;
                        cr.Create(d);
                        dbContext.SaveChanges();
                        ICollection<DoctorSpecializations> spec = new List<DoctorSpecializations>();
                        foreach (Specialization item in DocSpecLstBox.SelectedItems)
                        {
                            DoctorSpecializations ds = new DoctorSpecializations()
                            {
                                IdD = d.IdD,
                                IdS = item.IdS,
                                Doctor = d,
                                Specialization = item
                            };
                            dbContext.Entry(ds.Doctor).State = EntityState.Detached;
                            dbContext.Entry(ds.Specialization).State = EntityState.Detached;
                            cr.Create(ds);
                            dbContext.SaveChanges();
                            item.DoctorsSpecializations.Add(ds);
                            spec.Add(ds);
                        }
                        if (spec.Count() == 0)
                            break;
                        Doctor d2 = new Doctor()
                        {
                            IdD = cr.ReadLastIndexOfDoctor() + 1,
                            IdA = ((Address)(DocAddressCmbBox.SelectedItem)).IdA,
                            Address = (Address)(DocAddressCmbBox.SelectedItem),
                            IdPD = ((PersonalData)(DocPersonalDataCmbBox.SelectedItem)).IdPD,
                            PersonalData = (PersonalData)(DocPersonalDataCmbBox.SelectedItem),
                            ActualizationDate = DateTime.Now,
                            DoctorsSpecializations = spec
                        };
                        cr.Update(d, d2);
                        dbContext.SaveChanges();
                        break;
                    case DataToManipulate.Patient:
                        Patient patient = new Patient()
                        {
                            IdP = cr.ReadLastIndexOfPatient() + 1,
                            IdA = ((Address)(AddressCmbBox.SelectedItem)).IdA,
                            Address = (Address)(AddressCmbBox.SelectedItem),
                            IdPD = ((PersonalData)(PersonalDataCmbBox.SelectedItem)).IdPD,
                            PersonalData = (PersonalData)(PersonalDataCmbBox.SelectedItem),
                            ActualizationDate = DateTime.Now
                        };
                        if (patient.IdA == null || patient.Address == null || patient.PersonalData == null)
                            break;
                        cr.Create(patient);
                        dbContext.SaveChanges();
                        break;
                    case DataToManipulate.Medical_Appointment:
                        MedicalAppointment m;
                        if (VisitDate.SelectedDate != null)
                        {
                            m = new MedicalAppointment()
                            {
                                IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                Time = (DateTime)VisitDate.SelectedDate,
                                ActualizationDate = DateTime.Now
                            };
                        }
                        else
                        {
                            m = new MedicalAppointment()
                            {
                                IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                ActualizationDate = DateTime.Now
                            };
                        }
                        cr.Create(m);
                        dbContext.SaveChanges();
                        ICollection<MedicalAppointmentPatients> p = new List<MedicalAppointmentPatients>();
                        ICollection<MedicalAppointmentDoctors> doc = new List<MedicalAppointmentDoctors>();
                        foreach (Patient item in VisitPatientsLstBox.SelectedItems)
                        {
                            MedicalAppointmentPatients mp = new MedicalAppointmentPatients()
                            {
                                IdMA = m.IdMA,
                                IdP = item.IdP,
                                MedicalAppointment = m,
                                Patient = item
                            };
                            cr.Create(mp);
                            dbContext.SaveChanges();
                            item.MedicalAppointmentPatients.Add(mp);
                            p.Add(mp);
                        }
                        foreach (Doctor item in VisitDoctorsLstBox.SelectedItems)
                        {
                            MedicalAppointmentDoctors md = new MedicalAppointmentDoctors()
                            {
                                IdMA = m.IdMA,
                                IdD = item.IdD,
                                MedicalAppointment = m,
                                Doctor = item
                            };
                            cr.Create(md);
                            dbContext.SaveChanges();
                            item.MedicalAppointmentDoctors.Add(md);
                            doc.Add(md);
                        }
                        if (p.Count() == 0 && doc.Count() == 0)
                            break;
                        else if (p.Count() == 0)
                        {
                            MedicalAppointment m2;
                            if (VisitDate.SelectedDate != null)
                            {
                                m2 = new MedicalAppointment()
                                {
                                    IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                    Time = (DateTime)VisitDate.SelectedDate,
                                    ActualizationDate = DateTime.Now,
                                    MedicalAppointmentDoctors = doc
                                };
                            }
                            else
                            {
                                m2 = new MedicalAppointment()
                                {
                                    IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                    ActualizationDate = DateTime.Now,
                                    MedicalAppointmentDoctors = doc
                                };
                            }
                            cr.Update(m, m2);
                            dbContext.SaveChanges();
                        }
                        else if (doc.Count() == 0)
                        {
                            MedicalAppointment m2;
                            if (VisitDate.SelectedDate != null)
                            {
                                m2 = new MedicalAppointment()
                                {
                                    IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                    Time = (DateTime)VisitDate.SelectedDate,
                                    ActualizationDate = DateTime.Now,
                                    MedicalAppointmentPatients = p
                                };
                            }
                            else
                            {
                                m2 = new MedicalAppointment()
                                {
                                    IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                    ActualizationDate = DateTime.Now,
                                    MedicalAppointmentPatients = p
                                };
                            }
                            cr.Update(m, m2);
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            MedicalAppointment m2;
                            if (VisitDate.SelectedDate != null)
                            {
                                m2 = new MedicalAppointment()
                                {
                                    IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                    Time = (DateTime)VisitDate.SelectedDate,
                                    ActualizationDate = DateTime.Now,
                                    MedicalAppointmentDoctors = doc,
                                    MedicalAppointmentPatients = p
                                };
                            }
                            else
                            {
                                m2 = new MedicalAppointment()
                                {
                                    IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                    ActualizationDate = DateTime.Now,
                                    MedicalAppointmentDoctors = doc,
                                    MedicalAppointmentPatients = p
                                };
                            }
                            cr.Update(m, m2);
                            dbContext.SaveChanges();
                        }
                        break;
                    case DataToManipulate.Specialization:
                        Specialization specialization = new Specialization()
                        {
                            IdS = cr.ReadLastIndexOfSpecialization() + 1,
                            SpecializationName = SpecializationNameEntry.Text
                        };
                        if (specialization.SpecializationName == null)
                            break;
                        cr.Create(specialization);
                        dbContext.SaveChanges();
                        break;
                }
            }
        }

        private void UpdateObjReadBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ItemsLBox.SelectedItem == null) return;
            dbContext = new MedicalClinicContext(options);
            using (dbContext)
            {
                switch (DataTypeCreateCmbBox.SelectedItem)
                {
                    case DataToManipulate.Address:
                        Address old = (Address)ItemsLBox.SelectedItem;
                        Address a = new Address()
                        {
                            IdA = cr.ReadLastIndexOfAddress() + 1,
                            Country = CountryEntry.Text,
                            Street = StreetEntry.Text,
                            City = CityEntry.Text,
                            ZipCode = ZipCodeEntry.Text,
                            ActualizationDate = DateTime.Now
                        };
                        if (a.Country == null || a.Street == null || a.City == null)
                            break;
                        cr.Update(old,a);
                        dbContext.SaveChanges();
                        break;
                    case DataToManipulate.Personal_Data:
                        PersonalData old1 = (PersonalData)ItemsLBox.SelectedItem;
                        PersonalData personalData = new PersonalData()
                        {
                            IdPD = cr.ReadLastIndexOfPersonalData() + 1,
                            FirstName = FNameEntry.Text,
                            SecondName = SNameEntry.Text,
                            LastName = LNameEntry.Text,
                            Pesel = int.Parse(PeselEntry.Text),
                            Phone = PhoneEntry.Text,
                            ActualizationDate = DateTime.Now
                        };
                        if (personalData.FirstName == null || personalData.LastName == null || personalData.Pesel == null || personalData.Phone == null)
                            break;
                        cr.Update(old1,personalData);
                        dbContext.SaveChanges();
                        break;
                    case DataToManipulate.Doctor:
                        Doctor old2 = (Doctor)ItemsLBox.SelectedItem;
                        Doctor d = new Doctor()
                        {
                            IdD = cr.ReadLastIndexOfDoctor() + 1,
                            IdA = ((Address)(DocAddressCmbBox.SelectedItem)).IdA,
                            Address = (Address)(DocAddressCmbBox.SelectedItem),
                            IdPD = ((PersonalData)(DocPersonalDataCmbBox.SelectedItem)).IdPD,
                            PersonalData = (PersonalData)(DocPersonalDataCmbBox.SelectedItem),
                            ActualizationDate = DateTime.Now
                        };
                        if (d.Address == null || d.PersonalData == null)
                            break;
                        cr.Update(old2,d);
                        dbContext.SaveChanges();
                        ICollection<DoctorSpecializations> spec = new List<DoctorSpecializations>();
                        foreach (Specialization item in DocSpecLstBox.SelectedItems)
                        {
                            DoctorSpecializations ds = new DoctorSpecializations()
                            {
                                IdD = d.IdD,
                                IdS = item.IdS,
                                Doctor = d,
                                Specialization = item
                            };
                            dbContext.Entry(ds.Doctor).State = EntityState.Detached;
                            dbContext.Entry(ds.Specialization).State = EntityState.Detached;
                            cr.Create(ds);
                            dbContext.SaveChanges();
                            item.DoctorsSpecializations.Add(ds);
                            spec.Add(ds);
                        }
                        if (spec.Count() == 0)
                            break;
                        Doctor d2 = new Doctor()
                        {
                            IdD = cr.ReadLastIndexOfDoctor() + 1,
                            IdA = ((Address)(DocAddressCmbBox.SelectedItem)).IdA,
                            Address = (Address)(DocAddressCmbBox.SelectedItem),
                            IdPD = ((PersonalData)(DocPersonalDataCmbBox.SelectedItem)).IdPD,
                            PersonalData = (PersonalData)(DocPersonalDataCmbBox.SelectedItem),
                            ActualizationDate = DateTime.Now,
                            DoctorsSpecializations = spec
                        };
                        cr.Update(old2, d2);
                        dbContext.SaveChanges();
                        break;
                    case DataToManipulate.Patient:
                        Patient old3 = (Patient)ItemsLBox.SelectedItem;
                        Patient patient = new Patient()
                        {
                            IdP = cr.ReadLastIndexOfPatient() + 1,
                            IdA = ((Address)(AddressCmbBox.SelectedItem)).IdA,
                            Address = (Address)(AddressCmbBox.SelectedItem),
                            IdPD = ((PersonalData)(PersonalDataCmbBox.SelectedItem)).IdPD,
                            PersonalData = (PersonalData)(PersonalDataCmbBox.SelectedItem),
                            ActualizationDate = DateTime.Now
                        };
                        if (patient.IdA == null || patient.Address == null || patient.PersonalData == null)
                            break;
                        cr.Update(old3,patient);
                        dbContext.SaveChanges();
                        break;
                    case DataToManipulate.Medical_Appointment:
                        MedicalAppointment old4 = (MedicalAppointment)ItemsLBox.SelectedItem;
                        MedicalAppointment m;
                        if (VisitDate.SelectedDate != null)
                        {
                            m = new MedicalAppointment()
                            {
                                IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                Time = (DateTime)VisitDate.SelectedDate,
                                ActualizationDate = DateTime.Now
                            };
                        }
                        else
                        {
                            m = new MedicalAppointment()
                            {
                                IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                ActualizationDate = DateTime.Now
                            };
                        }
                        cr.Update(old4,m);
                        dbContext.SaveChanges();
                        ICollection<MedicalAppointmentPatients> p = new List<MedicalAppointmentPatients>();
                        ICollection<MedicalAppointmentDoctors> doc = new List<MedicalAppointmentDoctors>();
                        foreach (Patient item in VisitPatientsLstBox.SelectedItems)
                        {
                            MedicalAppointmentPatients mp = new MedicalAppointmentPatients()
                            {
                                IdMA = m.IdMA,
                                IdP = item.IdP,
                                MedicalAppointment = m,
                                Patient = item
                            };
                            cr.Create(mp);
                            dbContext.SaveChanges();
                            item.MedicalAppointmentPatients.Add(mp);
                            p.Add(mp);
                        }
                        foreach (Doctor item in VisitDoctorsLstBox.SelectedItems)
                        {
                            MedicalAppointmentDoctors md = new MedicalAppointmentDoctors()
                            {
                                IdMA = m.IdMA,
                                IdD = item.IdD,
                                MedicalAppointment = m,
                                Doctor = item
                            };
                            cr.Create(md);
                            dbContext.SaveChanges();
                            item.MedicalAppointmentDoctors.Add(md);
                            doc.Add(md);
                        }
                        if (p.Count() == 0 && doc.Count() == 0)
                            break;
                        else if (p.Count() == 0)
                        {
                            MedicalAppointment m2;
                            if (VisitDate.SelectedDate != null)
                            {
                                m2 = new MedicalAppointment()
                                {
                                    IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                    Time = (DateTime)VisitDate.SelectedDate,
                                    ActualizationDate = DateTime.Now,
                                    MedicalAppointmentDoctors = doc
                                };
                            }
                            else
                            {
                                m2 = new MedicalAppointment()
                                {
                                    IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                    ActualizationDate = DateTime.Now,
                                    MedicalAppointmentDoctors = doc
                                };
                            }
                            cr.Update(old4, m2);
                            dbContext.SaveChanges();
                        }
                        else if (doc.Count() == 0)
                        {
                            MedicalAppointment m2;
                            if (VisitDate.SelectedDate != null)
                            {
                                m2 = new MedicalAppointment()
                                {
                                    IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                    Time = (DateTime)VisitDate.SelectedDate,
                                    ActualizationDate = DateTime.Now,
                                    MedicalAppointmentPatients = p
                                };
                            }
                            else
                            {
                                m2 = new MedicalAppointment()
                                {
                                    IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                    ActualizationDate = DateTime.Now,
                                    MedicalAppointmentPatients = p
                                };
                            }
                            cr.Update(old4, m2);
                            dbContext.SaveChanges();
                        }
                        else
                        {
                            MedicalAppointment m2;
                            if (VisitDate.SelectedDate != null)
                            {
                                m2 = new MedicalAppointment()
                                {
                                    IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                    Time = (DateTime)VisitDate.SelectedDate,
                                    ActualizationDate = DateTime.Now,
                                    MedicalAppointmentDoctors = doc,
                                    MedicalAppointmentPatients = p
                                };
                            }
                            else
                            {
                                m2 = new MedicalAppointment()
                                {
                                    IdMA = cr.ReadLastIndexOfMedicalAppointment() + 1,
                                    ActualizationDate = DateTime.Now,
                                    MedicalAppointmentDoctors = doc,
                                    MedicalAppointmentPatients = p
                                };
                            }
                            cr.Update(old4, m2);
                            dbContext.SaveChanges();
                        }
                        break;
                    case DataToManipulate.Specialization:
                        Specialization old5 = (Specialization)ItemsLBox.SelectedItem;
                        Specialization specialization = new Specialization()
                        {
                            IdS = cr.ReadLastIndexOfSpecialization() + 1,
                            SpecializationName = SpecializationNameEntry.Text
                        };
                        if (specialization.SpecializationName == null)
                            break;
                        cr.Update(old5,specialization);
                        dbContext.SaveChanges();
                        break;
                }
            }
        }

        private void sort_Click(object sender, RoutedEventArgs e)
        {
            if ((DataToManipulate)DataTypeCmbBox.SelectedItem != DataToManipulate.Patient) return;
            if (SortType)
            {
                var items = ItemsLBox.Items.OfType<Patient>().ToList();

                // Posortuj elementy z wykorzystaniem implementacji IComparable<Patient> w klasie Patient
                items.Sort();

                // Wyczyść zawartość ListBox
                ItemsLBox.Items.Clear();

                // Dodaj posortowane elementy z powrotem do ListBox
                foreach (var patient in items)
                {
                    ItemsLBox.Items.Add(patient);
                }
                SortType = false;
            }
            else
            {
                var items = ItemsLBox.Items.OfType<Patient>().ToList();

                // Posortuj elementy w odwrotnej kolejności za pomocą delegatu Comparison<T>
                items.Sort((x, y) => y.CompareTo(x));

                // Wyczyść zawartość ListBox
                ItemsLBox.Items.Clear();

                // Dodaj posortowane elementy z powrotem do ListBox
                foreach (var patient in items)
                {
                    ItemsLBox.Items.Add(patient);
                }
                SortType = true;
            }
        }
    }

    public enum DataToManipulate { Address = 0, Doctor = 1, Medical_Appointment = 2, Patient = 3, Personal_Data = 4, Specialization = 5 }
}