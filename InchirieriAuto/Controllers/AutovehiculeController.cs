using InchirieriAuto.Data;
using InchirieriAuto.Models;
using InchirieriAuto.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InchirieriAuto.Controllers
{
    public class AutovehiculeController : Controller
    {
        private AutovehiculeRepository _repository;

        public AutovehiculeController(ApplicationDbContext dbContext)
        {
            _repository = new AutovehiculeRepository(dbContext);
        }

        // GET: AutovehiculeController
        public ActionResult Index()
        {
            var autovehicules = _repository.GetAllAutovehicules();
            return View("Index", autovehicules);

        }

        // GET: AutovehiculeController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetAutovehiculeByID(id);
            return View("AutovehiculeDetails", model);

        }

        // GET: AutovehiculeController/Create
        [Authorize(Roles = "User")]
        public ActionResult Create()
        {
            return View("CreateAutovehicule");
        }

        // POST: AutovehiculeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                AutovehiculeModel model = new AutovehiculeModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertAutovehicule(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateAutovehicule");
            }
        }

        // GET: AutovehiculeController/Edit/5
        [Authorize(Roles = "User")]
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetAutovehiculeByID(id);
            return View("EditAutovehicule", model);


        }

        // POST: AutovehiculeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new AutovehiculeModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateAutovehicule(model);
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

        // GET: AutovehiculeController/Delete/5
        [Authorize(Roles = "User")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetAutovehiculeByID(id);
            return View("DeleteAutovehicule", model);

        }

        // POST: AutovehiculeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var model = _repository.GetAutovehiculeByID(id);

                _repository.DeleteAutovehicule(model);
                return RedirectToAction("Index");

            }
            catch
            {
                return View("DeleteAutovehicule");
            }
        }
    }
}
