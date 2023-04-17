namespace ToDoList.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public List<TaskList> TaskLists { get; set; } = new List<TaskList>();
    }
}
