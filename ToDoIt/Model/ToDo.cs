namespace ToDoIt.Model
{
    public class ToDo
    {
        readonly int todoId;
        string description;
        bool done;
        Person assignee;

        /// <summary>
        /// A constructor method for create a new ToDo.
        /// </summary>
        /// <param name="todoId">The unique Id for this ToDo task.</param>
        /// <param name="description">The description of this ToDo task.</param>
        public ToDo(int todoId, string description)
        {
            this.todoId = todoId;
            this.description = description;
            this.done = false;
        }

        /// <summary>
        /// A get for the unique Id of this ToDo task.
        /// </summary>
        public int TodoId
        {
            get { return todoId; }
        }

        /// <summary>
        /// A get for the descriptiton of this ToDo task
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// A marker of the ToDo task done or not done.
        /// </summary>
        public bool Done
        {
            get { return done; }
            set { done = value; }
        }

        /// <summary>
        /// A get for the person that is assigned to the ToDo task.
        /// </summary>
        public Person Assignee
        {
            get { return assignee; }
            set { assignee = value; }
        }
    }
}
