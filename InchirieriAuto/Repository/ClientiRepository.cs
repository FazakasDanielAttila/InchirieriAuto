using InchirieriAuto.Data;
using InchirieriAuto.Models.DBObjects;
using InchirieriAuto.Models;

namespace InchirieriAuto.Repository
{
    public class ClientiRepository
    {
        private ApplicationDbContext dbContext;

        public ClientiRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public ClientiRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<ClientiModel> GetAllClientis()
        {
            List<ClientiModel> clientiList = new List<ClientiModel>();

            foreach (Clienti dbClienti in dbContext.Clientis)
            {
                clientiList.Add(MapDbObjectToModel(dbClienti));
            }

            return clientiList;

        }

        public ClientiModel GetClientiByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Clientis.FirstOrDefault(x => x.Idclient == ID));
        }

        public void InsertClienti(ClientiModel clientiModel)
        {
            clientiModel.IDClient = Guid.NewGuid();

            dbContext.Clientis.Add(MapModelToDbObject(clientiModel));
            dbContext.SaveChanges();
        }

        public void UpdateClienti(ClientiModel clientiModel)
        {
            Clienti existingClienti = dbContext.Clientis.FirstOrDefault(x => x.Idclient == clientiModel.IDClient);

            if (existingClienti != null)
            {
                existingClienti.Idclient = clientiModel.IDClient;
                existingClienti.Nume = clientiModel.Nume;
                existingClienti.Prenume = clientiModel.Prenume;
                existingClienti.Judet = clientiModel.Judet;
                existingClienti.Oras = clientiModel.Oras;
                existingClienti.Adresa = clientiModel.Adresa;
                existingClienti.NumarTelefon = clientiModel.NumarTelefon;
                existingClienti.Email = clientiModel.Email;
                existingClienti.Cnp = clientiModel.CNP;


                dbContext.SaveChanges();


            }
        }

        public void DeleteClienti(ClientiModel clientiModel)
        {
            Clienti existingClienti = dbContext.Clientis.FirstOrDefault(x => x.Idclient == clientiModel.IDClient);

            if (existingClienti != null)
            {
                dbContext.Clientis.Remove(existingClienti);
                dbContext.SaveChanges();
            }
        }
        private ClientiModel MapDbObjectToModel(Clienti dbClienti)
        {
            ClientiModel clientiModel = new ClientiModel();

            if (dbClienti != null)
            {
                clientiModel.IDClient = dbClienti.Idclient;
                clientiModel.Nume = dbClienti.Nume;
                clientiModel.Prenume = dbClienti.Prenume;
                clientiModel.Judet = dbClienti.Judet;
                clientiModel.Oras = dbClienti.Oras;
                clientiModel.Adresa = dbClienti.Adresa;
                clientiModel.NumarTelefon = dbClienti.NumarTelefon;
                clientiModel.Email = dbClienti.Email;
                clientiModel.CNP = dbClienti.Cnp;


            }
            return clientiModel;
        }

        private Clienti MapModelToDbObject(ClientiModel clientiModel)
        {
            Clienti clienti = new Clienti();

            if (clientiModel != null)
            {
                clienti.Idclient = clientiModel.IDClient;
                clienti.Nume = clientiModel.Nume;
                clienti.Prenume = clientiModel.Prenume;
                clienti.Judet = clientiModel.Judet;
                clienti.Oras = clientiModel.Oras;
                clienti.Adresa = clientiModel.Adresa;
                clienti.NumarTelefon = clientiModel.NumarTelefon;
                clienti.Email = clientiModel.Email;
                clienti.Cnp = clientiModel.CNP;

            }

            return clienti;
        }

    }
}
