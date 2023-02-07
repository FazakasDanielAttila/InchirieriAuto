using InchirieriAuto.Data;
using InchirieriAuto.Models;
using InchirieriAuto.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InchirieriAuto.Controllers
{
    public class RezervareController : Controller
    {
        private RezervareRepository _repository;

        public RezervareController(ApplicationDbContext dbContext)
        {
            _repository = new RezervareRepository(dbContext);
        }

        // GET: RezervareController
        public ActionResult Index()
        {
            var rezervares = _repository.GetAllRezervares();
            return View("Index", rezervares);

        }

        // GET: RezervareController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetRezervareByID(id);
            return View("RezervareDetails", model);


        }

        // GET: RezervareController/Create
        [Authorize(Roles = "Admin,User")]
        public ActionResult Create()
        {
            return View("CreateRezervare");
        }

        // POST: RezervareController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                RezervareModel model = new RezervareModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertRezervare(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateRezervare");
            }
        }

        // GET: RezervareController/Edit/5
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetRezervareByID(id);
            return View("EditRezervare", model);

        }

        // POST: RezervareController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new RezervareModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateRezervare(model);
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

        // GET: RezervareController/Delete/5
        [Authorize(Roles = "Admin, User")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetRezervareByID(id);
            return View("DeleteRezervare", model);

        }

        // POST: RezervareController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var model = _repository.GetRezervareByID(id);

                _repository.DeleteRezervare(model);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
