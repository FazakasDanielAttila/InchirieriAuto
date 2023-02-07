using InchirieriAuto.Data;
using InchirieriAuto.Models.DBObjects;
using InchirieriAuto.Models;

namespace InchirieriAuto.Repository
{
    public class AngajatiRepository
    {
        private ApplicationDbContext dbContext;

        public AngajatiRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public AngajatiRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<AngajatiModel> GetAllAngajatis()
        {
            List<AngajatiModel> angajatiList = new List<AngajatiModel>();

            foreach (Angajati dbAngajati in dbContext.Angajatis)
            {
                angajatiList.Add(MapDbObjectToModel(dbAngajati));
            }

            return angajatiList;

        }

        public AngajatiModel GetAngajatisByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Angajatis.FirstOrDefault(x => x.Idangajat == ID));
        }

        public void InsertAngajati(AngajatiModel angajatiModel)
        {
            angajatiModel.IDAngajat = Guid.NewGuid();

            dbContext.Angajatis.Add(MapModelToDbObject(angajatiModel));
            dbContext.SaveChanges();
        }

        public void UpdateAngajati(AngajatiModel angajatiModel)
        {
            Angajati existingAngajati = dbContext.Angajatis.FirstOrDefault(x => x.Idangajat == angajatiModel.IDAngajat);

            if (existingAngajati != null)
            {
                existingAngajati.Idangajat = angajatiModel.IDAngajat;
                existingAngajati.Nume = angajatiModel.Nume;
                existingAngajati.Prenume = angajatiModel.Prenume;
                existingAngajati.Oras = angajatiModel.Oras;
                existingAngajati.DataNasterii = angajatiModel.DataNasterii;
                existingAngajati.Cnp = angajatiModel.CNP;
                existingAngajati.NumarTelefon = angajatiModel.NumarTelefon;
                existingAngajati.AdresaCompleta = angajatiModel.AdresaCompleta;


                dbContext.SaveChanges();


            }
        }

        public void DeleteAngajati(AngajatiModel angajatiModel)
        {
            Angajati existingAngajati = dbContext.Angajatis.FirstOrDefault(x => x.Idangajat == angajatiModel.IDAngajat);

            if (existingAngajati != null)
            {
                dbContext.Angajatis.Remove(existingAngajati);
                dbContext.SaveChanges();
            }
        }
        private AngajatiModel MapDbObjectToModel(Angajati dbAngajati)
        {
            AngajatiModel angajatiModel = new AngajatiModel();

            if (dbAngajati != null)
            {
                angajatiModel.IDAngajat = dbAngajati.Idangajat;
                angajatiModel.Nume = dbAngajati.Nume;
                angajatiModel.Prenume = dbAngajati.Prenume;
                angajatiModel.Oras = dbAngajati.Oras;
                angajatiModel.DataNasterii = dbAngajati.DataNasterii;
                angajatiModel.CNP = dbAngajati.Cnp;
                angajatiModel.NumarTelefon = dbAngajati.NumarTelefon;
                angajatiModel.AdresaCompleta = dbAngajati.AdresaCompleta;
            }

            return angajatiModel;
        }

        private Angajati MapModelToDbObject(AngajatiModel angajatiModel)
        {
            Angajati angajati = new Angajati();

            if (angajatiModel != null)
            {
                angajati.Idangajat = angajatiModel.IDAngajat;
                angajati.Nume = angajatiModel.Nume;
                angajati.Prenume = angajatiModel.Prenume;
                angajati.Oras = angajatiModel.Oras;
                angajati.DataNasterii = angajatiModel.DataNasterii;
                angajati.Cnp = angajatiModel.CNP;
                angajati.NumarTelefon = angajatiModel.NumarTelefon;
                angajati.AdresaCompleta = angajatiModel.AdresaCompleta;
            }

            return angajati;
        }

    }
}
