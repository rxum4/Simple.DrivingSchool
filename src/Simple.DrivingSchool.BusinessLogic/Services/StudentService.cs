namespace Simple.DrivingSchool.BusinessLogic.Services
{
    using System;
    using System.Threading.Tasks;

    using Simple.DrivingSchool.BusinessLogic.ModelBuilder.Abstraction;
    using Simple.DrivingSchool.BusinessLogic.Models;
    using Simple.DrivingSchool.DataAccess.Repositories.Abstraction;
    public class StudentService : Abstraction.IStudentService
    {
        public IStudentRepository StudentRepository { get; }
        public IStudentModelBuilder StudentModelBuilder { get; }

        public StudentService(IStudentRepository studentRepository, IStudentModelBuilder studentModelBuilder)
        {
            StudentRepository = studentRepository;
            StudentModelBuilder = studentModelBuilder;
        }
        public async Task CreateAsync(Student student)
        {
            if (student is null)
                throw new ArgumentNullException();

            var creationModel = await StudentModelBuilder.GenerateCreationModel(student);

            await StudentRepository.CreateAsync(creationModel);
        }
    }
}