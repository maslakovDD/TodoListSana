using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class CategoryInputViewModel
    {
        [StringLength(25, MinimumLength =1, ErrorMessage ="Cannot be empty or more thsn 25 chars")]
        public string CategoryName { get; set; }
    }
}
