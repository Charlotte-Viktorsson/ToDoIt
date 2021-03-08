using System;
using ToDoIt.Model;
using Xunit;

namespace ToDoIt.Tests.Model
{
    public class ToDoTests
    {
        [Fact]
        public void CreateToDoTest()
        {
            //arrange
            string description = "baka kaka";
            int id = 1;

            //act
            ToDo todo1 = new ToDo(id, description);

            //assert
            Assert.Equal(description, todo1.Description);
            Assert.False(todo1.Done);
            Assert.Equal(id, todo1.TodoId);
            Assert.Null(todo1.Assignee);
        }

        [Fact]
        public void ToDoTest_ConstructNoAssignee_GetAssigneeNull()
        {
            //arrange
            string description = "Get to work.";
            int id = 1;
            Person expectedPerson = null;

            //act
            ToDo todo1 = new ToDo(id, description);
            Person myAssignedPerson = todo1.Assignee;

            //assert
            Assert.Equal(expectedPerson, myAssignedPerson);

        }

    }
}
