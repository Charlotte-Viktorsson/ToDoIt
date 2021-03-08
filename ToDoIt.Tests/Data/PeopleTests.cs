using System;
using Xunit;
using ToDoIt.Data;
using ToDoIt.Model;

namespace ToDoIt.Tests.Data
{
    public class PeopleTests
    {
        [Fact]
        public void Person_ConstructorGetSize_Zero()
        {
            //Arrange
            People myPeopleCollection = new People();
            int expectedSizeOfPeople = 0;
            //Act
            int myLengthOfPeople = myPeopleCollection.Size();
            //Assert
            Assert.Equal(expectedSizeOfPeople, myLengthOfPeople);
        }

        [Fact]
        public void AddPerson_OnlyOnePersonAdd_OnlyOnePersonIn()
        {
            //Arrange
            People myPeopleCollection = null;
            int myFirstTotalNrPersons = 0;
            Person onePerson = null;
            int mySecondTotalNrPersons = 0;

            int myExpectedNumberOfPersons = 1;

            //Act
            myPeopleCollection = new People();
            myFirstTotalNrPersons = myPeopleCollection.Size();
            onePerson = myPeopleCollection.AddPerson("Abel", "Jonsson");
            mySecondTotalNrPersons = myPeopleCollection.Size();

            //Assert
            Assert.NotEqual(myFirstTotalNrPersons, mySecondTotalNrPersons);
            Assert.Equal(myExpectedNumberOfPersons, mySecondTotalNrPersons);
        }

        [Fact]
        public void AddPerson_OnlyOnPersonAdd_DataInPersonRight()
        {
            //Arrange
            People myPeopleCollection = null;
            Person onePerson = null;
            int myFirstTotalNrPersons = 0;

            string myExpectedName = "Abel Jonsson";

            //Act
            myPeopleCollection = new People();
            onePerson = myPeopleCollection.AddPerson("Abel", "Jonsson");

            myFirstTotalNrPersons = myPeopleCollection.Size();
            onePerson = myPeopleCollection.FindById(myFirstTotalNrPersons);

            //Assert
            Assert.Equal(myExpectedName, onePerson.Name);

        }

        [Fact]
        public void Clear_AddPersonsClear_AllGone()
        {
            //Arrange
            People myPeopleCollection = null;
            int myFirstTotalNrPersons = 0;
            int mySecondTotalNrPersons = 0;
            int myExpectedNrOfPersons = 0;

            //Act
            myPeopleCollection = new People();
            myPeopleCollection.AddPerson("Abel", "Jonsson");
            myPeopleCollection.AddPerson("Ronja", "Axelsson");
            myPeopleCollection.AddPerson("Gottfrid", "Larsson");
            myFirstTotalNrPersons = myPeopleCollection.Size();
            myPeopleCollection.Clear();
            mySecondTotalNrPersons = myPeopleCollection.Size();


            //Assert
            Assert.NotEqual(myFirstTotalNrPersons, mySecondTotalNrPersons);
            Assert.Equal(myExpectedNrOfPersons, mySecondTotalNrPersons);

        }

    }
}
