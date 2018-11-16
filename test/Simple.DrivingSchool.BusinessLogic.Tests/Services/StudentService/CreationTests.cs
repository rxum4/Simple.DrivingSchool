namespace Simple.DrivingSchool.BusinessLogic.Tests.Services
{
    using System;
    using System.Threading.Tasks;

    using Moq;
    using Xunit;
    using Xunit.Sdk;

    using Simple.DrivingSchool.BusinessLogic.Models;
    public partial class StudentServiceTest
    {
        public class CreationTests
        {
            public MockContainer MockContainer { get; } = new MockContainer();

            [Fact]
            public async Task Given_ValidStudent_When_CreateAsyncCalled_Then_TaskIsReturned()
            {
                //Given
                var validStudent = CreateValidStudent();

                //When
                var result = MockContainer.Instance.CreateAsync(validStudent);
                //Then
                Assert.NotNull(result);
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