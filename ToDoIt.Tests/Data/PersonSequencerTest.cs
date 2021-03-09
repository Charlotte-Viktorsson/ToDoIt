using ToDoIt.Data;
using Xunit;

namespace ToDoIt.Tests.Data
{
    public class PersonSequencerTest
    {
        [Fact]
        public void NextPersonId_StepupId_Increase()
        {
            //Arrange
            int expectedId = 1;
            PersonSequencer.reset();
            //Act
            int getId = PersonSequencer.nextPersonId();
            // Assert
            Assert.Equal(expectedId, getId);
        }

        [Fact]
        public void NextPessonId_StepupId3_Increase3()
        {
            //Arrange
            int expectedId = 3;
            PersonSequencer.reset();
            //Act
            int getId = PersonSequencer.nextPersonId();
            getId = PersonSequencer.nextPersonId();
            getId = PersonSequencer.nextPersonId();
            // Assert
            Assert.Equal(expectedId, getId);
        }

        [Fact]
        public void NextPessonId_Stepup3ResetId_GetOne()
        {
            //Arrange
            int expectedId = 1;
            PersonSequencer.reset();
            //Act
            int getId = PersonSequencer.nextPersonId();
            getId = PersonSequencer.nextPersonId();
            getId = PersonSequencer.nextPersonId();
            PersonSequencer.reset();
            getId = PersonSequencer.nextPersonId();
            // Assert
            Assert.Equal(expectedId, getId);

        }


    }
}
