using ExactusLibraryApp.Models;
using ExactusLibraryApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExactusLibraryApp.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _service;
        public CommentController(ICommentService service)
        {
            _service = service;
        }

        public IActionResult GetAllComments()
        {
            var data = _service.GetAllComments();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Comment obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var result = _service.Create(obj);
            if (result)
            {
                TempData["success"] = "Comment added successfully";
                return RedirectToAction("GetAllComments");
            }
            TempData["error"] = "An error has occured";
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            var data = _service.GetCommentById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Comment obj)
        {
            if (!ModelState.IsValid)
            {
                return View(obj);
            }
            var result = _service.Edit(obj);
            if (result)
            {
                TempData["success"] = "Comment updated successfully";
                return RedirectToAction("GetAllComments");
            }
            TempData["error"] = "An error has occured";
            return View(obj);
        }
    }
}
