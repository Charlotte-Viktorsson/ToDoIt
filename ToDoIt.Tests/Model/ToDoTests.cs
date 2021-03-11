using System;
using ToDoIt.Model;
using Xunit;

namespace ToDoIt.Tests.Model
{
    public class ToDoTests
    {
        [Fact]
        public void Todo_Constructor_checkAllFields()
        {
            //arrange
            string description = "baka kaka";
            int id = 1;

            //act
            Todo todo1 = new Todo(id, description);

            //assert all fields
            Assert.Equal(description, todo1.Description);
            Assert.False(todo1.Done);
            Assert.Equal(id, todo1.TodoId);
            Assert.Null(todo1.Assignee);
        }

        [Fact]
        public void Todo_ConstructNoAssignee_GetAssigneeNull()
        {
            //arrange
            string description = "Get to work.";
            int id = 1;
            Person expectedPerson = null; //= unassigned

            //act
            Todo todo1 = new Todo(id, description);
            Person myAssignedPerson = todo1.Assignee;

            //assert
            Assert.Equal(expectedPerson, myAssignedPerson);
        }

        [Fact]
        public void Todo_ConstructNullDescription_EmptyDescription()
        {
            //arrange
            string description = null;
            int id = 1;

            //act
            Todo todo1 = new Todo(id, description);

            //assert
            Assert.Equal("", todo1.Description);
        }

        [Fact]
        public void Todo_CreateEmpty_UsedDefaultValues()
        {
            //Arrange
            int expectedDefaultId = 0;
            string expectedDefaultString = "";
            
            //Act
            Todo myToDo = new Todo();
            int myToDoId = myToDo.TodoId;

            //Assert
            Assert.NotNull(myToDo);
            Assert.Equal(expectedDefaultId, myToDoId);
            Assert.Equal(expectedDefaultString, myToDo.Description);
        }

        [Fact]
        public void Todo_CreateSetDescript_GetDescript()
        {
            //Arrange
            string setStringDescription = "Go walk";
            Todo myToDo = null;
            string expectedDescription;

            //Act
            myToDo = new Todo(1, setStringDescription);
            expectedDescription = myToDo.Description;

            //Assert
            Assert.Equal(setStringDescription, expectedDescription);
        }

        [Fact]
        public void Todo_ChangeDescript_GetDescript()
        {
            //Arrange
            string originalDescription = "Run home";
            string setStringDescription = "Go walk";
            string constructedDescription;
            string changedDescription;

            //Act
            
            Todo myToDo = new Todo(1, originalDescription);
            constructedDescription = myToDo.Description;
            //change description
            myToDo.Description = setStringDescription;
            changedDescription = myToDo.Description;

            //Assert
            Assert.Equal(originalDescription, constructedDescription);
            Assert.Equal(setStringDescription, changedDescription);
        }

        [Fact]
        public void Todo_ChangeDescriptToNull_GetDescript()
        {
            //Arrange
            string originalDescription = "Run home";
            string setStringDescription = null;
            string constructedDescription;
            string changedDescription;
            string expectedChangedDescription = "";

            //Act
            Todo myToDo = new Todo(1, originalDescription);
            constructedDescription = myToDo.Description;
            //change description
            myToDo.Description = setStringDescription;
            changedDescription = myToDo.Description;

            //Assert
            Assert.Equal(originalDescription, constructedDescription);
            Assert.Equal(expectedChangedDescription, changedDescription);
        }

        [Fact]
        public void Todo_CreateSetAssignee_GetAssignee()
        {
            //Arrange
            string setStringDescription = "Go walk";
            Todo myToDo = null;
            Person myPerson = null;

            //Act
            myPerson = new Person(1, "Charlie", "Brown");
            myToDo = new Todo(1, setStringDescription);
            myToDo.Assignee = myPerson;

            //Assert
            Assert.NotNull(myToDo.Assignee);
        }

        [Fact]
        public void Todo_CreateSetDone_GetDoneOk()
        {
            //Arrange
            string setStringDescription = "Go walk";

            //Act
            Todo myToDo = new Todo(1, setStringDescription);
            myToDo.Done = true;

            //Assert
            Assert.True(myToDo.Done);
        }
    }
}
