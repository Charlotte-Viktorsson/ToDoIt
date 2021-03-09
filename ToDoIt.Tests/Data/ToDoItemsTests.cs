using System;
using Xunit;
using ToDoIt.Data;
using ToDoIt.Model;

namespace ToDoIt.Tests.Data
{
    public class ToDoItemsTests
    {

        [Fact]
        public void clearToDoItemsTest()
        {
            //arrange
            int expectedSizeOfToDoItems = 0;
            string description = "Tvätta kläder";

            ToDoItems todoItems = new ToDoItems();
            ToDo returnedTodo = todoItems.CreateToDoItem(null, description);
            Assert.Equal(1, todoItems.Size());

            //act
            todoItems.Clear();

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());

        }

        [Fact]
        public void createTodoItemWithAssigneeTest()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Anna";
            string familyName = "Jansson";
            Person assignee = new Person(personId, firstName, familyName);

            int expectedSizeOfToDoItems = 1;
            string description = "Tvätta bilen";
            ToDoItems todoItems = new ToDoItems();

            //act
            ToDo returnedTodo = todoItems.CreateToDoItem(assignee, description);

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());
            Assert.Equal(description, returnedTodo.Description);
        }

        [Fact]
        public void createTodoItemWithoutAssigneeTest()
        {
            //arrange
            Person assignee = null;

            int expectedSizeOfToDoItems = 1;
            string description = "Handla mat";
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //act
            ToDo returnedTodo = todoItems.CreateToDoItem(assignee, description);

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());
            Assert.Equal(description, returnedTodo.Description);
        }

        [Fact]
        public void FindAllItemsTest()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Peter";
            string familyName = "Jansson";
            Person assignee = new Person(personId, firstName, familyName);

            int expectedSizeOfToDoItems = 3;
            string description1 = "Vattna blommor";
            string description2 = "Dammsuga";
            string description3 = "Putsa fönster";

            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.CreateToDoItem(assignee, description1);
            todoItems.CreateToDoItem(assignee, description2);
            todoItems.CreateToDoItem(null, description3);

            //act
            ToDo[] itemArray = todoItems.FindAll();

            //assert
            Assert.Equal(expectedSizeOfToDoItems, itemArray.Length);
        }

        [Fact]
        public void FindItemByIdTest()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";

            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 2 items
            todoItems.CreateToDoItem(assignee, description1);
            todoItems.CreateToDoItem(assignee, description2);
            int size = todoItems.Size();

            //act
            ToDo foundItem = todoItems.FindById(size);

            //assert
            Assert.Equal(description2, foundItem.Description);
        }
    }
}
