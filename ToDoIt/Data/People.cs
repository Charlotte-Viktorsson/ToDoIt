using System;
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
            int myIndex = 0;
            bool notFound = false;
            bool justLooking = true;
            int myCollectionNumber = myPeople.Length;


            while (!notFound && justLooking)
            {
                if (myPeople[myIndex].PersonId == personId)
                {
                    justLooking = false;
                }

                myIndex++;

                if (myIndex == myCollectionNumber)
                {
                    notFound = true;
                }
            }

            if (notFound)
            {
                return null;
            }
            else
            {
                return myPeople[myIndex - 1];

            }

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

        public void Clear()
        {
            myPeople = new Person[0];
            // We will keep the uniqe Id still Uniqe
            //PersonSequencer.reset();
        }

        public void Remove(Person myPerson)
        {
            int myPeopleCollection = myPeople.Length;
            int myIndexedPerson = -1;
            bool notDone = true;
            int myLoop = 0;

            do
            {
                if (myPeople[myLoop].PersonId == myPerson.PersonId)
                {
                    notDone = false;
                    myIndexedPerson = myLoop;
                }
                myLoop++;
                if (myLoop == myPeopleCollection) notDone = false;

            } while (notDone);


            if (myIndexedPerson > -1)
            {

                for (int removeLoop = myIndexedPerson; removeLoop < myPeopleCollection - 1; removeLoop++)
                {
                    myPeople[removeLoop] = myPeople[removeLoop + 1];
                }
                Array.Resize(ref myPeople, myPeopleCollection - 1);
            }

        }

    }
}
