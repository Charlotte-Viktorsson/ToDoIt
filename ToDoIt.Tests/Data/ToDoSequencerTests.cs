using System;
using Xunit;
using ToDoIt.Data;

namespace ToDoIt.Tests.Data
{
    public class ToDoSequencerTests
    {
        [Fact]
        public void GetNextTodoIdTest()
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
        public void ResetTodoIdTest()
        {
            //arrange
            TodoSequencer.Reset();
            int expectedResetId = 1;
            // consume 2 id's
            int nextId = TodoSequencer.NextTodoId();
            nextId = TodoSequencer.NextTodoId();
            Assert.Equal(2, nextId);

            //act
            TodoSequencer.Reset();
            nextId = TodoSequencer.NextTodoId();

            //assert
            Assert.Equal(expectedResetId, nextId);
        }
    }
}
