using System;
using System.Collections.Generic;
using ToDoIt.Model;

namespace ToDoIt.Data
{

    public class TodoItems
    {
        private static Todo[] myItems;

        /// <summary>
        /// The constructor of the todoitems allocates an empty array of Todo objects
        /// </summary>
        public TodoItems()
        {
            myItems = new Todo[0];
        }

        /// <summary>
        /// Size returns the size of the Array collection.
        /// </summary>
        /// <returns>Returns an int representing number of items</returns>
        public int Size()
        {
            return myItems.Length;
        }

        /// <summary>
        /// FindAll returns all todo items
        /// </summary>
        /// <returns>Returns the collection of Todo's</returns>
        public Todo[] FindAll()
        {
            return myItems;
        }

        /// <summary>
        /// Method creates a new Todo item, assignes it to the Assignee if any.
        /// The new Todo item is then inserted into the items list and finally returned.
        /// </summary>
        /// <param name="assignee">Either a Person object or null if not yet assigned</param>
        /// <param name="description">The desription of the Todo.</param>
        /// <returns>Returns the object of the created Todo item</returns>
        public Todo AddToDoItem(Person assignee, string description)
        {
            int nextItemId = TodoSequencer.nextTodoId();

            Todo newTodo = new Todo(nextItemId, description)
            {
                Assignee = assignee
            };

            //extend array by one and insert new todo last.
            int arrayLength = this.Size();
            Array.Resize(ref myItems, arrayLength + 1);
            myItems[arrayLength] = newTodo;

            return newTodo;
        }

        /// <summary>
        /// The method returns the Todo item with the requested Id
        /// </summary>
        /// <param name="todoId">The unique Todo identification number.</param>
        /// <returns>Returns the Todo item if found. Otherwise returns null.</returns>
        public Todo FindById(int todoId)
        {
            int returnIndex = -1;

            for (int i = 0; i < myItems.Length; i++)
            {
                if (myItems[i].TodoId == todoId)
                {
                    returnIndex = i;
                }
            }
            if (returnIndex != -1)
            {
                return myItems[returnIndex];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// The method creates a new empty list of Todo items.
        /// </summary>
        public void Clear()
        {
            myItems = new Todo[0];
            TodoSequencer.reset();
        }

        /// <summary>
        /// Finds all TodoItems that has the provided doneStatus.
        /// </summary>
        /// <param name="doneStatus">The doneStatus to filter on</param>
        /// <returns>Returns all Todo items in the wanted status or an empty array.</returns>
        public Todo[] FindByDoneStatus(bool doneStatus)
        {

            Todo[] returnArray = new Todo[0];
            List<Todo> returnList = new List<Todo>();


            for (int i = 0; i < myItems.Length; i++)
            {
                if (myItems[i].Done == doneStatus)
                {
                    int arrayLength = returnArray.Length;
                    Array.Resize(ref returnArray, arrayLength + 1);

                    returnArray[arrayLength] = myItems[i];
                }
            }
            return returnArray;
        }

        /// <summary>
        /// Finds all Todo items by the assigned person based on the personal Id.
        /// </summary>
        /// <param name="personId">The unique Id of an assigned Person</param>
        /// <returns>Returns all Todo items assigned to the specified person in an Array.
        /// If person do not have assignment the return array is empty.</returns>
        public Todo[] FindByAssignee(int personId)
        {
            Todo[] returnArray = new Todo[0];

            for (int i = 0; i < myItems.Length; i++)
            {
                if (myItems[i].Assignee != null &&
                    myItems[i].Assignee.PersonId == personId)
                {
                    int arrayLength = returnArray.Length;
                    Array.Resize(ref returnArray, arrayLength + 1);

                    returnArray[arrayLength] = myItems[i];
                }
            }
            return returnArray;
        }

        /// <summary>
        /// Finds all Todo items by the assigned person based on the personal object.
        /// </summary>
        /// <param name="assignee">The person input is an object of Person contained in the collection.</param>
        /// <returns>Returns all Todo items assigned to the specified person in an Array.
        /// If person do not have assignment the return array is empty.</returns>
        public Todo[] FindByAssignee(Person assignee)
        {
            Todo[] returnArray = new Todo[0];

            for (int i = 0; i < myItems.Length; i++)
            {
                if (myItems[i].Assignee == assignee)
                {
                    int arrayLength = returnArray.Length;
                    Array.Resize(ref returnArray, arrayLength + 1);

                    returnArray[arrayLength] = myItems[i];
                }
            }
            return returnArray;
        }

        /// <summary>
        /// Looks upp all the Todo items that are not assigned.
        /// </summary>
        /// <returns>Returns an Array of unassigned ToDos. If no unassigned
        /// ToDos is found the returned Array is empty.</returns>
        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] returnArray = new Todo[0];

            for (int i = 0; i < myItems.Length; i++)
            {
                if (myItems[i].Assignee == null)
                {
                    int arrayLength = returnArray.Length;
                    Array.Resize(ref returnArray, arrayLength + 1);

                    returnArray[arrayLength] = myItems[i];
                }
            }
            return returnArray;
        }

        /// <summary>
        /// Remove takes one specified object of Todo out of the Array
        /// collection and resizes the remaining Array accordingly.
        /// </summary>
        /// <param name="myToDo">The Todo object to remove from Array
        /// Collection. If not found nothing will happen.</param>
        public void Remove(Todo myToDo)
        {
            int myToDoCollection = myItems.Length;
            int myIndexedToDo = -1;
            bool notDoneYet = true;

            int myLoop = 0;
            while (notDoneYet)
            {

                if (myItems[myLoop].TodoId == myToDo.TodoId)
                {
                    myIndexedToDo = myLoop;
                    notDoneYet = false;
                }
                myLoop++;

                if (myLoop == myToDoCollection)
                {
                    notDoneYet = false;
                }
            }

            if (myIndexedToDo != -1)
            {
                for (int removeLoop = myIndexedToDo; removeLoop < myToDoCollection - 1; removeLoop++)
                {
                    myItems[removeLoop] = myItems[removeLoop + 1];
                }

                Array.Resize(ref myItems, myToDoCollection - 1);
            }
        }

    }
}
