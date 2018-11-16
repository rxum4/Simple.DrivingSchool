namespace Simple.DrivingSchool.BusinessLogic.Tests.Services
{
    using System;
    using System.Threading.Tasks;

    using Moq;

    using Simple.DrivingSchool.BusinessLogic.Services;
    using Simple.DrivingSchool.BusinessLogic.Services.Abstraction;

    public partial class StudentServiceTest
    {
        public class MockContainer
        {
            public IStudentService Instance { get; }

            public MockContainer()
            {
                Instance = new StudentService();
            }
        }
    }
}