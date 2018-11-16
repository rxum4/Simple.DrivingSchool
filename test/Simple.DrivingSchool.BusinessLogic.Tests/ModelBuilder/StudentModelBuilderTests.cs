namespace Simple.DrivingSchool.BusinessLogic.Tests.Services
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;
    using Moq;
    using Xunit;
    using Xunit.Sdk;

    using Simple.DrivingSchool.BusinessLogic.ModelBuilder;
    using Simple.DrivingSchool.BusinessLogic.ModelBuilder.Abstraction;

    using dto = Simple.DrivingSchool.BusinessLogic.Models;
    using dao = Simple.DrivingSchool.DataAccess.Models;
    public class StudentModelBuilderTests
    {
        public IStudentModelBuilder ModelBuilder { get; set; }
        public Mock<IMapper> MapperMock { get; set; }

        public StudentModelBuilderTests()
        {
            MapperMock = new Mock<IMapper>();
            ModelBuilder = new StudentModelBuilder(MapperMock.Object);
        }

        [Fact]
        public async Task Given_Null_When_ConvertedToCreationModel_Then_TaskIsReturned()
        {
            //Given
            var input = null as dto.Student;
            //When
            var result = ModelBuilder.GenerateCreationModel(input);
            //Then
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Given_Null_When_ConvertedToCreationModel_Then_NullIsReturned()
        {
            //Given
            var input = null as dto.Student;
            //When
            var result = await ModelBuilder.GenerateCreationModel(input);
            //Then
            Assert.Null(result);
        }

        [Fact]
        public async Task Given_Student_When_ConvertedToCreationModel_Then_AutoMapperIsUsed()
        {
            //Given
            var input = new dto.Student();
            var expectation = new dao.StudentCreationModel();
            MapperMock.Setup(mapper => mapper.Map<dao.StudentCreationModel>(input)).Returns(expectation);
            //When
            var result = await ModelBuilder.GenerateCreationModel(input);
            //Then
            Assert.Same(expectation, result);
        }
    }
}