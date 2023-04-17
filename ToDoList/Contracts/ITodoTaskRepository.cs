using ToDoList.Entities;
using ToDoList.Models;

namespace ToDoList.Contracts
{
    public interface ITodoTaskRepository 
    {
        public IEnumerable<TodoTask> GetTodoTasks();
        public TodoTask GetTodoTask(int id);
        public TodoTask CreateTodoTask(TodoTaskInputViewModel todoTask);
        public void UpdateTodoTask(int id, TodoTaskUpdateViewModel todoTask);
        public void DeleteTodoTask(int id);
        public void CompleteTodoTask(int id);
        public void UncompleteTodoTask(int id);
    }
}
