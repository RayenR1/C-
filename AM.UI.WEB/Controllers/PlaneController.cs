using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AM.ApplicationCore.Domain;

namespace AM.UI.WEB.Controllers
{
    public class PlaneController : Controller
    {
        private readonly IServicePlane _planeService;
        public PlaneController(IServicePlane planeService)
        {
            _planeService = planeService;
        }
        // GET: PlaneController
        public ActionResult Index()
        {
            return View(_planeService.GetAll().ToList());
        }

        // GET: PlaneController/Details/5
        public ActionResult Details(int id)
        {
            return View(_planeService.GetById(id));
        }
        public ActionResult Create()
        {
           return View();
            
        }
        // GET: PlaneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plane plane )
        {
            try
            {
                _planeService.Add(plane);
                _planeService.Commit();
                return RedirectToAction(nameof(Index));
            }catch
            {
                return View();
            }
        }

        //// POST: PlaneController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: PlaneController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_planeService.GetById(id));
        }

        // POST: PlaneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Plane plane)
        {
            try
            {
                _planeService.Update(plane);
                _planeService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_planeService.GetById(id));
        }

        // POST: PlaneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Plane plane)
        {
            try
            {
                _planeService.Delete(plane);
                _planeService.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
