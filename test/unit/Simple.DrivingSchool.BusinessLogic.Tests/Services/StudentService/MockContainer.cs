namespace Simple.DrivingSchool.BusinessLogic.Tests.Services
{
    using System;
    using System.Threading.Tasks;

    using Moq;

    using Simple.DrivingSchool.BusinessLogic.ModelBuilder.Abstraction;
    using Simple.DrivingSchool.DataAccess.Repositories.Abstraction;

    using bl = Simple.DrivingSchool.BusinessLogic.Services;
    using dao = Simple.DrivingSchool.DataAccess.Models;
    using dto = Simple.DrivingSchool.BusinessLogic.Models;

    public partial class StudentServiceTest
    {
        public class MockContainer
        {
            public bl.Abstraction.IStudentService Instance { get; }


            public Mock<IStudentRepository> StudentRepositoryMock { get; }

            public Mock<IStudentModelBuilder> StudentModelBuilderMock { get; }


            public MockContainer()
            {
                StudentRepositoryMock = new Mock<IStudentRepository>();
                StudentModelBuilderMock = new Mock<IStudentModelBuilder>();
                Instance = new bl.StudentService(
                            StudentRepositoryMock.Object,
                            StudentModelBuilderMock.Object);
                ResetMocks();
            }

            public void ResetMocks()
            {
                ResetStudentRepositoryMock();
                ResetStudentModelBuilderMock();
            }

            private void ResetStudentRepositoryMock()
            {
                StudentRepositoryMock.Reset();
                StudentRepositoryMock.SetReturnsDefault(Task.CompletedTask);
            }

            private void ResetStudentModelBuilderMock()
            {
                StudentModelBuilderMock.Reset();
                StudentModelBuilderMock.SetReturnsDefault(Task.CompletedTask);
                StudentModelBuilderMock.SetReturnsDefault(Task.FromResult(null as dao.StudentCreationModel));
            }
        }
    }
}