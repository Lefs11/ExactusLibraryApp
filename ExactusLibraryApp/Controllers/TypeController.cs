using ExactusLibraryApp.Models;
using ExactusLibraryApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExactusLibraryApp.Controllers
{
    public class TypeController : Controller
    {
        private readonly ITypeService _service;
        public TypeController(ITypeService service)
        {
            _service = service;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookType obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var result = _service.Create(obj);
            if (result)
            {
                TempData["success"] = "Type added successfully";
                return RedirectToAction("GetAllTypes");
            }
            TempData["error"] = "An error has occured";
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var data = _service.GetTypeById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(BookType obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var result = _service.Edit(obj);
            if (result)
            {
                TempData["success"] = "Type updated successfully";
                return RedirectToAction("GetAllTypes");
            }
            TempData["error"] = "An error has occured";
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            return RedirectToAction("GetAllTypes");
        }

        public IActionResult GetAllTypes()
        {
            var data = _service.GetAllTypes();
            return View(data);
        }
    }
}
