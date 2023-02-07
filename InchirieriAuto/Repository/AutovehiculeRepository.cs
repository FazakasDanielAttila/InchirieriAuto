using InchirieriAuto.Data;
using InchirieriAuto.Models.DBObjects;
using InchirieriAuto.Models;

namespace InchirieriAuto.Repository
{
    public class AutovehiculeRepository
    {
        private ApplicationDbContext dbContext;
        public AutovehiculeRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public AutovehiculeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<AutovehiculeModel> GetAllAutovehicules()
        {
            List<AutovehiculeModel> autovehiculeList = new List<AutovehiculeModel>();

            foreach (Autovehicule dbAutovehicule in dbContext.Autovehicules)
            {
                autovehiculeList.Add(MapDbObjectToModel(dbAutovehicule));
            }
            return autovehiculeList;
        }

        public AutovehiculeModel GetAutovehiculeByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Autovehicules.FirstOrDefault(x => x.Idautovehicul == ID));
        }

        public void InsertAutovehicule(AutovehiculeModel autovehiculeModel)
        {
            autovehiculeModel.IDAutovehicul = Guid.NewGuid();

            dbContext.Autovehicules.Add(MapModelToDbObject(autovehiculeModel));
            dbContext.SaveChanges();
        }
        public void UpdateAutovehicule(AutovehiculeModel autovehiculeModel)
        {
            Autovehicule existingAutovehicule = dbContext.Autovehicules.FirstOrDefault(x => x.Idautovehicul == autovehiculeModel.IDAutovehicul);

            if (existingAutovehicule != null)
            {
                existingAutovehicule.Idautovehicul = autovehiculeModel.IDAutovehicul;
                existingAutovehicule.Marca = autovehiculeModel.Marca;
                existingAutovehicule.NumarLocuri = autovehiculeModel.NumarLocuri;
                existingAutovehicule.Disponibilitate = autovehiculeModel.Disponibilitate;
                existingAutovehicule.PretZi = autovehiculeModel.PretZi;
                existingAutovehicule.Valuta = autovehiculeModel.Valuta;


                dbContext.SaveChanges();
            }
        }
        public void DeleteAutovehicule(AutovehiculeModel autovehiculeModel)
        {
            Autovehicule existingAutovehicule = dbContext.Autovehicules.FirstOrDefault(x => x.Idautovehicul == autovehiculeModel.IDAutovehicul);

            if (existingAutovehicule != null)
            {
                dbContext.Autovehicules.Remove(existingAutovehicule);
                dbContext.SaveChanges();
            }
        }
        private AutovehiculeModel MapDbObjectToModel(Autovehicule dbAutovehicule)
        {
            AutovehiculeModel autovehiculeModel = new AutovehiculeModel();

            if (dbAutovehicule != null)
            {
                autovehiculeModel.IDAutovehicul = dbAutovehicule.Idautovehicul;
                autovehiculeModel.Marca = dbAutovehicule.Marca;
                autovehiculeModel.NumarLocuri = dbAutovehicule.NumarLocuri;
                autovehiculeModel.Disponibilitate = dbAutovehicule.Disponibilitate;
                autovehiculeModel.PretZi = dbAutovehicule.PretZi;
                autovehiculeModel.Valuta = dbAutovehicule.Valuta;

            }

            return autovehiculeModel;
        }

        private Autovehicule MapModelToDbObject(AutovehiculeModel autovehiculeModel)
        {
            Autovehicule autovehicule = new Autovehicule();

            if (autovehiculeModel != null)
            {
                autovehicule.Idautovehicul = autovehiculeModel.IDAutovehicul;
                autovehicule.Marca = autovehiculeModel.Marca;
                autovehicule.NumarLocuri = autovehiculeModel.NumarLocuri;
                autovehicule.Disponibilitate = autovehiculeModel.Disponibilitate;
                autovehicule.PretZi = autovehiculeModel.PretZi;
                autovehicule.Valuta = autovehiculeModel.Valuta;





            }
            return autovehicule;

        }

    }
}
