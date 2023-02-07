using InchirieriAuto.Data;
using InchirieriAuto.Models.DBObjects;
using InchirieriAuto.Models;

namespace InchirieriAuto.Repository
{
    public class DetaliiAutoRepository
    {
        private ApplicationDbContext dbContext;

        public DetaliiAutoRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public DetaliiAutoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<DetaliiAutoModel> GetAllDetaliiAutos()
        {
            List<DetaliiAutoModel> detaliiAutoList = new List<DetaliiAutoModel>();

            foreach (DetaliiAuto dbDetaliiAuto in dbContext.DetaliiAutos)
            {
                detaliiAutoList.Add(MapDbObjectToModel(dbDetaliiAuto));
            }

            return detaliiAutoList;

        }

        public DetaliiAutoModel GetDetaliiAutoByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.DetaliiAutos.FirstOrDefault(x => x.IddetaliiAuto == ID));
        }

        public void InsertDetaliiAuto(DetaliiAutoModel detaliiAutoModel)
        {
            detaliiAutoModel.IDDetaliiAuto = Guid.NewGuid();

            dbContext.DetaliiAutos.Add(MapModelToDbObject(detaliiAutoModel));
            dbContext.SaveChanges();
        }

        public void UpdateDetaliiAuto(DetaliiAutoModel detaliiAutoModel)
        {
            DetaliiAuto existinDetaliiAuto = dbContext.DetaliiAutos.FirstOrDefault(x => x.IddetaliiAuto == detaliiAutoModel.IDDetaliiAuto);

            if (existinDetaliiAuto != null)
            {
                existinDetaliiAuto.IddetaliiAuto = detaliiAutoModel.IDDetaliiAuto;
                existinDetaliiAuto.Caroserie = detaliiAutoModel.Caroserie;
                existinDetaliiAuto.NumarInmatriculare = detaliiAutoModel.NumarInmatriculare;
                existinDetaliiAuto.AnFabricatie = detaliiAutoModel.AnFabricatie;
                existinDetaliiAuto.Combustibil = detaliiAutoModel.Combutisbil;
                existinDetaliiAuto.CutieViteze = detaliiAutoModel.CutieViteze;
                existinDetaliiAuto.CapacitateCilindrica = detaliiAutoModel.CapacitateCilindrica;

                dbContext.SaveChanges();


            }
        }

        public void DeleteDetaliiAuto(DetaliiAutoModel detaliiAutoModel)
        {
            DetaliiAuto existingDetaliiAuto = dbContext.DetaliiAutos.FirstOrDefault(x => x.IddetaliiAuto == detaliiAutoModel.IDDetaliiAuto);

            if (existingDetaliiAuto != null)
            {
                dbContext.DetaliiAutos.Remove(existingDetaliiAuto);
                dbContext.SaveChanges();
            }
        }
        private DetaliiAutoModel MapDbObjectToModel(DetaliiAuto dbDetaliiAuto)
        {
            DetaliiAutoModel detaliiAutoModel = new DetaliiAutoModel();

            if (dbDetaliiAuto != null)
            {
                detaliiAutoModel.IDDetaliiAuto = dbDetaliiAuto.IddetaliiAuto;
                detaliiAutoModel.Caroserie = dbDetaliiAuto.Caroserie;
                detaliiAutoModel.NumarInmatriculare = dbDetaliiAuto.NumarInmatriculare;
                detaliiAutoModel.AnFabricatie = dbDetaliiAuto.AnFabricatie;
                detaliiAutoModel.Combutisbil = dbDetaliiAuto.Combustibil;
                detaliiAutoModel.CutieViteze = dbDetaliiAuto.CutieViteze;
                detaliiAutoModel.CapacitateCilindrica = dbDetaliiAuto.CapacitateCilindrica;
            }
            return detaliiAutoModel;
        }

        private DetaliiAuto MapModelToDbObject(DetaliiAutoModel detaliiAutoModel)
        {
            DetaliiAuto detaliiAuto = new DetaliiAuto();

            if (detaliiAutoModel != null)
            {
                detaliiAuto.IddetaliiAuto = detaliiAutoModel.IDDetaliiAuto;
                detaliiAuto.Caroserie = detaliiAutoModel.Caroserie;
                detaliiAuto.NumarInmatriculare = detaliiAutoModel.NumarInmatriculare;
                detaliiAuto.AnFabricatie = detaliiAutoModel.AnFabricatie;
                detaliiAuto.Combustibil = detaliiAutoModel.Combutisbil;
                detaliiAuto.CutieViteze = detaliiAutoModel.CutieViteze;
                detaliiAuto.CapacitateCilindrica = detaliiAutoModel.CapacitateCilindrica;
            }

            return detaliiAuto;
        }

    }
}
