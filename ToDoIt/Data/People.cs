using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt.Data;
using ToDoIt.Model;

namespace ToDoIt.Data
{
    public class People
    {
        private static Person[] myPeople;

        public People()
        {
            myPeople = new Person[0];
        }

        public int Size()
        {
            return myPeople.Length;
        }

        public Person[] FindAll()
        {
            return myPeople;
        }

        public Person FindById(int personId)
        {
            // What will happen if Id is out of range??
            return myPeople[personId-1];
        }

        /// <summary>
        /// AddPerson creates a new person and inserts it into the existing array of
        /// persons in the people collection.
        /// </summary>
        /// <param name="firstName">The actual first name of person.</param>
        /// <param name="lastName">The actual last name of person.</param>
        /// <returns>Returns the object of the created person.</returns>
        public Person AddPerson(string firstName, string lastName)
        {
            int indexedPersonId = PersonSequencer.nextPersonId();
            Person newPerson = new Person(indexedPersonId, firstName, lastName);

            // Now extend the Array by one so insert is possible
            int lengthOfField = myPeople.Length;
            Array.Resize(ref myPeople, lengthOfField + 1);
            myPeople[lengthOfField] = newPerson;

            return newPerson;
        }

    }
}
