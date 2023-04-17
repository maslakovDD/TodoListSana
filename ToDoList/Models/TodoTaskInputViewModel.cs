namespace ToDoList.Models
{
    public class TodoTaskInputViewModel
    {
        public string TaskName { get; set; }
        public int ListId { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
    }
}
