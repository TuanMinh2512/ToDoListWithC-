using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TodoList.Models;
using UseCase;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ToDoListManager _toDoListManager;

        public HomeController(ILogger<HomeController> logger, ToDoListManager toDoListManager)
        {
            _logger = logger;
            _toDoListManager = toDoListManager;
        }

        public IActionResult Index()
        {
            var todoList = _toDoListManager.getTodoItems();

            var todoModels = todoList.Select(e => new Models.Todo
            {
                id = e.id,
                text = e.text,
                isCompleted = e.isCompleted,
            });
            return View(new TodoListViewModel() { Items = todoModels });
        }

        [HttpGet]
        public IActionResult Add() 
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Todo item) 
        {
            _toDoListManager.Add(new Entity.Todo()
            {
                id = item.id,
                text = item.text,
                isCompleted = false,
            });
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _toDoListManager.Delete(id);
            return RedirectToAction("Index");  
        }

        [HttpPost]
        public IActionResult Complete(int id)
        {
            _toDoListManager.isCompleted(id);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
