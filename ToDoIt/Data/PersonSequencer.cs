namespace ToDoIt.Data
{
    public class PersonSequencer
    {
        private static int personId;


        /// <summary>
        /// nextPersonId gives you the next free number available for idetification of a person.
        /// </summary>
        /// <returns>Returns a new int number by every call.</returns>
        public static int nextPersonId()
        {
            return ++personId;
        }

        /// <summary>
        /// The reset clear the numbering and restets the Id to zero.
        /// </summary>
        public static void reset()
        {
            personId = 0;
        }
    }
}
