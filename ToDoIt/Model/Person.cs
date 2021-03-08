using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoIt.Model
{
    public class Person
    {
        private readonly int personId;
        private string firstName;
        private string lastName;

        public Person(int myPersonId, string myFirstName, string myLastName)
        {
            personId = myPersonId; 

            // have to check for Null or enpty strings
            if (myFirstName != null && myFirstName.Length > 0)
            {
                firstName = myFirstName;
            }
            else
            {
                firstName = "John";
            }
            
            // have to check for Null or enpty strings
            if (myLastName != null && myLastName.Length > 0)
            {
                lastName = myLastName;
            }
            else
            {
                lastName = "Doe";
            };

            
        }

        public string Name {
            get { return firstName + " " + lastName; }
        }

        public int PersonId {
            get { return personId;  }
        }

    }
}

