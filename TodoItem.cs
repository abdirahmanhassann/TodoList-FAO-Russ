using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    public class TodoItem
    {
        public int Id { get; set; }        
        public string Username { get; set; }
        public string Password { get; set; }

        public List<TaskItem> Tasks { get; set; } = new();
        public string Title { get; set; }

        public string Description { get; set; } 
        public bool IsCompleted { get; set; }

    }
    public class TaskItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

}
