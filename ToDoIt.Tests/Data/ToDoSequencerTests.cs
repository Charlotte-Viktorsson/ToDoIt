using ToDoIt.Data;
using Xunit;

namespace ToDoIt.Tests.Data
{
    public class TodoSequencerTests
    {
        [Fact]
        public void NextTodoId_getNextTodoId_id()
        {
            //arrange
            TodoSequencer.reset();
            int expectedNextId = 1;
            //act
            int nextId = TodoSequencer.nextTodoId();

            //assert
            Assert.Equal(expectedNextId, nextId);
        }

        [Fact]
        public void Reset_ResetId_NextToDoId()
        {
            //arrange
            TodoSequencer.reset();
            int expectedResetId = 1;
            // consume 2 id's
            int nextId = TodoSequencer.nextTodoId();
            nextId = TodoSequencer.nextTodoId();


            //act
            TodoSequencer.reset();
            int newId = TodoSequencer.nextTodoId();

            //assert
            Assert.NotEqual(nextId, newId);
            Assert.Equal(expectedResetId, newId);
        }
    }
}
