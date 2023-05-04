using ExactusLibraryApp.Models;
using ExactusLibraryApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExactusLibraryApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IStatusService _statusService;
        private readonly ILocationService _locationService;
        private readonly ITypeService _typeService;

        public BookController(IBookService bookService, IStatusService statusService, ILocationService locationService, ITypeService typeService)
        {
            _bookService = bookService;
            _statusService = statusService;
            _locationService = locationService;
            _typeService = typeService;
        }

        public IActionResult Create()
        {
            var obj = new Book();
            obj.StatusList = _statusService.GetAllStatus().Select(s => new SelectListItem { Text = s.StatusName, Value = s.Id.ToString() }).ToList();
            obj.TypeList = _typeService.GetAllTypes().Select(t => new SelectListItem { Text = t.TypeName, Value = t.Id.ToString() }).ToList();
            obj.LocationList = _locationService.GetAllLocations().Select(l => new SelectListItem { Text = l.LocationName, Value = l.Id.ToString() }).ToList();

            return View(obj);
        }

        [HttpPost]
        public IActionResult Create(Book obj)
        {
            obj.StatusList = _statusService.GetAllStatus().Select(s => new SelectListItem { Text = s.StatusName, Value = s.Id.ToString(), Selected = s.Id == obj.StatusId }).ToList();
            obj.TypeList = _typeService.GetAllTypes().Select(t => new SelectListItem { Text = t.TypeName, Value = t.Id.ToString(), Selected = t.Id == obj.TypeId }).ToList();
            obj.LocationList = _locationService.GetAllLocations().Select(l => new SelectListItem { Text = l.LocationName, Value = l.Id.ToString(), Selected = l.Id == obj.LocationId }).ToList();
            
            var selectedType = _typeService.GetTypeById(obj.TypeId).TypeName;
            var selectedLocation = _locationService.GetLocationById(obj.LocationId).LocationName;
            if(selectedType == "Digital Copy" && selectedLocation.ToLower() != "In the Matrix")
            {
                ModelState.AddModelError(nameof(obj.LocationId), "A Digital Copy location should be only In The Matrix");
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View(obj);
            }
            var result = _bookService.Create(obj);
            if(result)
            {
                TempData["success"] = "Book added successfully";
                return RedirectToAction("GetAllBooks");
            }
            TempData["error"] = "An error has occured while trying to add a new book";
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var obj = _bookService.GetBookById(id);
            obj.StatusList = _statusService.GetAllStatus().Select(s => new SelectListItem { Text = s.StatusName, Value = s.Id.ToString(), Selected = s.Id == obj.StatusId }).ToList();
            obj.LocationList = _locationService.GetAllLocations().Select(l => new SelectListItem { Text = l.LocationName, Value = l.Id.ToString(), Selected = l.Id == obj.LocationId }).ToList();
            obj.TypeList = _typeService.GetAllTypes().Select(t => new SelectListItem { Text = t.TypeName, Value = t.Id.ToString(), Selected = t.Id == obj.TypeId }).ToList();
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Book obj)
        {
            obj.StatusList = _statusService.GetAllStatus().Select(s => new SelectListItem { Text = s.StatusName, Value = s.Id.ToString(), Selected = s.Id == obj.StatusId }).ToList();
            obj.LocationList = _locationService.GetAllLocations().Select(l => new SelectListItem { Text = l.LocationName, Value = l.Id.ToString(), Selected = l.Id == obj.LocationId }).ToList();
            obj.TypeList = _typeService.GetAllTypes().Select(t => new SelectListItem { Text = t.TypeName, Value = t.Id.ToString(), Selected = t.Id == obj.TypeId }).ToList();

            var selectedType = _typeService.GetTypeById(obj.TypeId).TypeName;
            var selectedLocation = _locationService.GetLocationById(obj.LocationId).LocationName;
            if (selectedType == "Digital Copy" && selectedLocation.ToLower() != "In the Matrix")
            {
                ModelState.AddModelError(nameof(obj.LocationId), "A Digital Copy location should be only In The Matrix");
            }

            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var result = _bookService.Edit(obj);
            if(result)
            {
                TempData["success"] = "Book updated successfully";
                return RedirectToAction("GetAllBooks");
            }
            TempData["error"] = "An error has occured";
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            var result = _bookService.Delete(id);
            return RedirectToAction("GetAllBooks");
        }

        public IActionResult GetAllBooks()
        {
            var data = _bookService.GetAllBooks();
            return View(data);
        }
    }
}
