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
            Assert.Equal(false, todo1.Done);
            Assert.Equal(id, todo1.TodoId);
            Assert.Null(todo1.Assignee);
        }
    }
}
