using ToDoList.Entities;
using ToDoList.Models;

namespace ToDoList.Contracts
{
    public interface ICategoryRepository 
    {
        public IEnumerable<Category> GetCategories();
        public Category GetCategory(int id);
        public Category CreateCategory(CategoryInputViewModel category);
        public void UpdateCategory(int id, CategoryUpdateViewModel category);
        public void DeleteCategory(int id);
    }
}
