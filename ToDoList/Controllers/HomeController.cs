using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using ToDoList.Contracts;
using ToDoList.Repository;
using ToDoList.Entities;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITaskListRepository _taskListRepository;
        private ICategoryRepository _categoryRepository;
        private ITodoTaskRepository _todoTaskRepository;
        public HomeController(ILogger<HomeController> logger, ITaskListRepository taskListRepository, ICategoryRepository categoryRepository, ITodoTaskRepository todoTaskRepository)
        {
            _logger = logger;
            _taskListRepository = taskListRepository;
            _categoryRepository = categoryRepository;
            _todoTaskRepository = todoTaskRepository;
        }

        public IActionResult Index()
        {
            var categories = _categoryRepository.GetCategories();
            var taskLists = _taskListRepository.GetTaskLists();
            var todoTasks = _todoTaskRepository.GetTodoTasks();
            var mainViewModel = new MainViewModel
            {
                Categories = categories,
                TaskLists = taskLists,
                TodoTasks = todoTasks
            };
            return View(mainViewModel);
        }
        public IActionResult EditCategory(int id)
        {
            return View(id);
        }
        public IActionResult AddCategory()
        {
            return View();
        }
        public IActionResult AddTodoTask()
        {
            return View();
        }
        public IActionResult AddTaskList()
        {
            return View();
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