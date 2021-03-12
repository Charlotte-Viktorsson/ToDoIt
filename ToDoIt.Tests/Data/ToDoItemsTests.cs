using ToDoIt.Data;
using ToDoIt.Model;
using Xunit;

namespace ToDoIt.Tests.Data
{
    public class TodoItemsTests
    {

        [Fact]
        public void Clear_ClearList_SizeIsZero()
        {
            //arrange
            int expectedSizeOfToDoItems = 0;
            string description = "Tvätta kläder";

            TodoItems todoItems = new TodoItems();
            Todo returnedTodo = todoItems.AddToDoItem(null, description);
            Assert.Equal(1, todoItems.Size());

            //act
            todoItems.Clear();

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());
        }

        [Fact]
        public void AddTodoItem_WithAssignee_SizeAndDescriptionCorrect()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Anna";
            string familyName = "Jansson";
            Person assignee = new Person(personId, firstName, familyName);

            int expectedSizeOfToDoItems = 1;
            string description = "Tvätta bilen";
            TodoItems todoItems = new TodoItems();

            //act
            Todo addedTodo = todoItems.AddToDoItem(assignee, description);

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());
            Assert.Equal(description, addedTodo.Description);
        }

        [Fact]
        public void AddTodoItem_WithoutAssignee_SizeDescription()
        {
            //arrange
            Person assignee = null;

            int expectedSizeOfToDoItems = 1;
            string description = "Handla mat";
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //act
            Todo addedTodo = todoItems.AddToDoItem(assignee, description);

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());
            Assert.Equal(description, addedTodo.Description);
        }

        [Fact]
        public void AddTodoItem_WithoutDescription_DescriptionEmpty()
        {
            //arrange
            Person assignee = null;

            int expectedSizeOfToDoItems = 1;
            string expectedDescription = "";
            string description = null;
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //act
            Todo addedTodo = todoItems.AddToDoItem(assignee, description);

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());
            Assert.Equal(expectedDescription, addedTodo.Description);
        }

        [Fact]
        public void FindAllItems_FindsAll_CorrectArraySize()
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

            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            Todo[] itemArray = todoItems.FindAll();

            //assert
            Assert.Equal(expectedSizeOfToDoItems, itemArray.Length);
        }

        [Fact]
        public void FindAllItems_ClearedItems_EmptyArray()
        {
            //arrange
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //act
            Todo[] itemArray = todoItems.FindAll();

            //assert
            Assert.Empty(itemArray);
        }

        [Fact]
        public void FindItemById_FindOne_CorrectDescription()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 2 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            int size = todoItems.Size();

            //act
            Todo foundLastItem = todoItems.FindById(size);
            Todo foundFirstItem = todoItems.FindById(1);

            //assert
            Assert.Equal(description2, foundLastItem.Description);
            Assert.Equal(description1, foundFirstItem.Description);
        }

        [Fact]
        public void FindItemById_UnknownId_NoneReturned()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 2 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            int size = todoItems.Size();

            //act
            Todo foundItem = todoItems.FindById(size + 3);

            //assert
            Assert.Null(foundItem);
        }

        [Fact]
        public void FindByDoneStatus_FindOnlyOne_Arraysize1()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 2 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);

            //set one item to done.
            Todo itemToBeDone = todoItems.FindById(1);
            itemToBeDone.Done = true;

            //act
            Todo[] foundItemsArray = todoItems.FindByDoneStatus(true);

            //assert
            Assert.Single(foundItemsArray);
            Assert.Equal(description1, foundItemsArray[0].Description);
        }

        [Fact]
        public void FindByDoneStatus_FindOnlyNotDone_Arraysize3()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 3 not done
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            todoItems.AddToDoItem(assignee, description3);

            //set one of the items to done.
            Todo itemToBeDone = todoItems.FindById(1);
            itemToBeDone.Done = true;

            //act
            Todo[] foundItemsArray = todoItems.FindByDoneStatus(false);

            //assert
            Assert.Equal(2, foundItemsArray.Length);
        }

        [Fact]
        public void FindByDoneStatus_FindNoDone_Arraysize0()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 3 not done
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            todoItems.AddToDoItem(assignee, description3);

            //act
            Todo[] foundItemsArray = todoItems.FindByDoneStatus(true);

            //assert
            Assert.Empty(foundItemsArray);
        }

        [Fact]
        public void FindByAssigneeInt_FindTwo_Arraysize2()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            Todo[] foundItemsArray = todoItems.FindByAssignee(personId);

            //assert
            Assert.Equal(2, foundItemsArray.Length);
        }

        [Fact]
        public void FindByAssigneeInt_NotFound_Arraysize0()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            Todo[] foundItemsArray = todoItems.FindByAssignee(personId + 10);

            //assert
            Assert.Empty(foundItemsArray);
        }

        [Fact]
        public void FindByAssigneePerson_FindOnlyOne_Arraysize1()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee1 = new Person(personId, firstName, familyName);

            personId = PersonSequencer.nextPersonId();
            Person assignee2 = new Person(personId, "Klara", familyName);

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";

            //TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee1, description1);
            todoItems.AddToDoItem(assignee2, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            Todo[] foundItemsArray = todoItems.FindByAssignee(assignee1);

            //assert
            Assert.Single(foundItemsArray);
        }

        [Fact]
        public void FindByAssigneePerson_NullPerson_ReturnsUnassignedItems()
        {
            //findbyAssignee(null) will return the unassigned items

            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee1 = new Person(personId, firstName, familyName);

            personId = PersonSequencer.nextPersonId();
            Person assignee2 = new Person(personId, "Klara", familyName);

            Person assignee3 = null;

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";

            //TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee1, description1);
            todoItems.AddToDoItem(assignee2, description2);
            todoItems.AddToDoItem(assignee3, description3);

            //act
            Todo[] foundItemsArray = todoItems.FindByAssignee(assignee3);

            //assert
            Assert.Single(foundItemsArray);
        }

        [Fact]
        public void FindUnassigned_FindOnlyOne_Arraysize3()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 4 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(null, description1);
            todoItems.AddToDoItem(null, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            Todo[] foundItemsArray = todoItems.FindUnassignedTodoItems();

            //assert
            Assert.Equal(3, foundItemsArray.Length);
            Assert.Equal(description1, foundItemsArray[0].Description);
        }

        [Fact]
        public void Remove_RemoveOneInMiddle_RemoveOnlyOne()
        {
            //arrange

            Todo myToDo = null;
            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";
            string description4 = "Läxor";
            int expectedNumberOfItems = 3;

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 4 items
            int myInitialNumber = todoItems.Size();
            todoItems.AddToDoItem(null, description1);
            todoItems.AddToDoItem(null, description2);
            myToDo = todoItems.AddToDoItem(null, description3);
            todoItems.AddToDoItem(null, description4);

            //act
            todoItems.Remove(myToDo);
            int myAdjustedNumber = todoItems.Size();

            //assert
            Assert.NotEqual(myInitialNumber, myAdjustedNumber);
            Assert.Equal(expectedNumberOfItems, myAdjustedNumber);
        }

        [Fact]
        public void Remove_RemoveLast_RemoveOnlyOne()
        {
            //arrange
            Todo myToDo = null;
            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";
            string description4 = "Läxor";
            int expectedNumberOfItems = 3;

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 4 items
            int myInitialNumber = todoItems.Size();
            todoItems.AddToDoItem(null, description1);
            todoItems.AddToDoItem(null, description2);
            todoItems.AddToDoItem(null, description3);
            myToDo = todoItems.AddToDoItem(null, description4);

            //act
            todoItems.Remove(myToDo);
            int myAdjustedNumber = todoItems.Size();

            //assert
            Assert.Equal(description4, myToDo.Description);
            Assert.NotEqual(myInitialNumber, myAdjustedNumber);
            Assert.Equal(expectedNumberOfItems, myAdjustedNumber);
        }

        [Fact]
        public void Remove_RemoveFirst_RemoveOnlyOne()
        {
            //arrange
            Todo myToDo = null;
            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";
            int expectedNumberOfItems = 2;

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 3 items
            int myInitialNumber = todoItems.Size();
            myToDo = todoItems.AddToDoItem(null, description1);
            todoItems.AddToDoItem(null, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            todoItems.Remove(myToDo);
            int myAdjustedNumber = todoItems.Size();

            //assert
            Assert.Equal(description1, myToDo.Description);
            Assert.NotEqual(myInitialNumber, myAdjustedNumber);
            Assert.Equal(expectedNumberOfItems, myAdjustedNumber);
        }

        [Fact]
        public void Remove_RemoveOneNotIncluded_RemoveNothing()
        {
            //arrange
            Todo myToDo = null;
            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";
            string description4 = "Läxor";
            int expectedNumberOfItems = 4;

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 4 items
            todoItems.AddToDoItem(null, description1);
            todoItems.AddToDoItem(null, description2);
            todoItems.AddToDoItem(null, description3);
            todoItems.AddToDoItem(null, description4);

            myToDo = new Todo(0, "Not added todo");

            //act
            todoItems.Remove(myToDo);
            int myAdjustedNumber = todoItems.Size();

            //assert
            Assert.Equal(myAdjustedNumber, expectedNumberOfItems);
        }

        [Fact]
        public void Remove_RemoveNull_NothingRemovedNoCrash()
        {
            //arrange
            Todo myToDo = null;
            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";
            string description4 = "Läxor";
            int expectedNumberOfItems = 4;

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 4 items
            todoItems.AddToDoItem(null, description1);
            todoItems.AddToDoItem(null, description2);
            todoItems.AddToDoItem(null, description3);
            todoItems.AddToDoItem(null, description4);

            //act
            todoItems.Remove(myToDo);
            int myAdjustedNumber = todoItems.Size();

            //assert
            Assert.Equal(myAdjustedNumber, expectedNumberOfItems);
        }
    }
}
