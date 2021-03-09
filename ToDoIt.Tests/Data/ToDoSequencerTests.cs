using System;
using Xunit;
using ToDoIt.Data;

namespace ToDoIt.Tests.Data
{
    public class ToDoSequencerTests
    {
        [Fact]
        public void NextTodoId_getNextTodoId_id()
        {
            //arrange
            TodoSequencer.Reset();
            int expectedNextId = 1;
            //act
            int nextId = TodoSequencer.NextTodoId();

            //assert
            Assert.Equal(expectedNextId, nextId);
        }

        [Fact]
        public void Reset_ResetId_NextToDoId()
        {
            //arrange
            TodoSequencer.Reset();
            int expectedResetId = 1;
            // consume 2 id's
            int nextId = TodoSequencer.NextTodoId();
            nextId = TodoSequencer.NextTodoId();
            

            //act
            TodoSequencer.Reset();
            int newId = TodoSequencer.NextTodoId();

            //assert
            Assert.NotEqual(nextId, newId);
            Assert.Equal(expectedResetId, newId);
        }
    }
}
