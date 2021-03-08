using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt.Model
{
    public class ToDo
    {
        readonly int todoId;
        string description;
        bool done;
        Person assignee;

        public ToDo(int todoId, string description)
        {
            this.todoId = todoId;
            this.description = description;
            this.done = false;
        }

        public int TodoId
        {
            get { return todoId; }
        }

        public string Description 
        {
            get { return description; }
            set { description = value; } 
        }

        public bool Done 
        {
            get { return done; }
            set { done = value; }
        }

        public Person Assignee
        {
            get { return assignee; }
            set { assignee = value; }
        }
    }
}
