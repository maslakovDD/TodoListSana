namespace ToDoList.Entities
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public int ListId { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
    }
}
