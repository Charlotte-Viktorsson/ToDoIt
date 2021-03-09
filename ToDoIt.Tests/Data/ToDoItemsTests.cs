using System;
using Xunit;
using ToDoIt.Data;
using ToDoIt.Model;

namespace ToDoIt.Tests.Data
{
    public class ToDoItemsTests
    {

        [Fact]
        public void Clear_clearList_zero()
        {
            //arrange
            int expectedSizeOfToDoItems = 0;
            string description = "Tvätta kläder";

            ToDoItems todoItems = new ToDoItems();
            ToDo returnedTodo = todoItems.AddToDoItem(null, description);
            Assert.Equal(1, todoItems.Size());

            //act
            todoItems.Clear();

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());

        }

        [Fact]
        public void AddTodoItem_WithAssignee_sizeCorrect_descriptionCorrect()
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
            ToDo returnedTodo = todoItems.AddToDoItem(assignee, description);

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());
            Assert.Equal(description, returnedTodo.Description);
        }

        [Fact]
        public void AddTodoItem_WithoutAssignee_SizeDescription()
        {
            //arrange
            Person assignee = null;

            int expectedSizeOfToDoItems = 1;
            string description = "Handla mat";
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //act
            ToDo returnedTodo = todoItems.AddToDoItem(assignee, description);

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());
            Assert.Equal(description, returnedTodo.Description);
        }

        [Fact]
        public void FindAllItems_findsAll_arraySize()
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
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            ToDo[] itemArray = todoItems.FindAll();

            //assert
            Assert.Equal(expectedSizeOfToDoItems, itemArray.Length);
        }

        [Fact]
        public void FindItemById_return1_description()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";

            TodoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 2 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            int size = todoItems.Size();
            
            //act
            ToDo foundItem = todoItems.FindById(size);

            //assert
            Assert.Equal(description2, foundItem.Description);
        }
    }
}
