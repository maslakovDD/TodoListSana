using Dapper;
using System.Data;
using ToDoList.Contracts;
using ToDoList.DBContext;
using ToDoList.Entities;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DapperContext _context;
        public CategoryRepository(DapperContext context)
        {
            _context = context;
        }

        public Category CreateCategory(CategoryInputViewModel category)
        {
            var query = "INSERT INTO category (categoryName) VALUES (@CategoryName)" + 
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("CategoryName", category.CategoryName, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                var id =  connection.QuerySingle<int>(query, parameters);

                var createdCategory = new Category
                {
                    Id = id,
                    CategoryName = category.CategoryName
                };
                return createdCategory;
            }
        }

        public void DeleteCategory(int id)
        {
            var query = "DELETE FROM category WHERE id = @Id";
            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, new { id });
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            var query = "SELECT * FROM category";

            using (var connection = _context.CreateConnection())
            {
                var categories = connection.Query<Category>(query);
                return categories.ToList();
            }
        }
       
        public Category GetCategory(int id)
        {
            var query = "SELECT * FROM category WHERE id = @Id";
            using(var connection = _context.CreateConnection())
            {
                var category = connection.QuerySingleOrDefault<Category>(query, new { id });
                return category;
            }
        }
        
        public void UpdateCategory(int id, CategoryUpdateViewModel category)
        {
            var query = "UPDATE category SET categoryName = @CategoryName WHERE id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("CategoryName", category.CategoryName, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }
    }
}
