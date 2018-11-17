namespace Simple.DrivingSchool.Server.Tests.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Moq;
    using Xunit;

    using Simple.DrivingSchool.BusinessLogic.Models;
    using Simple.DrivingSchool.BusinessLogic.Services.Abstraction;
    using Simple.DrivingSchool.Server.Controllers;
    public class StudentControllerTests
    {
        public StudentController Instance { get; }
        public Mock<IStudentService> ServiceMock { get; }

        public StudentControllerTests()
        {
            ServiceMock = new Mock<IStudentService>();
            Instance = new StudentController(ServiceMock.Object);
        }

        [Fact]
        public void Given_ValidStudent_When_CreateRequestRecieved_Then_ServiceIsCalled()
        {
            //Given
            var validStudent = GenerateValidStudent();
            ServiceMock.Invocations.Clear();
            ServiceMock
                .Setup(service => service.CreateAsync(validStudent))
                .Returns(Task.CompletedTask)
                .Verifiable();
            //When
            Instance.CreateAsync(validStudent);
            //Then
            ServiceMock.Verify();
        }

        private Student GenerateValidStudent()
        {
            return new Student
            {

            };
        }
    }
}
