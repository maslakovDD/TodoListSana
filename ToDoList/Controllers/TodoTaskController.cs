using Microsoft.AspNetCore.Mvc;
using ToDoList.Contracts;
using ToDoList.Entities;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TodoTaskController : Controller
    {
       private readonly ITodoTaskRepository _todoTaskRepository;

        public TodoTaskController(ITodoTaskRepository todoTaskRepository)
        {
            _todoTaskRepository = todoTaskRepository;
        }

        public IActionResult Create(int taskListId)
        {
            return View(taskListId);
        }
        [HttpPost]
        public IActionResult Create(TodoTaskInputViewModel todoTask)
        {
            try
            {
                _todoTaskRepository.CreateTodoTask(todoTask);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Edit(int id)
        {
            TodoTask task = _todoTaskRepository.GetTodoTask(id);
            return View(task);
        }
        [HttpPost]
        public IActionResult Edit(int id, TodoTaskUpdateViewModel todoTask)
        {
            try
            {
                _todoTaskRepository.UpdateTodoTask(id, todoTask);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _todoTaskRepository.DeleteTodoTask(id);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Complete(int id)
        {
            try
            {
                _todoTaskRepository.CompleteTodoTask(id);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Uncomplete(int id)
        {
            try
            {
                _todoTaskRepository.UncompleteTodoTask(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
