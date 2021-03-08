using System;
using Xunit;
using ToDoIt.Model;

namespace ToDoIt.Tests
{
    public class PersonTests
    {
        [Fact]
        public void PersonCreateValidNames()
        {
            int myPersonID = 0;
            string myFirstName = "Bosse";
            string myLastName = "Larsson";
            string myNameResult = "Bosse Larsson";

            Person myPerson = new Person(myPersonID, myFirstName, myLastName);

            // Assert
            Assert.Equal(myNameResult , myPerson.Name);
        }
    


        [Fact]
        public void PersonCreateInValidNames()
        {
            int myPersonID = 0;
            string myFirstName = "";
            string myLastName = "Larsson";
            string myNameResult = "John Larsson";

            Person myPerson = new Person(myPersonID, myFirstName, myLastName);

            // Assert
            Assert.Equal(myNameResult, myPerson.Name);
        }

        [Fact]
        public void PersonCreateNullLastName()
        {
            int myPersonID = 0;
            string myFirstName = "Bosse";
            string myLastName = null;
            string myNameResult = "Bosse Doe";

            Person myPerson = new Person(myPersonID, myFirstName, myLastName);

            // Assert
            Assert.Equal(myNameResult, myPerson.Name);
        }

        [Fact]
        public void PersonCreateID()
        {
            int myPersonID = 0;
            string myFirstName = "Bosse";
            string myLastName = "Larsson";
            int myIdResult = 0;
         

            Person myPerson = new Person(myPersonID, myFirstName, myLastName);

            // Assert
            Assert.Equal(myIdResult, myPerson.PersonId);
        }
    }
}
