namespace ToDoIt.Data
{
    public static class TodoSequencer
    {
        private static int todoId = 0;

        /// <summary>
        /// Gives a unique next number to use in ToDo identifier field.
        /// </summary>
        /// <returns>Returns an int that is unique.</returns>
        public static int NextTodoId()
        {
            todoId += 1;
            return todoId;
        }

        /// <summary>
        /// Reset will clear the unique set of Id to zero.
        /// </summary>
        public static void Reset()
        {
            todoId = 0;
        }
    }
}
