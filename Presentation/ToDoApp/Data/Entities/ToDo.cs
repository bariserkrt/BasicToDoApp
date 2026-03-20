using System;
using System.Collections.Generic;
using System.Text;
using ToDoApp.Data.Enums;

namespace ToDoApp.Data.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }
        public bool IsCompleted { get; set; } 
        public ToDoStatus Status { get; set; }
    }
}
