using ExactusLibraryApp.Models;
using ExactusLibraryApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExactusLibraryApp.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _service;
        public LocationController(ILocationService service)
        {
            _service = service;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location obj)
        {
            if(!ModelState.IsValid)
            {
                return View(obj);
            }
            var result = _service.Create(obj);
            if(result)
            {
                TempData["success"] = "Location added successfully";
                return RedirectToAction("GetAllLocations");
            }
            TempData["error"] = "An error has occured";
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var data = _service.GetLocationById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Location obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var result = _service.Edit(obj);
            if (result)
            {
                TempData["success"] = "Location updated successfully";
                return RedirectToAction("GetAllLocations");
            }
            TempData["error"] = "An error has occured";
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            return RedirectToAction("GetAllLocations");
        }

        public IActionResult GetAllLocations()
        {
            var data = _service.GetAllLocations();
            return View(data);
        }
    }
}
