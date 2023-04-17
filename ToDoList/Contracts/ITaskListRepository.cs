using System.Collections.Generic;
using ToDoList.Models;
using ToDoList.Entities;

namespace ToDoList.Contracts
{
    public interface ITaskListRepository 
    {
        public IEnumerable<TaskList> GetTaskLists();
        public TaskList GetTaskList(int id);
        public TaskList CreateTaskList(TaskListInputViewModel taskList);
        public void UpdateTaskList(int id, TaskListUpdateViewModel taskList);
        public void DeleteTaskList(int id);
    }
}
