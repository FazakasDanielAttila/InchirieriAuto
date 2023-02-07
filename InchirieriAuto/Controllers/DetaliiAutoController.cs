using InchirieriAuto.Data;
using InchirieriAuto.Models;
using InchirieriAuto.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InchirieriAuto.Controllers
{
    public class DetaliiAutoController : Controller
    {
        private DetaliiAutoRepository _repository;

        public DetaliiAutoController(ApplicationDbContext dbContext)
        {
            _repository = new DetaliiAutoRepository(dbContext);
        }

        // GET: DetaliiAutoController
        public ActionResult Index()
        {
            var detaliiAutos = _repository.GetAllDetaliiAutos();
            return View("Index", detaliiAutos);

        }

        // GET: DetaliiAutoController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetDetaliiAutoByID(id);
            return View("DetailsDetaliiAuto", model);

        }

        // GET: DetaliiAutoController/Create
        [Authorize(Roles = "User")]
        public ActionResult Create()
        {
            return View("CreateDetaliiAuto");
        }

        // POST: DetaliiAutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                DetaliiAutoModel model = new DetaliiAutoModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertDetaliiAuto(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateDetaliiAuto");
            }
        }

        // GET: DetaliiAutoController/Edit/5
        [Authorize(Roles = "User")]
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetDetaliiAutoByID(id);
            return View("EditDetaliiAuto", model);

        }

        // POST: DetaliiAutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new DetaliiAutoModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateDetaliiAuto(model);
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

        // GET: DetaliiAutoController/Delete/5
        [Authorize(Roles = "User")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetDetaliiAutoByID(id);
            return View("DeleteDetaliiAuto", model);

        }

        // POST: DetaliiAutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var model = _repository.GetDetaliiAutoByID(id);

                _repository.DeleteDetaliiAuto(model);
                return RedirectToAction("Index");

            }
            catch
            {
                return View("DeleteDetaliiAuto", id);
            }
        }
    }
}
