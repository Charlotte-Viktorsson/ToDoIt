using System;
using System.Collections.Generic;
using ToDoIt.Model;

namespace ToDoIt.Data
{

    public class ToDoItems
    {
        private static ToDo[] myItems;

        public ToDoItems()
        {
            myItems = new ToDo[0];
        }

        /// <summary>
        /// returns the size of the items list
        /// </summary>
        /// <returns>int size</returns>
        public int Size()
        {
            return myItems.Length;
        }

        /// <summary>
        /// returns all items
        /// </summary>
        /// <returns>ToDo[]</returns>
        public ToDo[] FindAll()
        {
            return myItems;
        }

        /// <summary>
        /// Method creates a new ToDo item, assignes it to the Assignee if any.
        /// The new ToDo item is then inserted into the items list and finally returned.
        /// </summary>
        /// <param name="assignee"></param>
        /// <param name="description"></param>
        /// <returns>Returns the object of the created ToDo item</returns>
        public ToDo AddToDoItem(Person assignee, string description)
        {
            int nextItemId = TodoSequencer.NextTodoId();

            ToDo newTodo = new ToDo(nextItemId, description);
            newTodo.Assignee = assignee;

            //extend array by one.
            int arrayLength = this.Size();
            Array.Resize(ref myItems, arrayLength + 1);
            myItems[arrayLength] = newTodo;

            return newTodo;
        }

        /// <summary>
        /// The method returns the ToDo item with the requested Id
        /// </summary>
        /// <param name="todoId"></param>
        /// <returns>Returns the ToDo item if found</returns>
        public ToDo FindById(int todoId)
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
        /// The method creates a new empty list of ToDo items.
        /// </summary>
        public void Clear()
        {
            myItems = new ToDo[0];
        }

        public ToDo[] FindByDoneStatus(bool doneStatus)
        {

            ToDo[] returnArray = new ToDo[0];
            List<ToDo> returnList = new List<ToDo>();


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

        public ToDo[] FindByAssignee(int personId)
        {
            ToDo[] returnArray = new ToDo[0];
            List<ToDo> returnList = new List<ToDo>();


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

        public ToDo[] FindByAssignee(Person assignee)
        {
            ToDo[] returnArray = new ToDo[0];
            List<ToDo> returnList = new List<ToDo>();


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

        public ToDo[] FindUnassignedTodoItems()
        {
            ToDo[] returnArray = new ToDo[0];
            List<ToDo> returnList = new List<ToDo>();


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

        public void Remove(ToDo myToDo)
        {
            int myToDoCollection = myItems.Length;
            int myIndexedToDo = -1;
            bool notDoneYet = true;

            //for (int myLoop = 0; (myItems[myLoop].TodoId != myToDo.TodoId) && (myLoop < myToDoCollection-1); myLoop++)
            //{
            //    if (myItems[myLoop].TodoId == myToDo.TodoId)
            //    {
            //        myIndexedToDo = myLoop;
            //    }
            //}
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
