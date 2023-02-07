using InchirieriAuto.Data;
using InchirieriAuto.Models.DBObjects;
using InchirieriAuto.Models;

namespace InchirieriAuto.Repository
{
    public class RezervareRepository
    {
        private ApplicationDbContext dbContext;

        public RezervareRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public RezervareRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<RezervareModel> GetAllRezervares()
        {
            List<RezervareModel> rezervareList = new List<RezervareModel>();

            foreach (Rezervare dbRezervare in dbContext.Rezervares)
            {
                rezervareList.Add(MapDbObjectToModel(dbRezervare));
            }

            return rezervareList;

        }

        public RezervareModel GetRezervareByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Rezervares.FirstOrDefault(x => x.Idrezervare == ID));
        }

        public void InsertRezervare(RezervareModel rezervareModel)
        {
            rezervareModel.IDRezervare = Guid.NewGuid();

            dbContext.Rezervares.Add(MapModelToDbObject(rezervareModel));
            dbContext.SaveChanges();
        }

        public void UpdateRezervare(RezervareModel rezervareModel)
        {
            Rezervare existingRezervare = dbContext.Rezervares.FirstOrDefault(x => x.Idrezervare == rezervareModel.IDRezervare);

            if (existingRezervare != null)
            {
                existingRezervare.Idrezervare = rezervareModel.IDRezervare;
                existingRezervare.Nume = rezervareModel.Nume;
                existingRezervare.NumarTelefon = rezervareModel.NumarTelefon;
                existingRezervare.DataPreluare = rezervareModel.DataPreluare;
                existingRezervare.DataReturnare = rezervareModel.DataReturnare;
                


                dbContext.SaveChanges();


            }
        }

        public void DeleteRezervare(RezervareModel rezervareModel)
        {
            Rezervare existingRezervare = dbContext.Rezervares.FirstOrDefault(x => x.Idrezervare == rezervareModel.IDRezervare);

            if (existingRezervare != null)
            {
                dbContext.Rezervares.Remove(existingRezervare);
                dbContext.SaveChanges();
            }
        }
        private RezervareModel MapDbObjectToModel(Rezervare dbRezervare)
        {
            RezervareModel rezervareModel = new RezervareModel();

            if (dbRezervare != null)
            {
                rezervareModel.IDRezervare = dbRezervare.Idrezervare;
                rezervareModel.Nume = dbRezervare.Nume;
                rezervareModel.NumarTelefon = dbRezervare.NumarTelefon;
                rezervareModel.DataPreluare = dbRezervare.DataPreluare;
                rezervareModel.DataReturnare = dbRezervare.DataReturnare;
                

            }
            return rezervareModel;
        }

        private Rezervare MapModelToDbObject(RezervareModel rezervareModel)
        {
            Rezervare rezervare = new Rezervare();

            if (rezervareModel != null)
            {
                rezervare.Idrezervare = rezervareModel.IDRezervare;
                rezervare.Nume = rezervareModel.Nume;
                rezervare.NumarTelefon = rezervareModel.NumarTelefon;
                rezervare.DataPreluare = rezervareModel.DataPreluare;
                rezervare.DataReturnare = rezervareModel.DataReturnare;
               

            }

            return rezervare;
        }

    }
}
