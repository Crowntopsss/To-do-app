using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using To_do_app.Models;

namespace To_do_app.Controllers
{
    public class HomeController : Controller
    {
        private static List<ToDo> toDoList = new List<ToDo>();

        public IActionResult Index()
        {
            return View(toDoList);
        }

        [HttpPost]
        public IActionResult Add(string description)
        {
            if (!string.IsNullOrWhiteSpace(description))
            {
                var newToDo = new ToDo
                {
                    Id = Guid.NewGuid(),
                    Description = description,
                    IsDone = false,
                    CompletionDate = null,
                    CreationDate = DateTime.Now 
                };

                toDoList.Add(newToDo);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarkAsDone(Guid id)
        {
            var todo = toDoList.Find(t => t.Id == id);
            if (todo != null)
            {
                todo.IsDone = true;
                todo.CompletionDate = DateTime.Now;
            }

            return RedirectToAction("Index");
        }
    }
}
