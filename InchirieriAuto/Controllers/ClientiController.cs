using InchirieriAuto.Data;
using InchirieriAuto.Models;
using InchirieriAuto.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InchirieriAuto.Controllers
{
    public class ClientiController : Controller
    {
        private ClientiRepository _repository;

        public ClientiController(ApplicationDbContext dbContext)
        {
            _repository = new ClientiRepository(dbContext);
        }


        // GET: ClientiController
        public ActionResult Index()
        {
            var clientis = _repository.GetAllClientis();
            return View("Index", clientis);

        }

        // GET: ClientiController/Details/5
        [Authorize(Roles = "Admin, User")]
        public ActionResult Details(Guid id)
        {
            var model = _repository.GetClientiByID(id);
            return View("ClientiDetails", model);

        }

        // GET: ClientiController/Create
        [Authorize(Roles = "Admin,User")]
        public ActionResult Create()
        {
            return View("CreateClienti");
        }

        // POST: ClientiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ClientiModel model = new ClientiModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.InsertClienti(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CreateClienti");
            }
        }

        // GET: ClientiController/Edit/5
        [Authorize(Roles = "Admin, User")]
        public ActionResult Edit(Guid id)
        {
            var model = _repository.GetClientiByID(id);
            return View("EditClienti", model);

        }

        // POST: ClientiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new ClientiModel();

                var task = TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _repository.UpdateClienti(model);
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

        // GET: ClientiController/Delete/5
        [Authorize(Roles = "Admin, User")]
        public ActionResult Delete(Guid id)
        {
            var model = _repository.GetClientiByID(id);
            return View("DeleteClienti", model);

        }

        // POST: ClientiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var model = _repository.GetClientiByID(id);

                _repository.DeleteClienti(model);
                return RedirectToAction("Index");


            }
            catch
            {
                return View("DeleteClienti", id);
            }
        }
    }
}
