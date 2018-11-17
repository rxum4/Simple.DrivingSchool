namespace Simple.DrivingSchool.DataAccess.Tests.Repositories
{
    using System;
    using System.Threading.Tasks;

    using Moq;
    using Xunit;

    using Simple.DrivingSchool.DataAccess.Models;
    using Simple.DrivingSchool.DataAccess.Persistence.Abstraction;
    using Simple.DrivingSchool.DataAccess.Repositories;
    using Simple.DrivingSchool.DataAccess.Repositories.Abstraction;
    public class StudentRepositoryTests
    {
        public StudentRepositoryTests()
        {
            PersistenceMock = new Mock<IPersistence>();
            Instance = new StudentRepository(PersistenceMock.Object);
        }

        public Mock<IPersistence> PersistenceMock { get; }
        public IStudentRepository Instance { get; }

        [Fact]
        public void Given_ValidCreationModel_When_CreateCalled_Then_ATaskIsReturned()
        {
            //Given
            var validCreationModel = GenerateValidCreationModel();

            //When
            var result = Instance.CreateAsync(validCreationModel);

            //Then
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Given_Null_When_CreateCalled_Then_ExceptionIsThrown()
        {
            //Given
            //When
            var functionCall = new Func<Task>(() => Instance.CreateAsync(null));

            //Then
            await Assert.ThrowsAsync<ArgumentNullException>(functionCall);
        }

        [Fact]
        public async Task Given_ValidStudent_When_CreateCalled_Then_NoExceptionIsThrown()
        {
            //Given
            var validCreationModel = GenerateValidCreationModel();

            //When
            var functionCall = new Func<Task>(() => Instance.CreateAsync(validCreationModel));
            var exception = await Record.ExceptionAsync(functionCall);

            //Then
            Assert.Null(exception);
        }

        [Fact]
        public async Task Given_ValidStudent_When_CreateCalled_Then_UpsertIsPerformed()
        {
            //Given
            var validCreationModel = GenerateValidCreationModel();
            PersistenceMock.Invocations.Clear();
            PersistenceMock
                .Setup(persistence => persistence.Upsert(validCreationModel))
                .Returns(Task.CompletedTask)
                .Verifiable();

            //When
            await Instance.CreateAsync(validCreationModel);

            //Then
            PersistenceMock.Verify();
        }

        private StudentCreationModel GenerateValidCreationModel()
        {
            return new StudentCreationModel
            {

            };
        }
    }
}
