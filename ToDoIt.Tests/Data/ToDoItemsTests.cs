using ToDoIt.Data;
using ToDoIt.Model;
using Xunit;

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

            TodoItems todoItems = new TodoItems();
            Todo returnedTodo = todoItems.AddToDoItem(null, description);
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
            TodoItems todoItems = new TodoItems();

            //act
            Todo returnedTodo = todoItems.AddToDoItem(assignee, description);

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
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //act
            Todo returnedTodo = todoItems.AddToDoItem(assignee, description);

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
        public void FindItemById_return1_description()
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
            Todo foundItem = todoItems.FindById(size);

            //assert
            Assert.Equal(description2, foundItem.Description);
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
        public void FindByDoneStatus_FindOnlyNotDone_Arraysize2()
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
            todoItems.AddToDoItem(assignee, description3);

            //set one item to done.
            Todo itemToBeDone = todoItems.FindById(1);
            itemToBeDone.Done = true;

            //act
            Todo[] foundItemsArray = todoItems.FindByDoneStatus(false);

            //assert
            Assert.Equal(2, foundItemsArray.Length);

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
        public void FindByAssigneePerson_FindOnlyOne_Arraysize1()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            personId = PersonSequencer.nextPersonId();
            Person assignee2 = new Person(personId, "Klara", familyName);

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee2, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            Todo[] foundItemsArray = todoItems.FindByAssignee(assignee);

            //assert
            Assert.Single(foundItemsArray);
        }

        [Fact]
        public void FindUnassigned_FindOnlyOne_Arraysize1()
        {
            //arrange
            int personId = PersonSequencer.nextPersonId();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            personId = PersonSequencer.nextPersonId();
            Person assignee2 = new Person(personId, "Klara", familyName);

            string description1 = "Gå ut med hunden";
            string description2 = "Kela med katten";
            string description3 = "Promenera";

            TodoSequencer.reset();
            TodoItems todoItems = new TodoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee2, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            Todo[] foundItemsArray = todoItems.FindUnassignedTodoItems();

            //assert
            Assert.Single(foundItemsArray);
            Assert.Equal(description3, foundItemsArray[0].Description);
        }


        [Fact]
        public void Remove_RemoveOne_RemoveOnlyOne()
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

            myToDo = new Todo(0, "Självdö");

            //act
            todoItems.Remove(myToDo);
            int myAdjustedNumber = todoItems.Size();

            //assert
            //Assert.NotEqual(myInitialNumber, myAdjustedNumber);
            Assert.Equal(myAdjustedNumber, expectedNumberOfItems);
        }
    }
}
