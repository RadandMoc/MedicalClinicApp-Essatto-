using MedicalClinicApp.Classes;
using MedicalClinicApp.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MedicalClinicApp
{
    public class DBService
    {
        public static string sqliteConnectionString;
        public static DbContextOptions<MedicalClinicContext> options;
        public static Crud cr;
        public static MedicalClinicContext dbContext;
        public DBService()
        {
            sqliteConnectionString = "Data Source = EntityFrameworkMedicalClinicApp.db";
            DBService.options = new DbContextOptionsBuilder<MedicalClinicContext>().UseSqlite(sqliteConnectionString).Options;
            /*using (var unitOfWork = new MedicalClinicAppUnitOfWork(new MedicalClinicAppContext(options)))
            {

            }*/
            dbContext = new MedicalClinicContext(DBService.options);
            using (dbContext)
            {
                // To Do: scenariusz testowy
                DBService.cr = new Crud(dbContext);
                //cr.Create();
                //cr.Read();
                //cr.Update("ABC123", 1, 3);
                //cr.Delete("ABC123");
                dbContext.SaveChanges();
                dbContext.Dispose();
            }
        }

        public static void Create(PersonalData personalData)
        {
            DBService.options = new DbContextOptionsBuilder<MedicalClinicContext>().UseSqlite(sqliteConnectionString).Options;
            dbContext = new MedicalClinicContext(DBService.options);
            using (dbContext)
            {
                DBService.cr = new Crud(dbContext);
                DBService.cr.Create(personalData);
                dbContext.SaveChanges();
                dbContext.Dispose();
            }
        }

        public static int ReadLastIndexOfPersonalData()
        {
            DBService.options = new DbContextOptionsBuilder<MedicalClinicContext>().UseSqlite(sqliteConnectionString).Options;
            dbContext = new MedicalClinicContext(DBService.options);
            int returner;
            using (dbContext)
            {
                DBService.cr = new Crud(dbContext);
                returner = DBService.cr.ReadLastIndexOfPersonalData();
                dbContext.Dispose();
            }
            return returner;
        }
    }
}
