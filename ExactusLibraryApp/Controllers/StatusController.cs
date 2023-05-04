using ExactusLibraryApp.Models;
using ExactusLibraryApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExactusLibraryApp.Controllers
{
    public class StatusController : Controller
    {
        private readonly IStatusService _service;
        public StatusController(IStatusService service)
        {
            _service = service;
        }

        public IActionResult GetAllStatus()
        {
            var data = _service.GetAllStatus();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Status obj)
        {
            if(!ModelState.IsValid)
            {
                return View(obj);
            }
            var result = _service.Create(obj);
            if(result)
            {
                TempData["success"] = "Status added successfully";
                return RedirectToAction("GetAllStatus");
            }
            TempData["error"] = "An error has occured";
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var data = _service.GetStatusById(id);
            return View(data); 
        }

        [HttpPost]
        public IActionResult Edit(Status obj)
        {
            if(!ModelState.IsValid)
            {
                return View(obj);
            }
            var result = _service.Edit(obj);
            if(result)
            {
                TempData["success"] = "Status updated successfully";
                return RedirectToAction("GetAllStatus");
            }
            TempData["error"] = "An error has occured";
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            return RedirectToAction("GetAllStatus");
        }
    }
}
