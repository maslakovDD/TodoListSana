using Microsoft.AspNetCore.Mvc;
using ToDoList.Contracts;
using ToDoList.Entities;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TaskListController : Controller
    {
        private readonly ITaskListRepository _taskListRepo;

        public TaskListController(ITaskListRepository taskListRepo)
        {
            _taskListRepo = taskListRepo;
        }
        [HttpGet]
        public IActionResult Create(int categoryId)
        {
            return View(categoryId);
        }
        [HttpPost]
        public IActionResult Create(TaskListInputViewModel taskList)
        {
            try
            {
                _taskListRepo.CreateTaskList(taskList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            TaskList taskList = _taskListRepo.GetTaskList(id);
            return View(taskList);
        }
        [HttpPost]
        public IActionResult Edit(int id, TaskListUpdateViewModel taskList)
        {
            try
            {
                _taskListRepo.UpdateTaskList(id, taskList);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _taskListRepo.DeleteTaskList(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
