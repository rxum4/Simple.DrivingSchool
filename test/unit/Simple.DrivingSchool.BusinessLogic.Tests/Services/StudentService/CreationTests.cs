namespace Simple.DrivingSchool.BusinessLogic.Tests.Services
{
    using System;
    using System.Threading.Tasks;

    using Moq;
    using Xunit;
    using Xunit.Sdk;

    using Simple.DrivingSchool.BusinessLogic.Models;

    using bl = Simple.DrivingSchool.BusinessLogic.Services;
    using dao = Simple.DrivingSchool.DataAccess.Models;
    public partial class StudentServiceTest
    {
        public class CreationTests
        {
            public MockContainer MockContainer { get; } = new MockContainer();

            [Fact]
            public void Given_ValidStudent_When_CreateAsyncCalled_Then_TaskIsReturned()
            {
                //Given
                var validStudent = CreateValidStudent();

                //When
                var result = MockContainer.Instance.CreateAsync(validStudent);
                //Then
                Assert.NotNull(result);
            }

            [Fact]
            public async Task Given_Null_When_CreateAsyncCalled_Then_ThrowsExpection()
            {
                //Given

                //When
                var functionCall = new Func<Task>(() => MockContainer.Instance.CreateAsync(null));
                //Then
                await Assert.ThrowsAsync<ArgumentNullException>(functionCall);
            }

            [Fact]
            public async Task When_CreateAsyncCalled_Then_RepositoryIsCalled()
            {
                //Given
                MockContainer.ResetMocks();
                var validStudent = CreateValidStudent();

                //When
                await MockContainer.Instance.CreateAsync(validStudent);
                //Then
                MockContainer.StudentRepositoryMock.Verify(mock => mock.CreateAsync(It.IsAny<dao.StudentCreationModel>()));
            }

            [Fact]
            public async Task Given_Student_When_CreateAsyncCalled_Then_ModelBuilderIsUsedToCreateCreationModel()
            {
                //Given
                MockContainer.ResetMocks();
                var validStudent = CreateValidStudent();
                var expectedCreationModel = new dao.StudentCreationModel();
                MockContainer.StudentModelBuilderMock
                    .Setup(builder => builder.GenerateCreationModelAsync(validStudent))
                    .ReturnsAsync(expectedCreationModel);

                //When
                await MockContainer.Instance.CreateAsync(validStudent);
                //Then
                MockContainer.StudentRepositoryMock.Verify(mock => mock.CreateAsync(expectedCreationModel));
            }

            private Student CreateValidStudent()
            {
                return new Student
                {

                };
            }
        }
    }
}