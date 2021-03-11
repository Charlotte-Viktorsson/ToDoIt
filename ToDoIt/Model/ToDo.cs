﻿namespace ToDoIt.Model
{
    public class Todo
    {
        readonly int todoId;
        string description;
        bool done;
        Person assignee;

        /// <summary>
        /// A constructor method for create a new Todo.
        /// </summary>
        /// <param name="todoId">The unique Id for this Todo task.</param>
        /// <param name="description">The description of this Todo task.</param>
        public Todo(int todoId=0, string description="")
        {
            if (description == null)
            {
                description = "";
            }
            this.todoId = todoId;
            this.description = description;
            this.done = false;
            this.assignee = null;
        }

        /// <summary>
        /// A get for the unique Id of this Todo task.
        /// </summary>
        public int TodoId
        {
            get { return todoId; }
            //since todoId is readonly, it can't be changed
        }

        /// <summary>
        /// Methods for the description of this Todo task
        /// </summary>
        public string Description
        {
            get { return description; }
            set {
                if (value == null)
                {
                    description = "";
                }
                else
                {
                    description = value;
                }
            }
        }

        /// <summary>
        /// A marker of the Todo task done or not done.
        /// </summary>
        public bool Done
        {
            get { return done; }
            set { done = value; }
        }

        /// <summary>
        /// Methods for the person that is assigned to the Todo task.
        /// For an unassigned Todo, assignee can be set to null
        /// </summary>
        public Person Assignee
        {
            get { return assignee; }
            set { assignee = value; }
        }
    }
}
