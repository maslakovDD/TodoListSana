using ToDoList.Entities;

namespace ToDoList.Models
{
    public class MainViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<TaskList> TaskLists { get; set; }
        public IEnumerable<TodoTask> TodoTasks { get; set; }
    }
}
