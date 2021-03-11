using ToDoIt.Data;
using ToDoIt.Model;
using Xunit;

namespace ToDoIt.Tests
{
    public class PersonTests
    {
        [Fact]
        public void Person_CreateValidPerson_NamesOk()
        {
            //Arrange
            int myPersonID = 0;
            string myFirstName = "Bosse";
            string myLastName = "Larsson";
            string myNameResult = "Bosse Larsson";
            PersonSequencer.reset();
            
            //Act
            Person myPerson = new Person(myPersonID, myFirstName, myLastName);

            // Assert
            Assert.Equal(myNameResult, myPerson.Name);
        }

        [Fact]
        public void Person_CreateEmptyPersonName_GetEmptyStandardName()
        {
            //Arrange
            int myPersonID = 0;
            string myFirstName = "";
            string myLastName = "Larsson";
            string myNameResult = "John Larsson";
            PersonSequencer.reset();

            //Act
            Person myPerson = new Person(myPersonID, myFirstName, myLastName);

            // Assert
            Assert.Equal(myNameResult, myPerson.Name);
        }

        [Fact]
        public void Person_CreateNullLastName_GetEmptyStandardName()
        {
            //Arrange
            int myPersonID = 0;
            string myFirstName = "Bosse";
            string myLastName = null;
            string myNameResult = "Bosse Doe";
            PersonSequencer.reset();
            
            //Act
            Person myPerson = new Person(myPersonID, myFirstName, myLastName);

            // Assert
            Assert.Equal(myNameResult, myPerson.Name);
        }

        [Fact]
        public void Person_CreateNullNames_GetDefaultNames()
        {
            //Arrange
            int myPersonID = 0;
            string myFirstName = null;
            string myLastName = null;
            int myIdResult = 0;
            string myExpectedNameResult = "John Doe";

            //Act
            Person myPerson = new Person(myPersonID, myFirstName, myLastName);

            // Assert
            Assert.Equal(myIdResult, myPerson.PersonId);
            Assert.Equal(myExpectedNameResult, myPerson.Name);
        }

        [Fact]
        public void Person_CreateID_IdOk()
        {
            //Arrange
            int myPersonID = 0;
            string myFirstName = "Bosse";
            string myLastName = "Larsson";
            int myIdResult = 0;

            //Act
            Person myPerson = new Person(myPersonID, myFirstName, myLastName);

            // Assert
            Assert.Equal(myIdResult, myPerson.PersonId);
        }
    }
}
