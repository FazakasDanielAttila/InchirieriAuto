using InchirieriAuto.Data;
using InchirieriAuto.Models.DBObjects;
using InchirieriAuto.Models;

namespace InchirieriAuto.Repository
{
    public class AgentieRepository
    {
        private ApplicationDbContext dbContext;

        public AgentieRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public AgentieRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<AgentieModel> GetAllAgenties()
        {
            List<AgentieModel> agentieList = new List<AgentieModel>();

            foreach (Agentie dbAgentie in dbContext.Agenties)
            {
                agentieList.Add(MapDbObjectToModel(dbAgentie));
            }

            return agentieList;

        }

        public AgentieModel GetAgentieByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Agenties.FirstOrDefault(x => x.Idagentie == ID));
        }

        public void InsertAgentie(AgentieModel agentieModel)
        {
            agentieModel.IDAgentie = Guid.NewGuid();

            dbContext.Agenties.Add(MapModelToDbObject(agentieModel));
            dbContext.SaveChanges();
        }

        public void UpdateAgentie(AgentieModel agentieModel)
        {
            Agentie existingAgentie = dbContext.Agenties.FirstOrDefault(x => x.Idagentie == agentieModel.IDAgentie);

            if (existingAgentie != null)
            {
                existingAgentie.Idagentie = agentieModel.IDAgentie;
                existingAgentie.NumeAgentie = agentieModel.NumeAgentie;
                existingAgentie.Judet = agentieModel.Judet;
                existingAgentie.Oras = agentieModel.Oras;
                existingAgentie.Adresa = agentieModel.Adresa;
                existingAgentie.NumarTelefon = agentieModel.NumarTelefon;
                existingAgentie.Email = agentieModel.Email;


                dbContext.SaveChanges();


            }
        }

        public void DeleteAgentie(AgentieModel agentieModel)
        {
            Agentie existingAgentie = dbContext.Agenties.FirstOrDefault(x => x.Idagentie == agentieModel.IDAgentie);

            if (existingAgentie != null)
            {
                dbContext.Agenties.Remove(existingAgentie);
                dbContext.SaveChanges();
            }
        }
        private AgentieModel MapDbObjectToModel(Agentie dbAgentie)
        {
            AgentieModel agentieModel = new AgentieModel();

            if (dbAgentie != null)
            {
                agentieModel.IDAgentie = dbAgentie.Idagentie;
                agentieModel.NumeAgentie = dbAgentie.NumeAgentie;
                agentieModel.Judet = dbAgentie.Judet;
                agentieModel.Oras = dbAgentie.Oras;
                agentieModel.Adresa = dbAgentie.Adresa;
                agentieModel.NumarTelefon = dbAgentie.NumarTelefon;
                agentieModel.Email = dbAgentie.Email;

            }

            return agentieModel;
        }

        private Agentie MapModelToDbObject(AgentieModel agentieModel)
        {
            Agentie agentie = new Agentie();

            if (agentieModel != null)
            {
                agentie.Idagentie = agentieModel.IDAgentie;
                agentie.NumeAgentie = agentieModel.NumeAgentie;
                agentie.Judet = agentieModel.Judet;
                agentie.Oras = agentieModel.Oras;
                agentie.Adresa = agentieModel.Adresa;
                agentie.NumarTelefon = agentieModel.NumarTelefon;
                agentie.Email = agentieModel.Email;

            }

            return agentie;
        }

    }
}
