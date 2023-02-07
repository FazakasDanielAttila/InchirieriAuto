using InchirieriAuto.Data;
using InchirieriAuto.Models;
using InchirieriAuto.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InchirieriAuto.Controllers
{
    public class AngajatiController : Controller
    {
        private AngajatiRepository _repository;

        public AngajatiController(ApplicationDbContext dbContext)
        {
            _repository = new AngajatiRepository(dbContext);
        }

        // GET: AngajatiController
        public ActionResult Index()
        {
            var angajatis = _repository.GetAllAngajatis();
            return View("Index", angajatis);

        }

        // GET: AngajatiController/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetAngajatisByID(id);
            return View("AngajatiDetails", model);

        }

        // GET: AngajatiController/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View("CreateAngajati");
        }

        // POST: AngajatiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                AngajatiModel model = new AngajatiModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertAngajati(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateAngajati");
            }
        }

        // GET: AngajatiController/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetAngajatisByID(id);
            return View("EditAngajati", model);

        }

        // POST: AngajatiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new AngajatiModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateAngajati(model);
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

        // GET: AngajatiController/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetAngajatisByID(id);
            return View("DeleteAngajati", model);

        }

        // POST: AngajatiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var model = _repository.GetAngajatisByID(id);

                _repository.DeleteAngajati(model);
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }
    }
}
