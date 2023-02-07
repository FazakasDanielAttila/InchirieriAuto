using InchirieriAuto.Data;
using InchirieriAuto.Models;
using InchirieriAuto.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InchirieriAuto.Controllers
{
    public class AgentieController : Controller
    {
        private AgentieRepository _repository;

        public AgentieController(ApplicationDbContext dbContext)
        {
            _repository = new AgentieRepository(dbContext);
        }

        // GET: AgentieController
        public ActionResult Index()
        {
            var agenties = _repository.GetAllAgenties();
            return View("Index", agenties);

        }

        // GET: AgentieController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetAgentieByID(id);
            return View("AgentieDetails", model);

        }

        // GET: AgentieController/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View("CreateAgentie");
        }

        // POST: AgentieController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                AgentieModel model = new AgentieModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertAgentie(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateAgentie");
            }
        }

        // GET: AgentieController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetAgentieByID(id);
            return View("EditAgentie", model);
        }

        // POST: AgentieController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new AgentieModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateAgentie(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", id);
                }

            }
            catch
            {
                return View("Index", id);
            }
        }

        // GET: AgentieController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetAgentieByID(id);
            return View("DeleteAgentie", model);

        }

        // POST: AgentieController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var model = _repository.GetAgentieByID(id);

                _repository.DeleteAgentie(model);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
