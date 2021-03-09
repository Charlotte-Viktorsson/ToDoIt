namespace ToDoIt.Model
{
    public class Person
    {
        private readonly int personId;
        private string firstName;
        private string lastName;

        /// <summary>
        /// Person is constructor for a Person. Sets up a persons initial
        /// values. If no name input, a default name will be assigned to person.
        /// </summary>
        /// <param name="myPersonId">The unique Id for this person.</param>
        /// <param name="myFirstName">The first name of this person.</param>
        /// <param name="myLastName">The last or family name of this person.</param>
        public Person(int myPersonId, string myFirstName, string myLastName)
        {
            personId = myPersonId;

            // have to check for Null or empty strings
            if (myFirstName != null && myFirstName.Length > 0)
            {
                firstName = myFirstName;
            }
            else
            {
                firstName = "John";
            }

            // have to check for Null or empty strings
            if (myLastName != null && myLastName.Length > 0)
            {
                lastName = myLastName;
            }
            else
            {
                lastName = "Doe";
            };


        }

        /// <summary>
        /// A get full name of this person.
        /// </summary>
        public string Name
        {
            get { return firstName + " " + lastName; }
        }

        /// <summary>
        /// A get personal Id from this person.
        /// </summary>
        public int PersonId
        {
            get { return personId; }
        }

    }
}

