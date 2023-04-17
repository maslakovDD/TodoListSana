namespace ToDoList.Entities
{
    public class TaskList
    {
        public int Id { get; set; }
        public string ListName { get; set; }
        public int CategoryId { get; set; }

        public List<TodoTask> TodoTasks { get; set; } = new List<TodoTask>();
    }
}
