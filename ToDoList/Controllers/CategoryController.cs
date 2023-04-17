using Microsoft.AspNetCore.Mvc;
using ToDoList.Contracts;
using ToDoList.Models;
using ToDoList.Entities;
namespace ToDoList.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryInputViewModel category)
        {
            try
            {
                _categoryRepo.CreateCategory(category);
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryRepo.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Edit(int id)
        {
            Category category = _categoryRepo.GetCategory(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(int id, CategoryUpdateViewModel category)
        {
            try
            {
                _categoryRepo.UpdateCategory(id, category);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
