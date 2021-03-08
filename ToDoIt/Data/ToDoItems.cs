﻿using System;
using System.Collections.Generic;
using System.Text;
using ToDoIt.Model;

namespace ToDoIt.Data
{

    public class ToDoItems
    {
        private static ToDo[] items;

        public ToDoItems()
        {
            items = new ToDo[0];
        }

        /// <summary>
        /// returns the size of the items list
        /// </summary>
        /// <returns>int size</returns>
        public int Size()
        {
            return items.Length;
        }

        /// <summary>
        /// returns all items
        /// </summary>
        /// <returns>ToDo[]</returns>
        public ToDo[] FindAll()
        {
            return items;
        }

        /// <summary>
        /// Method creates a new ToDo item, assignes it to the Assignee if any.
        /// The new ToDo item is then inserted into the items list and finally returned.
        /// </summary>
        /// <param name="assignee"></param>
        /// <param name="description"></param>
        /// <returns>Returns the object of the created ToDo item</returns>
        public ToDo CreateToDoItem(Person assignee, string description)
        {
            int nextItemId = TodoSequencer.NextTodoId();

            ToDo newTodo = new ToDo(nextItemId, description);
            newTodo.Assignee = assignee;

            //extend array by one.
            int arrayLength = this.Size();
            Array.Resize(ref items, arrayLength + 1);
            items[arrayLength] = newTodo;

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
            
            for(int i = 0; i < items.Length; i++)
            {
                if (items[i].TodoId == todoId)
                {
                    returnIndex = i;
                }
            }
            if (returnIndex != -1)
            {
                return items[returnIndex];
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
            items = new ToDo[0];
        }

        /*public ToDo[] FindByDoneStatus(bool doneStatus) {
            
        }

        public ToDo[] FindByAssignee(int personId)
        {

        }

        public ToDo[] FindByAssignee(Person assignee)
        {

        }
        public ToDo[] FindUnassignedTodoItems()
        {

        }*/

    }
}
