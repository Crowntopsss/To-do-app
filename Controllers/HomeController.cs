using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using To_do_app.Models;

namespace To_do_app.Controllers
{
    public class HomeController : Controller
    {
        private static List<ToDo> toDoList = new List<ToDo>();

        // Action to display the To-Do list
        public IActionResult Index()
        {
            return View(toDoList);
        }

        // Action to add a new To-Do
        [HttpPost]
        public IActionResult Add(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                // Create a new To-Do item
                var newToDo = new ToDo
                {
                    Id = Guid.NewGuid(),
                    Description = description,
                    IsDone = false,
                    CompletionDate = null,
                    CreationDate = DateTime.Now 
                };

                // Add the new To-Do item to the list
                toDoList.Add(newToDo);
            }

            return RedirectToAction("Index");
        }

        // Action to mark a To-Do as done
        [HttpPost]
        public IActionResult MarkAsDone(Guid id)
        {
            // Find the To-Do item by its ID
            var todo = toDoList.Find(t => t.Id == id);
            if (todo != null)
            {
                // Mark the To-Do as done and record completion date
                todo.IsDone = true;
                todo.CompletionDate = DateTime.Now;
            }

            return RedirectToAction("Index");
        }
    }
}
