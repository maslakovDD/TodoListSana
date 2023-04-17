using Dapper;
using System.Data;
using System.Diagnostics;
using ToDoList.Contracts;
using ToDoList.DBContext;
using ToDoList.Entities;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class TodoTaskRepository : ITodoTaskRepository
    {
        private readonly DapperContext _context;

        public TodoTaskRepository(DapperContext context)
        {
            _context = context;
        }
        
        public IEnumerable<TodoTask> GetTodoTasks()
        {
            var query = "SELECT * FROM task";

            using (var connection = _context.CreateConnection())
            {
                var todoTasks =  connection.Query<TodoTask>(query);
                return todoTasks.ToList();
            }
        }
        public TodoTask GetTodoTask(int id)
        {
            var query = "SELECT * FROM task WHERE id = @id";
            using (var connection = _context.CreateConnection())
            {
                var todoTask =  connection.QuerySingleOrDefault<TodoTask>(query, new { id });

                return todoTask;
            }
        }
        public TodoTask CreateTodoTask(TodoTaskInputViewModel todoTask)
        {
            var query = "INSERT INTO task (taskName, listId, dueDate, completed) VALUES (@TaskName, @ListId, @DueDate, @Completed)" +
               "SELECT CAST(SCOPE_IDENTITY() as int)";

            var parameters = new DynamicParameters();
            parameters.Add("TaskName", todoTask.TaskName, DbType.String);
            parameters.Add("ListId", todoTask.ListId, DbType.Int32);
            parameters.Add("DueDate", todoTask.DueDate, DbType.DateTime);
            parameters.Add("Completed", todoTask.Completed, DbType.Boolean);

            using(var connection = _context.CreateConnection())
            {
                var id =  connection.QuerySingle<int>(query, parameters);
                var createdTodoTask = new TodoTask
                {
                    Id = id,
                    TaskName = todoTask.TaskName,
                    ListId = todoTask.ListId,
                    DueDate = todoTask.DueDate,
                    Completed = todoTask.Completed,
                };
                return createdTodoTask;
            }
        }

        public void DeleteTodoTask(int id)
        {
            var query = "DELETE FROM task WHERE id = @Id";

            using(var connection = _context.CreateConnection())
            {
                 connection.Execute(query, new { id });
            }
        }

        public void UpdateTodoTask(int id, TodoTaskUpdateViewModel todoTask)
        {
            var query = "UPDATE task Set taskName = @TaskName, dueDate = @DueDate WHERE id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("TaskName", todoTask.TaskName, DbType.String);
            parameters.Add("DueDate", todoTask.DueDate, DbType.DateTime);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public void CompleteTodoTask(int id)
        {
            var query = "UPDATE task Set completed = @Completed WHERE id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Completed", true, DbType.Boolean);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }

        public void UncompleteTodoTask(int id)
        {
            var query = "UPDATE task Set completed = @Completed WHERE id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Completed", false, DbType.Boolean);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
            }
        }
    }
}
