using Dapper;
using System.Data;
using ToDoList.Contracts;
using ToDoList.DBContext;
using ToDoList.Entities;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class TaskListRepository : ITaskListRepository
    {
        private readonly DapperContext _context;

        public TaskListRepository(DapperContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskList> GetTaskLists()
        {
            var query = "SELECT * FROM taskList";

            using(var connection = _context.CreateConnection())
            {
                var taskLists = connection.Query<TaskList>(query);
                return taskLists.ToList();
            }
        }

        public TaskList GetTaskList(int id)
        {
            var query = "SELECT * FROM taskList WHERE id = @id";
            using(var connection = _context.CreateConnection())
            {
                var taskList =  connection.QuerySingleOrDefault<TaskList>(query, new {id});

                return taskList;
            }
        }
        public TaskList CreateTaskList(TaskListInputViewModel taskList)
        {
            var query = "INSERT INTO taskList (listName, categoryId) VALUES (@ListName, @CategoryId)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("ListName", taskList.ListName, DbType.String);
            parameters.Add("CategoryId", taskList.CategoryId, DbType.Int32);

            using(var connection = _context.CreateConnection())
            {
                var id =  connection.QuerySingle<int>(query, parameters);

                var createdTaskList = new TaskList
                {
                    Id = id,
                    ListName = taskList.ListName,
                    CategoryId = taskList.CategoryId
                };
                return createdTaskList;
            }
        }
        public void UpdateTaskList(int id, TaskListUpdateViewModel taskList)
        {
            var query = "UPDATE taskList Set listName = @ListName WHERE id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("ListName", taskList.ListName, DbType.String);

            using(var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }
        public void DeleteTaskList(int id)
        {
            var query = "DELETE FROM taskList WHERE id = @ID";

            using(var connection = _context.CreateConnection())
            {
                connection.Execute(query, new {id});
            }
        }
    }
}
