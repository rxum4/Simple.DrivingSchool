namespace Simple.DrivingSchool.BusinessLogic.ModelBuilder
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;

    using dto = Simple.DrivingSchool.BusinessLogic.Models;
    using dao = Simple.DrivingSchool.DataAccess.Models;
    public class StudentModelBuilder : Abstraction.IStudentModelBuilder
    {
        public StudentModelBuilder(IMapper mapper)
        {
            Mapper = mapper;
        }

        public IMapper Mapper { get; }

        public Task<dao.StudentCreationModel> GenerateCreationModelAsync(dto.Student student)
        {
            var mapperResult = Mapper.Map<dao.StudentCreationModel>(student);
            return Task.FromResult(mapperResult);
        }
    }
}